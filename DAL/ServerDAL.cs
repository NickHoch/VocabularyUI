using DAL.DTOs;
using DAL.Mapping;

namespace DAL
{
    public class ServerDAL
    {
        private ServiceVocabulary.VocabularyClient vocabularyClient = new ServiceVocabulary.VocabularyClient();
        public int? GetUserIdByCredential(CredentialDTO credentialDTO)
        {
            var credentialDC = MappingCredential.CredentialDTOtoDC(credentialDTO);
            return vocabularyClient.GetUserIdByCredential(credentialDC);            
        }
        public bool IsEmailAddressFree(string email)
        {
            return vocabularyClient.IsEmailAddressFree(email);
        }
        public bool AddCredential(CredentialDTO credentialDTO)
        {
            var credentialDC = MappingCredential.CredentialDTOtoDC(credentialDTO);
            return vocabularyClient.AddCredential(credentialDC);
        }
        public bool AddDictionary(DictionaryDTO dictionaryDTO)
        {
            var dictionaryDC = MappingDictionary.CredentialDTOtoDC(dictionaryDTO);
            return vocabularyClient.AddDictionary(dictionaryDC);
        }
    }
}
