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
        private DAL.ServiceVocabulary.DictionaryExtnDC[] DictionariesField;
        
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
        public DAL.ServiceVocabulary.DictionaryExtnDC[] Dictionaries {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="DictionaryExtnDC", Namespace="http://schemas.datacontract.org/2004/07/WCF.DCs")]
    [System.SerializableAttribute()]
    public partial class DictionaryExtnDC : DAL.ServiceVocabulary.DictionaryDC {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.CredentialDC CredentialField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.WordDC[] WordsField;
        
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
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DictionaryDC", Namespace="http://schemas.datacontract.org/2004/07/WCF.DCs")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DAL.ServiceVocabulary.DictionaryExtnDC))]
    public partial class DictionaryDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        public int Id {
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WordDC", Namespace="http://schemas.datacontract.org/2004/07/WCF.DCs")]
    [System.SerializableAttribute()]
    public partial class WordDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private DAL.ServiceVocabulary.DictionaryExtnDC DictionaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        public DAL.ServiceVocabulary.DictionaryExtnDC Dictionary {
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
        public int Id {
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/IsDictionaryNameExists", ReplyAction="http://tempuri.org/IVocabulary/IsDictionaryNameExistsResponse")]
        bool IsDictionaryNameExists(string email, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/IsDictionaryNameExists", ReplyAction="http://tempuri.org/IVocabulary/IsDictionaryNameExistsResponse")]
        System.Threading.Tasks.Task<bool> IsDictionaryNameExistsAsync(string email, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/IsEmailAddressExists", ReplyAction="http://tempuri.org/IVocabulary/IsEmailAddressExistsResponse")]
        bool IsEmailAddressExists(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/IsEmailAddressExists", ReplyAction="http://tempuri.org/IVocabulary/IsEmailAddressExistsResponse")]
        System.Threading.Tasks.Task<bool> IsEmailAddressExistsAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetUserIdByCredential", ReplyAction="http://tempuri.org/IVocabulary/GetUserIdByCredentialResponse")]
        System.Nullable<int> GetUserIdByCredential(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetUserIdByCredential", ReplyAction="http://tempuri.org/IVocabulary/GetUserIdByCredentialResponse")]
        System.Threading.Tasks.Task<System.Nullable<int>> GetUserIdByCredentialAsync(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddUser", ReplyAction="http://tempuri.org/IVocabulary/AddUserResponse")]
        bool AddUser(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddUser", ReplyAction="http://tempuri.org/IVocabulary/AddUserResponse")]
        System.Threading.Tasks.Task<bool> AddUserAsync(DAL.ServiceVocabulary.CredentialDC credentialDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddWord", ReplyAction="http://tempuri.org/IVocabulary/AddWordResponse")]
        bool AddWord(DAL.ServiceVocabulary.WordDC wordDC, int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddWord", ReplyAction="http://tempuri.org/IVocabulary/AddWordResponse")]
        System.Threading.Tasks.Task<bool> AddWordAsync(DAL.ServiceVocabulary.WordDC wordDC, int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/DeleteWord", ReplyAction="http://tempuri.org/IVocabulary/DeleteWordResponse")]
        bool DeleteWord(int wordId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/DeleteWord", ReplyAction="http://tempuri.org/IVocabulary/DeleteWordResponse")]
        System.Threading.Tasks.Task<bool> DeleteWordAsync(int wordId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/UpdateWord", ReplyAction="http://tempuri.org/IVocabulary/UpdateWordResponse")]
        void UpdateWord(DAL.ServiceVocabulary.WordDC wordDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/UpdateWord", ReplyAction="http://tempuri.org/IVocabulary/UpdateWordResponse")]
        System.Threading.Tasks.Task UpdateWordAsync(DAL.ServiceVocabulary.WordDC wordDC);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetWords", ReplyAction="http://tempuri.org/IVocabulary/GetWordsResponse")]
        DAL.ServiceVocabulary.WordDC[] GetWords(int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetWords", ReplyAction="http://tempuri.org/IVocabulary/GetWordsResponse")]
        System.Threading.Tasks.Task<DAL.ServiceVocabulary.WordDC[]> GetWordsAsync(int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetNotLearnedWords", ReplyAction="http://tempuri.org/IVocabulary/GetNotLearnedWordsResponse")]
        DAL.ServiceVocabulary.WordDC[] GetNotLearnedWords(int quantityWords, int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetNotLearnedWords", ReplyAction="http://tempuri.org/IVocabulary/GetNotLearnedWordsResponse")]
        System.Threading.Tasks.Task<DAL.ServiceVocabulary.WordDC[]> GetNotLearnedWordsAsync(int quantityWords, int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearned", ReplyAction="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearnedResponse")]
        void SetToWordsStatusAsLearned(int quantityWords, int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearned", ReplyAction="http://tempuri.org/IVocabulary/SetToWordsStatusAsLearnedResponse")]
        System.Threading.Tasks.Task SetToWordsStatusAsLearnedAsync(int quantityWords, int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/SetToWordsStatusAsUnlearned", ReplyAction="http://tempuri.org/IVocabulary/SetToWordsStatusAsUnlearnedResponse")]
        void SetToWordsStatusAsUnlearned(int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/SetToWordsStatusAsUnlearned", ReplyAction="http://tempuri.org/IVocabulary/SetToWordsStatusAsUnlearnedResponse")]
        System.Threading.Tasks.Task SetToWordsStatusAsUnlearnedAsync(int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/ChangeImage", ReplyAction="http://tempuri.org/IVocabulary/ChangeImageResponse")]
        void ChangeImage(int wordId, byte[] newImage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/ChangeImage", ReplyAction="http://tempuri.org/IVocabulary/ChangeImageResponse")]
        System.Threading.Tasks.Task ChangeImageAsync(int wordId, byte[] newImage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/ChangeSound", ReplyAction="http://tempuri.org/IVocabulary/ChangeSoundResponse")]
        void ChangeSound(int wordId, byte[] newSound);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/ChangeSound", ReplyAction="http://tempuri.org/IVocabulary/ChangeSoundResponse")]
        System.Threading.Tasks.Task ChangeSoundAsync(int wordId, byte[] newSound);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddDictionary", ReplyAction="http://tempuri.org/IVocabulary/AddDictionaryResponse")]
        bool AddDictionary(DAL.ServiceVocabulary.DictionaryExtnDC dictionaryDC, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/AddDictionary", ReplyAction="http://tempuri.org/IVocabulary/AddDictionaryResponse")]
        System.Threading.Tasks.Task<bool> AddDictionaryAsync(DAL.ServiceVocabulary.DictionaryExtnDC dictionaryDC, int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/UpdateDictionary", ReplyAction="http://tempuri.org/IVocabulary/UpdateDictionaryResponse")]
        void UpdateDictionary(int dictionaryId, string newDictionaryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/UpdateDictionary", ReplyAction="http://tempuri.org/IVocabulary/UpdateDictionaryResponse")]
        System.Threading.Tasks.Task UpdateDictionaryAsync(int dictionaryId, string newDictionaryName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/DeleteDictionary", ReplyAction="http://tempuri.org/IVocabulary/DeleteDictionaryResponse")]
        bool DeleteDictionary(int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/DeleteDictionary", ReplyAction="http://tempuri.org/IVocabulary/DeleteDictionaryResponse")]
        System.Threading.Tasks.Task<bool> DeleteDictionaryAsync(int dictionaryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetDictionariesBaseInfo", ReplyAction="http://tempuri.org/IVocabulary/GetDictionariesBaseInfoResponse")]
        DAL.ServiceVocabulary.DictionaryDC[] GetDictionariesBaseInfo(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVocabulary/GetDictionariesBaseInfo", ReplyAction="http://tempuri.org/IVocabulary/GetDictionariesBaseInfoResponse")]
        System.Threading.Tasks.Task<DAL.ServiceVocabulary.DictionaryDC[]> GetDictionariesBaseInfoAsync(int userId);
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
        
        public bool IsDictionaryNameExists(string email, int userId) {
            return base.Channel.IsDictionaryNameExists(email, userId);
        }
        
        public System.Threading.Tasks.Task<bool> IsDictionaryNameExistsAsync(string email, int userId) {
            return base.Channel.IsDictionaryNameExistsAsync(email, userId);
        }
        
        public bool IsEmailAddressExists(string email) {
            return base.Channel.IsEmailAddressExists(email);
        }
        
        public System.Threading.Tasks.Task<bool> IsEmailAddressExistsAsync(string email) {
            return base.Channel.IsEmailAddressExistsAsync(email);
        }
        
        public System.Nullable<int> GetUserIdByCredential(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.GetUserIdByCredential(credentialDC);
        }
        
        public System.Threading.Tasks.Task<System.Nullable<int>> GetUserIdByCredentialAsync(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.GetUserIdByCredentialAsync(credentialDC);
        }
        
        public bool AddUser(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.AddUser(credentialDC);
        }
        
        public System.Threading.Tasks.Task<bool> AddUserAsync(DAL.ServiceVocabulary.CredentialDC credentialDC) {
            return base.Channel.AddUserAsync(credentialDC);
        }
        
        public bool AddWord(DAL.ServiceVocabulary.WordDC wordDC, int dictionaryId) {
            return base.Channel.AddWord(wordDC, dictionaryId);
        }
        
        public System.Threading.Tasks.Task<bool> AddWordAsync(DAL.ServiceVocabulary.WordDC wordDC, int dictionaryId) {
            return base.Channel.AddWordAsync(wordDC, dictionaryId);
        }
        
        public bool DeleteWord(int wordId) {
            return base.Channel.DeleteWord(wordId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteWordAsync(int wordId) {
            return base.Channel.DeleteWordAsync(wordId);
        }
        
        public void UpdateWord(DAL.ServiceVocabulary.WordDC wordDC) {
            base.Channel.UpdateWord(wordDC);
        }
        
        public System.Threading.Tasks.Task UpdateWordAsync(DAL.ServiceVocabulary.WordDC wordDC) {
            return base.Channel.UpdateWordAsync(wordDC);
        }
        
        public DAL.ServiceVocabulary.WordDC[] GetWords(int dictionaryId) {
            return base.Channel.GetWords(dictionaryId);
        }
        
        public System.Threading.Tasks.Task<DAL.ServiceVocabulary.WordDC[]> GetWordsAsync(int dictionaryId) {
            return base.Channel.GetWordsAsync(dictionaryId);
        }
        
        public DAL.ServiceVocabulary.WordDC[] GetNotLearnedWords(int quantityWords, int dictionaryId) {
            return base.Channel.GetNotLearnedWords(quantityWords, dictionaryId);
        }
        
        public System.Threading.Tasks.Task<DAL.ServiceVocabulary.WordDC[]> GetNotLearnedWordsAsync(int quantityWords, int dictionaryId) {
            return base.Channel.GetNotLearnedWordsAsync(quantityWords, dictionaryId);
        }
        
        public void SetToWordsStatusAsLearned(int quantityWords, int dictionaryId) {
            base.Channel.SetToWordsStatusAsLearned(quantityWords, dictionaryId);
        }
        
        public System.Threading.Tasks.Task SetToWordsStatusAsLearnedAsync(int quantityWords, int dictionaryId) {
            return base.Channel.SetToWordsStatusAsLearnedAsync(quantityWords, dictionaryId);
        }
        
        public void SetToWordsStatusAsUnlearned(int dictionaryId) {
            base.Channel.SetToWordsStatusAsUnlearned(dictionaryId);
        }
        
        public System.Threading.Tasks.Task SetToWordsStatusAsUnlearnedAsync(int dictionaryId) {
            return base.Channel.SetToWordsStatusAsUnlearnedAsync(dictionaryId);
        }
        
        public void ChangeImage(int wordId, byte[] newImage) {
            base.Channel.ChangeImage(wordId, newImage);
        }
        
        public System.Threading.Tasks.Task ChangeImageAsync(int wordId, byte[] newImage) {
            return base.Channel.ChangeImageAsync(wordId, newImage);
        }
        
        public void ChangeSound(int wordId, byte[] newSound) {
            base.Channel.ChangeSound(wordId, newSound);
        }
        
        public System.Threading.Tasks.Task ChangeSoundAsync(int wordId, byte[] newSound) {
            return base.Channel.ChangeSoundAsync(wordId, newSound);
        }
        
        public bool AddDictionary(DAL.ServiceVocabulary.DictionaryExtnDC dictionaryDC, int userId) {
            return base.Channel.AddDictionary(dictionaryDC, userId);
        }
        
        public System.Threading.Tasks.Task<bool> AddDictionaryAsync(DAL.ServiceVocabulary.DictionaryExtnDC dictionaryDC, int userId) {
            return base.Channel.AddDictionaryAsync(dictionaryDC, userId);
        }
        
        public void UpdateDictionary(int dictionaryId, string newDictionaryName) {
            base.Channel.UpdateDictionary(dictionaryId, newDictionaryName);
        }
        
        public System.Threading.Tasks.Task UpdateDictionaryAsync(int dictionaryId, string newDictionaryName) {
            return base.Channel.UpdateDictionaryAsync(dictionaryId, newDictionaryName);
        }
        
        public bool DeleteDictionary(int dictionaryId) {
            return base.Channel.DeleteDictionary(dictionaryId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteDictionaryAsync(int dictionaryId) {
            return base.Channel.DeleteDictionaryAsync(dictionaryId);
        }
        
        public DAL.ServiceVocabulary.DictionaryDC[] GetDictionariesBaseInfo(int userId) {
            return base.Channel.GetDictionariesBaseInfo(userId);
        }
        
        public System.Threading.Tasks.Task<DAL.ServiceVocabulary.DictionaryDC[]> GetDictionariesBaseInfoAsync(int userId) {
            return base.Channel.GetDictionariesBaseInfoAsync(userId);
        }
    }
}
