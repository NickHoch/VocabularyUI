﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.ServiceVocabulary {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CredentialDC", Namespace="http://schemas.datacontract.org/2004/07/WCF.DCs")]
    [System.SerializableAttribute()]
    public partial class CredentialDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.DictionaryDC[] DictionariesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
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
        public DAL.ServiceVocabulary.DictionaryDC[] Dictionaries {
            get {
                return this.DictionariesField;
            }
            set {
                if ((object.ReferenceEquals(this.DictionariesField, value) != true)) {
                    this.DictionariesField = value;
                    this.RaisePropertyChanged("Dictionaries");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DictionaryDC", Namespace="http://schemas.datacontract.org/2004/07/WCF.DCs")]
    [System.SerializableAttribute()]
    public partial class DictionaryDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.CredentialDC CredentialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.WordDC[] WordsField;
        
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
        public DAL.ServiceVocabulary.CredentialDC Credential {
            get {
                return this.CredentialField;
            }
            set {
                if ((object.ReferenceEquals(this.CredentialField, value) != true)) {
                    this.CredentialField = value;
                    this.RaisePropertyChanged("Credential");
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
        public DAL.ServiceVocabulary.WordDC[] Words {
            get {
                return this.WordsField;
            }
            set {
                if ((object.ReferenceEquals(this.WordsField, value) != true)) {
                    this.WordsField = value;
                    this.RaisePropertyChanged("Words");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="WordDC", Namespace="http://schemas.datacontract.org/2004/07/WCF.DCs")]
    [System.SerializableAttribute()]
    public partial class WordDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.DictionaryDC DictionaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ImageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool[] IsLearnedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsLearnedWordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] SoundField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TranscriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TranslationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WordEngField;
        
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
        public DAL.ServiceVocabulary.DictionaryDC Dictionary {
            get {
                return this.DictionaryField;
            }
            set {
                if ((object.ReferenceEquals(this.DictionaryField, value) != true)) {
                    this.DictionaryField = value;
                    this.RaisePropertyChanged("Dictionary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Image {
            get {
                return this.ImageField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageField, value) != true)) {
                    this.ImageField = value;
                    this.RaisePropertyChanged("Image");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool[] IsLearned {
            get {
                return this.IsLearnedField;
            }
            set {
                if ((object.ReferenceEquals(this.IsLearnedField, value) != true)) {
                    this.IsLearnedField = value;
                    this.RaisePropertyChanged("IsLearned");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsLearnedWord {
            get {
                return this.IsLearnedWordField;
            }
            set {
                if ((this.IsLearnedWordField.Equals(value) != true)) {
                    this.IsLearnedWordField = value;
                    this.RaisePropertyChanged("IsLearnedWord");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte[] Sound {
            get {
                return this.SoundField;
            }
            set {
                if ((object.ReferenceEquals(this.SoundField, value) != true)) {
                    this.SoundField = value;
                    this.RaisePropertyChanged("Sound");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Transcription {
            get {
                return this.TranscriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.TranscriptionField, value) != true)) {
                    this.TranscriptionField = value;
                    this.RaisePropertyChanged("Transcription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Translation {
            get {
                return this.TranslationField;
            }
            set {
                if ((object.ReferenceEquals(this.TranslationField, value) != true)) {
                    this.TranslationField = value;
                    this.RaisePropertyChanged("Translation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string WordEng {
            get {
                return this.WordEngField;
            }
            set {
                if ((object.ReferenceEquals(this.WordEngField, value) != true)) {
                    this.WordEngField = value;
                    this.RaisePropertyChanged("WordEng");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceVocabulary.IVocabulary")]
    public interface IVocabulary {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetUserIdByCredential", ReplyAction="http://tempuri.org/IVocabulary/GetUserIdByCredentialResponse")]
        System.Nullable<int> GetUserIdByCredential(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetUserIdByCredential", ReplyAction="http://tempuri.org/IVocabulary/GetUserIdByCredentialResponse")]
        System.Threading.Tasks.Task<System.Nullable<int>> GetUserIdByCredentialAsync(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/IsEmailAddressFree", ReplyAction="http://tempuri.org/IVocabulary/IsEmailAddressFreeResponse")]
        bool IsEmailAddressFree(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/IsEmailAddressFree", ReplyAction="http://tempuri.org/IVocabulary/IsEmailAddressFreeResponse")]
        System.Threading.Tasks.Task<bool> IsEmailAddressFreeAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddUser", ReplyAction="http://tempuri.org/IVocabulary/AddUserResponse")]
        bool AddUser(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddUser", ReplyAction="http://tempuri.org/IVocabulary/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddDictionary", ReplyAction="http://tempuri.org/IVocabulary/AddDictionaryResponse")]
        bool AddDictionary(DAL.ServiceVocabulary.DictionaryDC dictionaryDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddDictionary", ReplyAction="http://tempuri.org/IVocabulary/AddDictionaryResponse")]
        System.Threading.Tasks.Task<bool> AddDictionaryAsync(DAL.ServiceVocabulary.DictionaryDC dictionaryDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetDictionariesNameByUserId", ReplyAction="http://tempuri.org/IVocabulary/GetDictionariesNameByUserIdResponse")]
        string[] GetDictionariesNameByUserId(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetDictionariesNameByUserId", ReplyAction="http://tempuri.org/IVocabulary/GetDictionariesNameByUserIdResponse")]
        System.Threading.Tasks.Task<string[]> GetDictionariesNameByUserIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetNotLearnedWords", ReplyAction="http://tempuri.org/IVocabulary/GetNotLearnedWordsResponse")]
        DAL.ServiceVocabulary.WordDC[] GetNotLearnedWords(int quantityWords, string dictionaryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetNotLearnedWords", ReplyAction="http://tempuri.org/IVocabulary/GetNotLearnedWordsResponse")]
        System.Threading.Tasks.Task<DAL.ServiceVocabulary.WordDC[]> GetNotLearnedWordsAsync(int quantityWords, string dictionaryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearned", ReplyAction="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearnedResponse")]
        void SetToWordsStatusAsLearned(int quantityWords, string dictionaryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearned", ReplyAction="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearnedResponse")]
        System.Threading.Tasks.Task SetToWordsStatusAsLearnedAsync(int quantityWords, string dictionaryName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVocabularyChannel : DAL.ServiceVocabulary.IVocabulary, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VocabularyClient : System.ServiceModel.ClientBase<DAL.ServiceVocabulary.IVocabulary>, DAL.ServiceVocabulary.IVocabulary {
        
        public VocabularyClient() {
        }
        
        public VocabularyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VocabularyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VocabularyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VocabularyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Nullable<int> GetUserIdByCredential(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.GetUserIdByCredential(credentialDC);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<int>> GetUserIdByCredentialAsync(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.GetUserIdByCredentialAsync(credentialDC);
        }
        
        public bool IsEmailAddressFree(string email) {
            return base.Channel.IsEmailAddressFree(email);
        }
        
        public System.Threading.Tasks.Task<bool> IsEmailAddressFreeAsync(string email) {
            return base.Channel.IsEmailAddressFreeAsync(email);
        }
        
        public bool AddUser(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.AddUser(credentialDC);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.AddUserAsync(credentialDC);
        }
        
        public bool AddDictionary(DAL.ServiceVocabulary.DictionaryDC dictionaryDC) {
            return base.Channel.AddDictionary(dictionaryDC);
        }
        
        public System.Threading.Tasks.Task<bool> AddDictionaryAsync(DAL.ServiceVocabulary.DictionaryDC dictionaryDC) {
            return base.Channel.AddDictionaryAsync(dictionaryDC);
        }
        
        public string[] GetDictionariesNameByUserId(int userId) {
            return base.Channel.GetDictionariesNameByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<string[]> GetDictionariesNameByUserIdAsync(int userId) {
            return base.Channel.GetDictionariesNameByUserIdAsync(userId);
        }
        
        public DAL.ServiceVocabulary.WordDC[] GetNotLearnedWords(int quantityWords, string dictionaryName) {
            return base.Channel.GetNotLearnedWords(quantityWords, dictionaryName);
        }
        
        public System.Threading.Tasks.Task<DAL.ServiceVocabulary.WordDC[]> GetNotLearnedWordsAsync(int quantityWords, string dictionaryName) {
            return base.Channel.GetNotLearnedWordsAsync(quantityWords, dictionaryName);
        }
        
        public void SetToWordsStatusAsLearned(int quantityWords, string dictionaryName) {
            base.Channel.SetToWordsStatusAsLearned(quantityWords, dictionaryName);
        }
        
        public System.Threading.Tasks.Task SetToWordsStatusAsLearnedAsync(int quantityWords, string dictionaryName) {
            return base.Channel.SetToWordsStatusAsLearnedAsync(quantityWords, dictionaryName);
        }
    }
}
