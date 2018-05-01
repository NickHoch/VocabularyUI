using DAL.DMs;
using DAL.Mapping;

namespace DAL
{
    public class ServerDAL
    {
        private ServiceVocabulary.VocabularyClient vocabularyClient = new ServiceVocabulary.VocabularyClient();
        public int? CheckCredential(Credential credential)
        {
            var credentialDC = MappingCredential.CredentialDMtoDC(credential);
            return vocabularyClient.CheckCredential(credentialDC);            
        }
        public bool IsEmailAddressFree(string email)
        {
            return vocabularyClient.IsEmailAddressFree(email);
        }
    }
}
