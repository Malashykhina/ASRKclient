https://blogs.msdn.microsoft.com/andrewarnottms/2007/09/12/calling-wcf-services-from-netcf-3-5-using-compact-wcf-and-netcfsvcutil-exe/
https://blogs.msdn.microsoft.com/robcamer/2009/12/21/wcf-in-net-compact-framework-3-5/
https://stackoverflow.com/questions/26704913/referencing-newer-wcf-project-with-older-web-reference

Win-> cmd
cd D:\WinMobProgects\INSTALL
D:
NetCFSvcUtil.exe /out:AsrkService http://10.255.102.149:8080/motorolla/login.wsdl

В результаті буде згенеровано 2 файли:
AsrkService.cs і
CFClientBase.cs