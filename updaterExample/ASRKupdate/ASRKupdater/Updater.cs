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
public interface IUpdater
{
    
    int DoWork();
    
    byte[] DownloadFile(string url);
    
    ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] GetHeshes();
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="DoWork", Namespace="http://tempuri.org/")]
public partial class DoWorkRequest
{
    
    public DoWorkRequest()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="DoWorkResponse", Namespace="http://tempuri.org/")]
public partial class DoWorkResponse
{
    
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/", Order=0)]
    public int DoWorkResult;
    
    public DoWorkResponse()
    {
    }
    
    public DoWorkResponse(int DoWorkResult)
    {
        this.DoWorkResult = DoWorkResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="DownloadFile", Namespace="http://tempuri.org/")]
public partial class DownloadFileRequest
{
    
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public string url;
    
    public DownloadFileRequest()
    {
    }
    
    public DownloadFileRequest(string url)
    {
        this.url = url;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="DownloadFileResponse", Namespace="http://tempuri.org/")]
public partial class DownloadFileResponse
{
    
    [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary", IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    public byte[] DownloadFileResult;
    
    public DownloadFileResponse()
    {
    }
    
    public DownloadFileResponse(byte[] DownloadFileResult)
    {
        this.DownloadFileResult = DownloadFileResult;
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("NetCFSvcUtil", "3.5.0.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
public partial class ArrayOfKeyValueOfstringstringKeyValueOfstringstring
{
    
    private string keyField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
    public string Key
    {
        get
        {
            return this.keyField;
        }
        set
        {
            this.keyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetHeshes", Namespace="http://tempuri.org/")]
public partial class GetHeshesRequest
{
    
    public GetHeshesRequest()
    {
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.Xml.Serialization.XmlRootAttribute(ElementName="GetHeshesResponse", Namespace="http://tempuri.org/")]
public partial class GetHeshesResponse
{
    
    [System.Xml.Serialization.XmlArrayAttribute(IsNullable=true, Namespace="http://tempuri.org/", Order=0)]
    [System.Xml.Serialization.XmlArrayItemAttribute("KeyValueOfstringstring", Namespace="http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable=false)]
    public ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] GetHeshesResult;
    
    public GetHeshesResponse()
    {
    }
    
    public GetHeshesResponse(ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] GetHeshesResult)
    {
        this.GetHeshesResult = GetHeshesResult;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class UpdaterClient : Microsoft.Tools.ServiceModel.CFClientBase<IUpdater>, IUpdater
{
    
    public UpdaterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
        addProtectionRequirements(binding);
    }
    
    private DoWorkResponse DoWork(DoWorkRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IUpdater/DoWork";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IUpdater/DoWorkResponse";
        info.ResponseIsWrapped = true;
        DoWorkResponse retVal = base.Invoke<DoWorkRequest, DoWorkResponse>(info, request);
        return retVal;
    }
    
    public int DoWork()
    {
        DoWorkRequest request = new DoWorkRequest();
        DoWorkResponse response = this.DoWork(request);
        return response.DoWorkResult;
    }
    
    private DownloadFileResponse DownloadFile(DownloadFileRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IUpdater/DownloadFile";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IUpdater/DownloadFileResponse";
        info.ResponseIsWrapped = true;
        DownloadFileResponse retVal = base.Invoke<DownloadFileRequest, DownloadFileResponse>(info, request);
        return retVal;
    }
    
    public byte[] DownloadFile(string url)
    {
        DownloadFileRequest request = new DownloadFileRequest(url);
        DownloadFileResponse response = this.DownloadFile(request);
        return response.DownloadFileResult;
    }
    
    private GetHeshesResponse GetHeshes(GetHeshesRequest request)
    {
        CFInvokeInfo info = new CFInvokeInfo();
        info.Action = "http://tempuri.org/IUpdater/GetHeshes";
        info.RequestIsWrapped = true;
        info.ReplyAction = "http://tempuri.org/IUpdater/GetHeshesResponse";
        info.ResponseIsWrapped = true;
        GetHeshesResponse retVal = base.Invoke<GetHeshesRequest, GetHeshesResponse>(info, request);
        return retVal;
    }
    
    public ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] GetHeshes()
    {
        GetHeshesRequest request = new GetHeshesRequest();
        GetHeshesResponse response = this.GetHeshes(request);
        return response.GetHeshesResult;
    }
    
    private void addProtectionRequirements(System.ServiceModel.Channels.Binding binding)
    {
        if ((IsSecureMessageBinding(binding) == false))
        {
            return;
        }
        System.ServiceModel.Security.ChannelProtectionRequirements cpr = new System.ServiceModel.Security.ChannelProtectionRequirements();
        ApplyProtection("http://tempuri.org/IUpdater/DoWork", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IUpdater/DoWork", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IUpdater/DownloadFile", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IUpdater/DownloadFile", cpr.IncomingEncryptionParts, true);
        ApplyProtection("http://tempuri.org/IUpdater/GetHeshes", cpr.IncomingSignatureParts, true);
        ApplyProtection("http://tempuri.org/IUpdater/GetHeshes", cpr.IncomingEncryptionParts, true);
        if ((binding.MessageVersion.Addressing == System.ServiceModel.Channels.AddressingVersion.None))
        {
            ApplyProtection("*", cpr.OutgoingSignatureParts, true);
            ApplyProtection("*", cpr.OutgoingEncryptionParts, true);
        }
        else
        {
            ApplyProtection("http://tempuri.org/IUpdater/DoWorkResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IUpdater/DoWorkResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IUpdater/DownloadFileResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IUpdater/DownloadFileResponse", cpr.OutgoingEncryptionParts, true);
            ApplyProtection("http://tempuri.org/IUpdater/GetHeshesResponse", cpr.OutgoingSignatureParts, true);
            ApplyProtection("http://tempuri.org/IUpdater/GetHeshesResponse", cpr.OutgoingEncryptionParts, true);
        }
        this.Parameters.Add(cpr);
    }
}
