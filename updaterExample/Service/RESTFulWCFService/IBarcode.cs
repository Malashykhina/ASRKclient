using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using System.Xml.Linq;

namespace RESTFulWCFService
{ [ServiceContract]
    public interface IBarcode
    {
    [OperationContract]
    loginResponse login(loginRequest login);

    [OperationContract]
    getUnpackedShellsResponse getUnpackedShells(getUnpackedShellsRequest UnpackedShells);
    
    [OperationContract]
    packShellResponse packShell(packShellRequest shell);
    
    [OperationContract]
    cancelShellResponse cancelShell(cancelShellRequest cancellSR);
    //cancellShellResponse cancellShell(cancellShellRequest cancellSR);

    [OperationContract]
    createShellResponse createShell(createShellRequest createSR);
 
    [OperationContract]
    finishShellResponse finishShell(finishShellRequest fSR);

    }
}
