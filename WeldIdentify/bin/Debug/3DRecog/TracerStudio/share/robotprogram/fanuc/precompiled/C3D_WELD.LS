/PROG  C3D_WELD
/ATTR
OWNER		= MNEDITOR;
COMMENT		= "";
PROG_SIZE	= 1287;
CREATE		= DATE 21-08-12  TIME 19:34:24;
MODIFIED	= DATE 21-12-10  TIME 09:18:08;
FILE_NAME	= C3D_WELD;
VERSION		= 2;
LINE_COUNT	= 52;
MEMORY_SIZE	= 1711;
PROTECT		= READ_WRITE;
TCD:  STACK_SIZE	= 0,
      TASK_PRIORITY	= 50,
      TIME_SLICE	= 0,
      BUSY_LAMP_OFF	= 0,
      ABORT_REQUEST	= 0,
      PAUSE_REQUEST	= 0;
DEFAULT_GROUP	= 1,*,*,*,*;
CONTROL_CODE	= 00000000 00000000;
/APPL
  ARC Welding Equipment : 1,*,*,*,*;

MPAS ;
MPAS_NUM_PASSES        : 0;
MPAS_LAST_PASS         : 0;
MPAS_CURRENT_PASS      : 0;
MPAS_STATUS_PASS       : 0;
/MN
   1:  IF (R[11]<>0) THEN ;
   2:  PAUSE ;
   3:  ENDIF ;
   4:  R[49]=1    ;
   5:  PR[50]=PR[R[49]]    ;
   6:  PR[50,3]=R[50]    ;
   7:J PR[50] 30% FINE    ;
   8:  FOR R[41]=1 TO R[13] ;
   9:  R[42]=R[41]+13    ;
  10:  R[43]=R[41]+25    ;
  11:  R[44]=R[41]+35    ;
  12:L PR[R[49]] 100mm/sec FINE    ;
  13:  R[49]=R[49]+1    ;
  14:  IF (R[R[43]]>5) THEN ;
  15:  R[49]=R[49]+R[R[42]]    ;
  16:  JMP LBL[1] ;
  17:  ENDIF ;
  18:L PR[R[49]] 100mm/sec FINE    ;
  19:  R[49]=R[49]+1    ;
  20:  --eg: Flat weld(Ping) ;
  21:  IF (R[R[44]]=0) THEN ;
  22:  Weld Start[1,1] ;
  23:  R[46]=20    ;
  24:  ENDIF ;
  25:  --eg: Stand weld(Li) ;
  26:  IF (R[R[44]]=1) THEN ;
  27:  Weld Start[1,2] ;
  28:  R[46]=10    ;
  29:  ENDIF ;
  30:  --eg: gap&weave ;
  31:  IF (R[R[43]]>2 AND R[R[43]]<5) THEN ;
  32:  Weave Sine[1] ;
  33:  ENDIF ;
  34:  IF (R[R[43]]<2) THEN ;
  35:  Weave Sine[2] ;
  36:  ENDIF ;
  37:  --eg: START weld ;
  38:  FOR R[45]=2 TO R[R[42]] ;
  39:L PR[R[49]] R[46]mm/sec FINE    ;
  40:  R[49]=R[49]+1    ;
  41:  ENDFOR ;
  42:  Weave End[1] ;
  43:  Weld End[1,1] ;
  44:  LBL[1] ;
  45:L PR[R[49]] 100mm/sec FINE    ;
  46:  WAIT 100.00(sec) ;
  47:  R[49]=R[49]+1    ;
  48:  ENDFOR ;
  49:  R[49]=R[49]-1    ;
  50:  PR[50]=PR[R[49]]    ;
  51:  PR[50,3]=R[50]    ;
  52:L PR[50] 100mm/sec FINE    ;
/POS
/END
