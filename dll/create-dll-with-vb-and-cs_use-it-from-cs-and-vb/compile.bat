vbc /t:module StringUtil.vb
rem
rem  Creates StringUtil.netmodule
rem

csc /t:module NumberUtil.cs
rem
rem  Creates NumberUtil.netmodule
rem

link numberutil.netmodule stringutil.netmodule /out:UtilityLib.dll /dll
rem
rem  Creates UtilityLib.dll
rem

csc example-cs.cs /r:UtilityLib.dll
rem
rem  create example-cs.exe
rem

vbc example-vb.vb /r:UtilityLib.dll
rem
rem  create example-vb.exe
rem
