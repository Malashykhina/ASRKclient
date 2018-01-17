using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace ASRKclient
{
    public class ServiceProxy
    {
        private static LoginPortClient proxy;
        //!!!!!! url дозволити зміни 
        private static string serviceUrl="http://10.255.102.149:8080/motorolla/login.wsdl";
        static ServiceProxy()//private 
        {
            EndpointAddress endpoint = new EndpointAddress(serviceUrl);
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = Int32.MaxValue;
            proxy = new LoginPortClient(binding, endpoint);           
        }
        public static loginResponse login( string index, string login, string password)
        {
            var user = new loginRequest();
            user.index = index;
            user.login = login;
            user.password = password;
            var result = proxy.login(user);
            return result;
        }
        public static packShellResponse packShell(string barcodeId, string index, string shellId, string userid)
        {
            var pack = new packShellRequest();
            pack.barcodeId = barcodeId;
            pack.index = index;
            pack.shellId = shellId;
            pack.userid = userid;
            var result = proxy.packShell(pack);
            return result;
        }

        public static getUnpackedShellsResponse getUnpackedShells(string index)
        {
            var shells = new getUnpackedShellsRequest();
            shells.index = index;
            var result = proxy.getUnpackedShells(shells);
            return result;
        }
        public static createShellResponse createShell(string deliveryIndex, string index, string userid, string tareNumber)
        {
            var shell = new createShellRequest();
            shell.index = index;
            shell.userid = userid;
            shell.tareNumber = tareNumber;
            shell.deliveryIndex = deliveryIndex;
            var result = proxy.createShell(shell);
            return result;
        }
        public static cancelShellResponse cancelShell(string index, string userid, string shellId)
        {
            var shell = new cancelShellRequest();
            shell.index = index;
            shell.userid = userid;
            shell.shellId = shellId;
            var result = proxy.cancelShell(shell);
            return result;
        }
        public static scannedPackage[] finishSession(string index, string operation, string status, string userid)//finishSessionResponse
        {
            var shell = new finishSessionRequest();
            shell.index = index;
            shell.operation = operation;
            shell.status = status;
            shell.user = userid;
            var result = proxy.finishSession(shell);
            return result;
        }
        public static finishShellResponse finishShell(string index, string shell)
        {
            var req = new finishShellRequest();
            req.index = index;
            req.shell = shell;
            var result = proxy.finishShell(req);
            return result;
        }
    }
}
