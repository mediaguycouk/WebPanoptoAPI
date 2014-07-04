﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebPanoptoAPI.PanoptoRemoteRecorderManagement {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationInfo", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    [System.SerializableAttribute()]
    public partial class AuthenticationInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AuthCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserKeyField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AuthCode {
            get {
                return this.AuthCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.AuthCodeField, value) != true)) {
                    this.AuthCodeField = value;
                    this.RaisePropertyChanged("AuthCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserKey {
            get {
                return this.UserKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.UserKeyField, value) != true)) {
                    this.UserKeyField = value;
                    this.RaisePropertyChanged("UserKey");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RemoteRecorder", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V42.Soa" +
        "p")]
    [System.SerializableAttribute()]
    public partial class RemoteRecorder : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorderDevice[] DevicesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExternalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MachineIPField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PreviewUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid[] ScheduledRecordingsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SettingsUrlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorderState StateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorderDevice[] Devices {
            get {
                return this.DevicesField;
            }
            set {
                if ((object.ReferenceEquals(this.DevicesField, value) != true)) {
                    this.DevicesField = value;
                    this.RaisePropertyChanged("Devices");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExternalId {
            get {
                return this.ExternalIdField;
            }
            set {
                if ((object.ReferenceEquals(this.ExternalIdField, value) != true)) {
                    this.ExternalIdField = value;
                    this.RaisePropertyChanged("ExternalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MachineIP {
            get {
                return this.MachineIPField;
            }
            set {
                if ((object.ReferenceEquals(this.MachineIPField, value) != true)) {
                    this.MachineIPField = value;
                    this.RaisePropertyChanged("MachineIP");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PreviewUrl {
            get {
                return this.PreviewUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.PreviewUrlField, value) != true)) {
                    this.PreviewUrlField = value;
                    this.RaisePropertyChanged("PreviewUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid[] ScheduledRecordings {
            get {
                return this.ScheduledRecordingsField;
            }
            set {
                if ((object.ReferenceEquals(this.ScheduledRecordingsField, value) != true)) {
                    this.ScheduledRecordingsField = value;
                    this.RaisePropertyChanged("ScheduledRecordings");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SettingsUrl {
            get {
                return this.SettingsUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.SettingsUrlField, value) != true)) {
                    this.SettingsUrlField = value;
                    this.RaisePropertyChanged("SettingsUrl");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorderState State {
            get {
                return this.StateField;
            }
            set {
                if ((this.StateField.Equals(value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RemoteRecorderDevice", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    [System.SerializableAttribute()]
    public partial class RemoteRecorderDevice : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorderDeviceType DeviceTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsCapturingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorderDeviceType DeviceType {
            get {
                return this.DeviceTypeField;
            }
            set {
                if ((this.DeviceTypeField.Equals(value) != true)) {
                    this.DeviceTypeField = value;
                    this.RaisePropertyChanged("DeviceType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsCapturing {
            get {
                return this.IsCapturingField;
            }
            set {
                if ((this.IsCapturingField.Equals(value) != true)) {
                    this.IsCapturingField = value;
                    this.RaisePropertyChanged("IsCapturing");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RemoteRecorderState", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    public enum RemoteRecorderState : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Stopped = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Previewing = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Recording = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Paused = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Faulted = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Disconnected = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Blocked = 6,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RemoteRecorderDeviceType", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    public enum RemoteRecorderDeviceType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unknown = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DV = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        HDV = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Video = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Audio = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Screen = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Slide = 6,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Pagination", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    [System.SerializableAttribute()]
    public partial class Pagination : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MaxNumberResultsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PageNumberField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MaxNumberResults {
            get {
                return this.MaxNumberResultsField;
            }
            set {
                if ((this.MaxNumberResultsField.Equals(value) != true)) {
                    this.MaxNumberResultsField = value;
                    this.RaisePropertyChanged("MaxNumberResults");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PageNumber {
            get {
                return this.PageNumberField;
            }
            set {
                if ((this.PageNumberField.Equals(value) != true)) {
                    this.PageNumberField = value;
                    this.RaisePropertyChanged("PageNumber");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RecorderSortField", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    public enum RecorderSortField : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Name = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        State = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ListRecordersResponse", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V42.Soa" +
        "p")]
    [System.SerializableAttribute()]
    public partial class ListRecordersResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorder[] PagedResultsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TotalResultCountField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorder[] PagedResults {
            get {
                return this.PagedResultsField;
            }
            set {
                if ((object.ReferenceEquals(this.PagedResultsField, value) != true)) {
                    this.PagedResultsField = value;
                    this.RaisePropertyChanged("PagedResults");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TotalResultCount {
            get {
                return this.TotalResultCountField;
            }
            set {
                if ((this.TotalResultCountField.Equals(value) != true)) {
                    this.TotalResultCountField = value;
                    this.RaisePropertyChanged("TotalResultCount");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RecorderSettings", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V40")]
    [System.SerializableAttribute()]
    public partial class RecorderSettings : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid RecorderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuppressPrimaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuppressSecondaryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid RecorderId {
            get {
                return this.RecorderIdField;
            }
            set {
                if ((this.RecorderIdField.Equals(value) != true)) {
                    this.RecorderIdField = value;
                    this.RaisePropertyChanged("RecorderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool SuppressPrimary {
            get {
                return this.SuppressPrimaryField;
            }
            set {
                if ((this.SuppressPrimaryField.Equals(value) != true)) {
                    this.SuppressPrimaryField = value;
                    this.RaisePropertyChanged("SuppressPrimary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool SuppressSecondary {
            get {
                return this.SuppressSecondaryField;
            }
            set {
                if ((this.SuppressSecondaryField.Equals(value) != true)) {
                    this.SuppressSecondaryField = value;
                    this.RaisePropertyChanged("SuppressSecondary");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ScheduledRecordingResult", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V42.Soa" +
        "p")]
    [System.SerializableAttribute()]
    public partial class ScheduledRecordingResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingInfo[] ConflictingSessionsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ConflictsExistField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid[] SessionIDsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingInfo[] ConflictingSessions {
            get {
                return this.ConflictingSessionsField;
            }
            set {
                if ((object.ReferenceEquals(this.ConflictingSessionsField, value) != true)) {
                    this.ConflictingSessionsField = value;
                    this.RaisePropertyChanged("ConflictingSessions");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ConflictsExist {
            get {
                return this.ConflictsExistField;
            }
            set {
                if ((this.ConflictsExistField.Equals(value) != true)) {
                    this.ConflictsExistField = value;
                    this.RaisePropertyChanged("ConflictsExist");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid[] SessionIDs {
            get {
                return this.SessionIDsField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionIDsField, value) != true)) {
                    this.SessionIDsField = value;
                    this.RaisePropertyChanged("SessionIDs");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ScheduledRecordingInfo", Namespace="http://schemas.datacontract.org/2004/07/Panopto.Server.Services.PublicAPI.V42.Soa" +
        "p")]
    [System.SerializableAttribute()]
    public partial class ScheduledRecordingInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid SessionIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SessionNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartTimeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndTime {
            get {
                return this.EndTimeField;
            }
            set {
                if ((this.EndTimeField.Equals(value) != true)) {
                    this.EndTimeField = value;
                    this.RaisePropertyChanged("EndTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid SessionID {
            get {
                return this.SessionIDField;
            }
            set {
                if ((this.SessionIDField.Equals(value) != true)) {
                    this.SessionIDField = value;
                    this.RaisePropertyChanged("SessionID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SessionName {
            get {
                return this.SessionNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionNameField, value) != true)) {
                    this.SessionNameField = value;
                    this.RaisePropertyChanged("SessionName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartTime {
            get {
                return this.StartTimeField;
            }
            set {
                if ((this.StartTimeField.Equals(value) != true)) {
                    this.StartTimeField = value;
                    this.RaisePropertyChanged("StartTime");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PanoptoRemoteRecorderManagement.IRemoteRecorderManagement")]
    public interface IRemoteRecorderManagement {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/GetRemoteRecordersById", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/GetRemoteRecordersByIdResponse")]
        WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorder[] GetRemoteRecordersById(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid[] remoteRecorderIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/GetRemoteRecordersByExternalId", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/GetRemoteRecordersByExternalIdRespon" +
            "se")]
        WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorder[] GetRemoteRecordersByExternalId(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, string[] externalIds);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/UpdateRemoteRecorderExternalId", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/UpdateRemoteRecorderExternalIdRespon" +
            "se")]
        void UpdateRemoteRecorderExternalId(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid remoteRecorderId, string externalId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/ListRecorders", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/ListRecordersResponse")]
        WebPanoptoAPI.PanoptoRemoteRecorderManagement.ListRecordersResponse ListRecorders(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, WebPanoptoAPI.PanoptoRemoteRecorderManagement.Pagination pagination, WebPanoptoAPI.PanoptoRemoteRecorderManagement.RecorderSortField sortBy);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/ScheduleRecording", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/ScheduleRecordingResponse")]
        WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingResult ScheduleRecording(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, string name, System.Guid folderId, bool isBroadcast, System.DateTime start, System.DateTime end, WebPanoptoAPI.PanoptoRemoteRecorderManagement.RecorderSettings[] recorderSettings);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/ScheduleRecurringRecording", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/ScheduleRecurringRecordingResponse")]
        WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingResult ScheduleRecurringRecording(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid scheduledSessionId, System.DayOfWeek[] daysOfWeek, System.DateTime end);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRemoteRecorderManagement/UpdateRecordingTime", ReplyAction="http://tempuri.org/IRemoteRecorderManagement/UpdateRecordingTimeResponse")]
        WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingResult UpdateRecordingTime(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid sessionId, System.DateTime start, System.DateTime end);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRemoteRecorderManagementChannel : WebPanoptoAPI.PanoptoRemoteRecorderManagement.IRemoteRecorderManagement, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RemoteRecorderManagementClient : System.ServiceModel.ClientBase<WebPanoptoAPI.PanoptoRemoteRecorderManagement.IRemoteRecorderManagement>, WebPanoptoAPI.PanoptoRemoteRecorderManagement.IRemoteRecorderManagement {
        
        public RemoteRecorderManagementClient() {
        }
        
        public RemoteRecorderManagementClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RemoteRecorderManagementClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoteRecorderManagementClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RemoteRecorderManagementClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorder[] GetRemoteRecordersById(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid[] remoteRecorderIds) {
            return base.Channel.GetRemoteRecordersById(auth, remoteRecorderIds);
        }
        
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.RemoteRecorder[] GetRemoteRecordersByExternalId(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, string[] externalIds) {
            return base.Channel.GetRemoteRecordersByExternalId(auth, externalIds);
        }
        
        public void UpdateRemoteRecorderExternalId(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid remoteRecorderId, string externalId) {
            base.Channel.UpdateRemoteRecorderExternalId(auth, remoteRecorderId, externalId);
        }
        
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.ListRecordersResponse ListRecorders(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, WebPanoptoAPI.PanoptoRemoteRecorderManagement.Pagination pagination, WebPanoptoAPI.PanoptoRemoteRecorderManagement.RecorderSortField sortBy) {
            return base.Channel.ListRecorders(auth, pagination, sortBy);
        }
        
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingResult ScheduleRecording(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, string name, System.Guid folderId, bool isBroadcast, System.DateTime start, System.DateTime end, WebPanoptoAPI.PanoptoRemoteRecorderManagement.RecorderSettings[] recorderSettings) {
            return base.Channel.ScheduleRecording(auth, name, folderId, isBroadcast, start, end, recorderSettings);
        }
        
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingResult ScheduleRecurringRecording(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid scheduledSessionId, System.DayOfWeek[] daysOfWeek, System.DateTime end) {
            return base.Channel.ScheduleRecurringRecording(auth, scheduledSessionId, daysOfWeek, end);
        }
        
        public WebPanoptoAPI.PanoptoRemoteRecorderManagement.ScheduledRecordingResult UpdateRecordingTime(WebPanoptoAPI.PanoptoRemoteRecorderManagement.AuthenticationInfo auth, System.Guid sessionId, System.DateTime start, System.DateTime end) {
            return base.Channel.UpdateRecordingTime(auth, sessionId, start, end);
        }
    }
}
