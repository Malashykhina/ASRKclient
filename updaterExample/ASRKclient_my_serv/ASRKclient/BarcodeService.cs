﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:2.0.50727.5472
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IBarcode
{
    
    cancelShellResponse cancelShell(cancelShellRequest cancellSR);
    
    createShellResponse createShell(createShellRequest createSR);
    
    finishShellResponse finishShell(finishShellRequest fSR);
    
    getUnpackedShellsResponse getUnpackedShells(getUnpackedShellsRequest UnpackedShells);
    
    loginResponse login(loginRequest login1);
    
    packShellResponse packShell(packShellRequest shell);
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class cancelShellRequest
{
    
    private string indexField;
    
    private string shellIdField;
    
    private string useridField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string shellId
    {
        get
        {
            return this.shellIdField;
        }
        set
        {
            this.shellIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
    public string userid
    {
        get
        {
            return this.useridField;
        }
        set
        {
            this.useridField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class packShellResponse
{
    
    private string packField;
    
    private string packUserField;
    
    private string statusField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string pack
    {
        get
        {
            return this.packField;
        }
        set
        {
            this.packField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string packUser
    {
        get
        {
            return this.packUserField;
        }
        set
        {
            this.packUserField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class packShellRequest
{
    
    private string barcodeIdField;
    
    private string indexField;
    
    private string shellIdField;
    
    private string useridField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string barcodeId
    {
        get
        {
            return this.barcodeIdField;
        }
        set
        {
            this.barcodeIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
    public string shellId
    {
        get
        {
            return this.shellIdField;
        }
        set
        {
            this.shellIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
    public string userid
    {
        get
        {
            return this.useridField;
        }
        set
        {
            this.useridField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class loginResponse
{
    
    private string registerIdField;
    
    private string userNameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string registerId
    {
        get
        {
            return this.registerIdField;
        }
        set
        {
            this.registerIdField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string userName
    {
        get
        {
            return this.userNameField;
        }
        set
        {
            this.userNameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class loginRequest
{
    
    private string indexField;
    
    private string loginField;
    
    private string passwordField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string login
    {
        get
        {
            return this.loginField;
        }
        set
        {
            this.loginField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
    public string password
    {
        get
        {
            return this.passwordField;
        }
        set
        {
            this.passwordField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class getUnpackedShellsResponse
{
    
    private string[] shellField;
    
    private string statusField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    public string[] shell
    {
        get
        {
            return this.shellField;
        }
        set
        {
            this.shellField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class getUnpackedShellsRequest
{
    
    private string indexField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class finishShellResponse
{
    
    private string inShellField;
    
    private string statusField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string inShell
    {
        get
        {
            return this.inShellField;
        }
        set
        {
            this.inShellField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class finishShellRequest
{
    
    private string indexField;
    
    private string shellField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string shell
    {
        get
        {
            return this.shellField;
        }
        set
        {
            this.shellField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class createShellResponse
{
    
    private string barcodeShellField;
    
    private string statusField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string barcodeShell
    {
        get
        {
            return this.barcodeShellField;
        }
        set
        {
            this.barcodeShellField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class createShellRequest
{
    
    private string indexField;
    
    private string useridField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string index
    {
        get
        {
            return this.indexField;
        }
        set
        {
            this.indexField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string userid
    {
        get
        {
            return this.useridField;
        }
        set
        {
            this.useridField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RESTFulWCFService")]
public partial class cancelShellResponse
{
    
    private string cancelField;
    
    private string statusField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string cancel
    {
        get
        {
            return this.cancelField;
        }
        set
        {
            this.cancelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string status
    {
        get
        {
            return this.statusField;
        }
        set
        {
            this.statusField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="cancelShell", Namespace="http://tempuri.org/")]
public partial class cancelShellRequest1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public cancelShellRequest cancellSR;
    
    public cancelShellRequest1()
    {
    }
    
    public cancelShellRequest1(cancelShellRequest cancellSR)
    {
        this.cancellSR = cancellSR;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="cancelShellResponse", Namespace="http://tempuri.org/")]
public partial class cancelShellResponse1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public cancelShellResponse cancelShellResult;
    
    public cancelShellResponse1()
    {
    }
    
    public cancelShellResponse1(cancelShellResponse cancelShellResult)
    {
        this.cancelShellResult = cancelShellResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="createShell", Namespace="http://tempuri.org/")]
public partial class createShellRequest1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public createShellRequest createSR;
    
    public createShellRequest1()
    {
    }
    
    public createShellRequest1(createShellRequest createSR)
    {
        this.createSR = createSR;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="createShellResponse", Namespace="http://tempuri.org/")]
public partial class createShellResponse1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public createShellResponse createShellResult;
    
    public createShellResponse1()
    {
    }
    
    public createShellResponse1(createShellResponse createShellResult)
    {
        this.createShellResult = createShellResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="finishShell", Namespace="http://tempuri.org/")]
public partial class finishShellRequest1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public finishShellRequest fSR;
    
    public finishShellRequest1()
    {
    }
    
    public finishShellRequest1(finishShellRequest fSR)
    {
        this.fSR = fSR;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="finishShellResponse", Namespace="http://tempuri.org/")]
public partial class finishShellResponse1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public finishShellResponse finishShellResult;
    
    public finishShellResponse1()
    {
    }
    
    public finishShellResponse1(finishShellResponse finishShellResult)
    {
        this.finishShellResult = finishShellResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="getUnpackedShells", Namespace="http://tempuri.org/")]
public partial class getUnpackedShellsRequest1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public getUnpackedShellsRequest UnpackedShells;
    
    public getUnpackedShellsRequest1()
    {
    }
    
    public getUnpackedShellsRequest1(getUnpackedShellsRequest UnpackedShells)
    {
        this.UnpackedShells = UnpackedShells;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="getUnpackedShellsResponse", Namespace="http://tempuri.org/")]
public partial class getUnpackedShellsResponse1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public getUnpackedShellsResponse getUnpackedShellsResult;
    
    public getUnpackedShellsResponse1()
    {
    }
    
    public getUnpackedShellsResponse1(getUnpackedShellsResponse getUnpackedShellsResult)
    {
        this.getUnpackedShellsResult = getUnpackedShellsResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="login", Namespace="http://tempuri.org/")]
public partial class loginRequest1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public loginRequest login;
    
    public loginRequest1()
    {
    }
    
    public loginRequest1(loginRequest login)
    {
        this.login = login;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="loginResponse", Namespace="http://tempuri.org/")]
public partial class loginResponse1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public loginResponse loginResult;
    
    public loginResponse1()
    {
    }
    
    public loginResponse1(loginResponse loginResult)
    {
        this.loginResult = loginResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="packShell", Namespace="http://tempuri.org/")]
public partial class packShellRequest1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public packShellRequest shell;
    
    public packShellRequest1()
    {
    }
    
    public packShellRequest1(packShellRequest shell)
    {
        this.shell = shell;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="packShellResponse", Namespace="http://tempuri.org/")]
public partial class packShellResponse1
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public packShellResponse packShellResult;
    
    public packShellResponse1()
    {
    }
    
    public packShellResponse1(packShellResponse packShellResult)
    {
        this.packShellResult = packShellResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class BarcodeClient : Microsoft.Tools.ServiceModel.CFClientBase<IBarcode>, IBarcode
{
    
    public static System.ServiceModel.EndpointAddress EndpointAddress = new System.ServiceModel.EndpointAddress("http://10.49.170.56:61090/Barcode.svc");
    
    public BarcodeClient() : 
            this(CreateDefaultBinding(), EndpointAddress)
    {
    }
    
    public BarcodeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
        addProtectionRequirements(binding);
    }
    
    private cancelShellResponse1 cancelShell(cancelShellRequest1 request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IBarcode/cancelShell";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IBarcode/cancelShellResponse";
        info.ResponseIsWrapped = true;
        cancelShellResponse1 retVal = base.Invoke<cancelShellRequest1, cancelShellResponse1>(info, request);
        return retVal;
    }
    
    public cancelShellResponse cancelShell(cancelShellRequest cancellSR)
    {
        cancelShellRequest1 request = new cancelShellRequest1(cancellSR);
        cancelShellResponse1 response = this.cancelShell(request);
        return response.cancelShellResult;
    }
    
    private createShellResponse1 createShell(createShellRequest1 request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IBarcode/createShell";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IBarcode/createShellResponse";
        info.ResponseIsWrapped = true;
        createShellResponse1 retVal = base.Invoke<createShellRequest1, createShellResponse1>(info, request);
        return retVal;
    }
    
    public createShellResponse createShell(createShellRequest createSR)
    {
        createShellRequest1 request = new createShellRequest1(createSR);
        createShellResponse1 response = this.createShell(request);
        return response.createShellResult;
    }
    
    private finishShellResponse1 finishShell(finishShellRequest1 request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IBarcode/finishShell";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IBarcode/finishShellResponse";
        info.ResponseIsWrapped = true;
        finishShellResponse1 retVal = base.Invoke<finishShellRequest1, finishShellResponse1>(info, request);
        return retVal;
    }
    
    public finishShellResponse finishShell(finishShellRequest fSR)
    {
        finishShellRequest1 request = new finishShellRequest1(fSR);
        finishShellResponse1 response = this.finishShell(request);
        return response.finishShellResult;
    }
    
    private getUnpackedShellsResponse1 getUnpackedShells(getUnpackedShellsRequest1 request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IBarcode/getUnpackedShells";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IBarcode/getUnpackedShellsResponse";
        info.ResponseIsWrapped = true;
        getUnpackedShellsResponse1 retVal = base.Invoke<getUnpackedShellsRequest1, getUnpackedShellsResponse1>(info, request);
        return retVal;
    }
    
    public getUnpackedShellsResponse getUnpackedShells(getUnpackedShellsRequest UnpackedShells)
    {
        getUnpackedShellsRequest1 request = new getUnpackedShellsRequest1(UnpackedShells);
        getUnpackedShellsResponse1 response = this.getUnpackedShells(request);
        return response.getUnpackedShellsResult;
    }
    
    private loginResponse1 login(loginRequest1 request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IBarcode/login";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IBarcode/loginResponse";
        info.ResponseIsWrapped = true;
        loginResponse1 retVal = base.Invoke<loginRequest1, loginResponse1>(info, request);
        return retVal;
    }
    
    public loginResponse login(loginRequest login1)
    {
        loginRequest1 request = new loginRequest1(login1);
        loginResponse1 response = this.login(request);
        return response.loginResult;
    }
    
    private packShellResponse1 packShell(packShellRequest1 request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IBarcode/packShell";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IBarcode/packShellResponse";
        info.ResponseIsWrapped = true;
        packShellResponse1 retVal = base.Invoke<packShellRequest1, packShellResponse1>(info, request);
        return retVal;
    }
    
    public packShellResponse packShell(packShellRequest shell)
    {
        packShellRequest1 request = new packShellRequest1(shell);
        packShellResponse1 response = this.packShell(request);
        return response.packShellResult;
    }
    
    public static System.ServiceModel.Channels.Binding CreateDefaultBinding()
    {
        System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
        binding.Elements.Add(new System.ServiceModel.Channels.TextMessageEncodingBindingElement(System.ServiceModel.Channels.MessageVersion.Soap11, System.Text.Encoding.UTF8));
        binding.Elements.Add(new System.ServiceModel.Channels.HttpTransportBindingElement());
        return binding;
    }
    
    private void addProtectionRequirements(System.ServiceModel.Channels.Binding binding)
    {
        if ((IsSecureMessageBinding(binding) == false))
        {
            return;
        }
        System.ServiceModel.Security.ChannelProtectionRequirements cpr = new System.ServiceModel.Security.ChannelProtectionRequirements();
        ApplyProtection("http://tempuri.org/IBarcode/cancelShell", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/cancelShell", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/createShell", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/createShell", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/finishShell", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/finishShell", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/getUnpackedShells", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/getUnpackedShells", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/login", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/login", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/packShell", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IBarcode/packShell", cpr.IncomingEncryptionParts, true);
        if ((binding.MessageVersion.Addressing == System.ServiceModel.Channels.AddressingVersion.None))
        {
            ApplyProtection("*", cpr.OutgoingSignatureParts, true);
            ApplyProtection("*", cpr.OutgoingEncryptionParts, true);
        }
        else
        {
            ApplyProtection("http://tempuri.org/IBarcode/cancelShellResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/cancelShellResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/createShellResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/createShellResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/finishShellResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/finishShellResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/getUnpackedShellsResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/getUnpackedShellsResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/loginResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/loginResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/packShellResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IBarcode/packShellResponse", cpr.OutgoingEncryptionParts, true);
        }
        this.Parameters.Add(cpr);
    }
}
