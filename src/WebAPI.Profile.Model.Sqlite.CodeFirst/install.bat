sc create Count4U.Service.WebAPI.Model binPath= %~dp0Count4U.Service.WebAPI.exe
sc failure Count4U.Service.WebAPI.Model actions= restart/60000/restart/60000/""/60000 reset= 86400
sc start Count4U.Service.WebAPI.Model
sc config Count4U.Service.WebAPI.Model start= auto
pause