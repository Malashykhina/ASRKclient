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
        //!!!!!! url в конфігах зберігати 
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
        public static createShellResponse createShell(string deliveryIndex, string index, string userid, string tareNumber, 
            string postUnitIndexTo, long routePlanId, long routePointId, string shellTypeId)
        {
            var shell = new createShellRequest();
            shell.index = index;
            shell.userid = userid;
            shell.tareNumber = tareNumber;
            shell.postUnitIndexTo = postUnitIndexTo;
            shell.routePlanId = routePlanId;
            shell.routePointId = routePointId;
            shell.shellTypeId = shellTypeId;

            //shell.deliveryIndex = deliveryIndex;
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
        public static getAllShellTypesResponse getAllShellTypes()
        {
            var req = new getAllShellTypesRequest();
            var result = proxy.getAllShellTypes(req);
            return result;
        }
        public static bool postUnitExists(string index){
           var req = new postUnitExistsRequest();
           req.index=index;
           var result= proxy.postUnitExists(req);
           return (result.status == 1);
        }

        public static getRoutePointByRouteIdResponse getRoutePointByRouteId(long routeId)
        {
            var req = new getRoutePointByRouteIdRequest();
            req.routeId = routeId;
            var result = proxy.getRoutePointByRouteId(req);
            return result;
        }
        public static getAllRoutePlansResponse getAllRoutePlans()
        {
            var req = new getAllRoutePlansRequest();
            var result = proxy.getAllRoutePlans(req);
            return result;
        }
        public static packResponse pack(string barcodeId, string index, string shellId, string userid, 
            string postUnitIndexTo, long routePlanId, long routePointId, string shellTypeId)
        {
            var req = new packRequest();
            req.barcodeId = barcodeId;
            req.index = index;
            req.shellId = shellId;
            req.userid = userid;
            req.postUnitIndexTo = postUnitIndexTo;
            req.routePlanId = routePlanId;
            req.routePointId = routePointId;
            req.shellTypeId = shellTypeId;
            var result = proxy.pack(req);
            return result;
        }
    }
}
