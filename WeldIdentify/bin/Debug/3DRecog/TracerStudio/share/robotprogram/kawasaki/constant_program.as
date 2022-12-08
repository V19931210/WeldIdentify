.PROGRAM c3d_weld() #0 \
;FUNCTION c3d_weld:执行焊接示例任务，焊接工艺需要在此修改,
;如有定制需求，请自行编写
  POINT .safe_point = start_weld[1]
  POINT safez = TRANS(0,0,safe_z,0,0,0)
  POINT/Z safe_point = safez
  JMOVE .safe_point
    FOR .i = 1 TO path_num
        LMOVE start_weld[.i]
        IF weld_type[.i] == 0  THEN   
            IF gap[.i] >5 THEN 
                W1SET 20 = 22,260,25.5,5,1.2
            END
            IF 2<gap[.i]<5 THEN 
                W1SET 20 = 22,260,25.5,5,1.2
            END
            IF gap[.i]<2 THEN 
                W1SET 20 = 22,260,25.5,5,1.2
            END            
        END
        IF weld_type[.i] == 1  THEN   
            IF gap[.i]>5 THEN 
                W1SET 20 = 22,260,25.5,5,1.2
            END
            IF 2<gap[.i]<5 THEN 
                W1SET 20 = 22,260,25.5,5,1.2
            END
            IF gap[.i]<2 THEN 
                W1SET 20 = 22,260,25.5,5,1.2
            END
        END
        LWS weld_points[.i,1] 
        FOR .j = 2 TO weld_point_num[.i]-1 
            LWC weld_points[.i,.j] 20
        END 
        .m = weld_point_num[.i]
        LWE weld_points[.i,.m],20,1
        LMOVE end_weld[.i]
    END
    POINT .safe_point = end_weld[path_num]
    POINT safez = TRANS(0,0,safe_z,0,0,0)
    POINT/Z safe_point = safez
    LMOVE .safe_point
.END
.PROGRAM c3d_connect()
;**********************************************************
;*以下C3D程序库禁止修改                                   *
;                                                         *
;                                                         *
;**********************************************************
;FUNCTION c3d_connect:客户端建立连接，并打开软件服务
re_connect:
    TCP_STATUS .tcp_cnt,.port[0],.sock[0],.err[0],.sub[0],.$ip_add[0] 
    IF .tcp_cnt>0 THEN
        CALL c3d_close  ;关闭通讯
    END
    .er_count = 1
connect:
;TCP_CONNECT 套接字号，端口号，IP地址，超时时间
    TCP_CONNECT sock_id,port,ip[1],timeout
    IF sock_id<0 THEN
        IF .er_count<=re_count THEN
           .er_count = .er_count+1
           GOTO connect 
        END
    END

    IF sock_id<0 THEN
        GOTO re_connect  ;返回并重新连接
    END
.END
.PROGRAM c3d_request(.msg_num,.arg2,.arg3)
;FUNCTION c3d_request:发送数据
start:
    CALL pack_msg2vision(.msg_num,.arg2,.arg3)  ;调用C3D消息打包程序
    .send_num = 1  ;send元素数
    .retry_times = 3
    .t = 0
    WHILE .t<.retry_times DO
        TCP_SEND send_ret,sock_id,$sendmsg[1],.send_num,timeout
        IF send_ret<0 THEN
            CALL c3d_connect 
            GOTO start
        END
        CALL c3d_receive
        IF c3d_ret==0 THEN
            GOTO exit
        END
        .t = .t+1
    END
exit:
.END    
.PROGRAM pack_msg2vision(.msg_num,.arg2,.arg3))
;FUNCTION pack_msg2vision:打包为视觉发送的信息 
    $arg[2] = $ENCODE(.arg2)
    $arg[3] = $ENCODE(.arg3)
    HERE cur_pos     ;适用HERE指令，记录当前位姿参数到cur_pos位置变量中
    DECOMPOSE pos_array[1] = cur_pos    ;解析cur_pos位置变量，将参数依次装入POS_ARRAY数组中
    $str_array[1] = $ENCODE(pos_array[1])   ;依次将解析的位置参数，从实数型转换成字符串型
    $str_array[2] = $ENCODE(pos_array[2])
    $str_array[3] = $ENCODE(pos_array[3])
    $str_array[4] = $ENCODE(pos_array[4])
    $str_array[5] = $ENCODE(pos_array[5])
    $str_array[6] = $ENCODE(pos_array[6])
    ;将位置参数字符串以及","拼接起来
    $pos_msg = $str_array[1]+","+$str_array[2]+","+$str_array[3]+","+$str_array[4]+","+$str_array[5]+","+$str_array[6]
    ;将所有信息拼接起来
    CASE .msg_num OF
    VALUE 0:   ;视觉服务控制
      .$msg2vision = "000,"+$arg[2]
    VALUE 1:   ;单步请求焊缝数据
      .$msg2vision = "001,"+$arg[2]+","+$pos_msg
    VALUE 2:   ;多步请求融合焊缝数据 
      .$msg2vision = "002,"+$arg[2]+","+$arg[3]+","+$pos_msg
    VALUE 11:  ;单步请求焊接路径
      .$msg2vision = "011,"+$arg[2]+","+$pos_msg
    VALUE 12:  ;多步请求融合焊接路径
      .$msg2vision = "012,"+$arg[2]+","+$arg[3]+","+$pos_msg
    VALUE 20:  ;向视觉发送工序编号，1-开启；0-关闭
      .$msg2vision = "020,"+$arg[2]+","+$arg[3]
    VALUE 21:  ;程序编辑功能
      .$msg2vision = "021,"+$arg[2]+","+$arg[3]+","+$pos_msg  
    VALUE 22:  ;程序编辑功能
      .$msg2vision = "022,"+$arg[2]  
    VALUE 101:  ;请求内参标定
      .$msg2vision = "101,"+$arg[2]+","+$arg[3]
    VALUE 102:  ;请求手眼标定
      .$msg2vision = "102,"+$arg[2]+","+$pos_msg +","+$arg[3]
    VALUE 200:  ;请求拍照参数组 
      .$msg2vision = "200,"+$arg[2]
    END 
    $sendmsg[1] = .$msg2vision   ;将发送得字符串放置数组中
.END
.PROGRAM c3d_receive()
.count_num = 0
arr_serial = 2
start:
    FOR .i = 1 TO 10
      $recv_buf[.i] = ""   ;将接收字符串组清空
    END
    TCP_RECV recv_ret,sock_id,$recv_buf[1],recv_num,timeout,max_length
    IF .count_num >= re_count THEN
        PRINT "TCP_RECV error in recv_data",recv_ret
        $recv_buf[1] = "000"
        GOTO exit
    END   
    IF recv_ret<0 THEN
        .count_num = .count_num+1
        PRINT "TCP_recv error id=",sock_id," error count=",.count_num
        GOTO start
    ELSE
        PRINT "TCP_RECV OK in rcv_data",recv_ret
        $recv_data = $recv_buf[1]
    END
    $recv_head = $DECODE($recv_data,",",0)    ;提取","前的数据。
    recv_head = VAL($recv_head)
    CALL c3d_proc_recv
    c3d_ret = 0
    CASE recv_head OF
    VALUE 1:
        PRINT "Write the program by yourself"
    VALUE 2:
        CALL proc_weld_path
    VALUE 900:
        PRINT "c3d_success"
    VALUE 999:
      IF $recv_data=="" THEN
         GOTO over
      END
      .$err_code = $DECODE($recv_data,",",0)    ;提取错误码
      err_code = VAL(.$err_code)
      PRINT "c3d_error",err_code
over:
      PAUSE
    END
exit:
.END
.PROGRAM proc_weld_path() 
;FUNCTION proc_weld_path:处理焊接轨迹数据
;$recv_data 接收到的数据（焊点数、间隙、）
  HERE cur_pos0
    DO
        $path_num = $DECODE($recv_data,",",0)
        path_num = VAL($path_num)
        CALL c3d_proc_recv
        FOR .i = 1 TO path_num      
            $weld_type = $DECODE($recv_data,",",0)     
            weld_type[.i] = VAL($weld_type)  
            CALL c3d_proc_recv      
            $weld_point_num = $DECODE($recv_data,",",0)  
            weld_point_num[.i] = VAL($weld_point_num)
            CALL c3d_proc_recv
            $gap = $DECODE($recv_data,",",0)
            gap[.i] = VAL($gap)
            CALL c3d_proc_recv
            FOR .j = 0 TO weld_point_num[.i]+1
                FOR .k = 1 TO 6
                    .$temp_str = $DECODE($recv_data,",",0)
                    weld_point[.k] = VAL(.$temp_str)
                    CALL c3d_proc_recv
                END 
                CASE .j OF
                VALUE 0:
                   POINT start_weld[.i] = TRANS(weld_point[1],weld_point[2],weld_point[3],weld_point[4],weld_point[5],weld_point[6])                  
                   POINT/EXT start_weld[.i] = cur_pos0
                VALUE weld_point_num[.i]+1:
                   POINT end_weld[.i] = TRANS(weld_point[1],weld_point[2],weld_point[3],weld_point[4],weld_point[5],,weld_point[6])              
                   POINT/EXT end_weld[.i] = cur_pos0
                ANY :
                   POINT weld_points[.i,.j] = TRANS(weld_point[1],weld_point[2],weld_point[3],weld_point[4],weld_point[5],,weld_point[6]) 
                   TSHIFT weld_points[.i,.j],tool_cs_x,tool_cs_y,tool_cs_z  ;工具坐标系方向进行偏移，初始值为0
                   POINT/EXT weld_points[.i,.j] = cur_pos0
                END
            END  
        END
    UNTIL $recv_data==""
exit:
.END
.PROGRAM c3d_proc_recv()
;FUNCTION c3d_proc_recv:处理接收到的数据，去除“,”,判断字符数
;小于10后，将现存的字符加上下一组接收的字符
  IF $recv_data=="" THEN
    GOTO over
  END
    $temp = $DECODE($recv_data,",",1)
    data_len = LEN($recv_data)
    TYPE data_len
    TYPE arr_serial
    IF data_len<10 THEN
      $recv_data = $recv_data + $recv_buf[arr_serial]
      arr_serial = arr_serial+1
    END
over:
.END
.PROGRAM c3d_close() 
;FUNCTION c3d_close:TCP/IP断开连接(client)
    TCP_CLOSE val_ret,sock_id 
    IF val_ret<0 THEN
       TCP_CLOSE ret1,sock_id 
         IF ret1<0 THEN
         
         END
    ELSE
    END
.END
.JOINTS
.END