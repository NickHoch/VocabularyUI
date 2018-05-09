using DAL.DTOs;
using DAL.Mapping;
using System.Collections.Generic;
using System.Linq;

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
        public bool AddUser(CredentialDTO credentialDTO)
        {
            var credentialDC = MappingCredential.CredentialDTOtoDC(credentialDTO);
            return vocabularyClient.AddUser(credentialDC);
        }
        public bool AddDictionary(DictionaryDTO dictionaryDTO)
        {
            var dictionaryDC = MappingDictionary.CredentialDTOtoDC(dictionaryDTO);
            return vocabularyClient.AddDictionary(dictionaryDC);
        }
        public List<string> GetDictionariesNameByUserId(int userId)
        {
            return vocabularyClient.GetDictionariesNameByUserId(userId)
                                   .OfType<string>()
                                   .ToList();
        }
        public List<WordDTO> GetNotLearnedWords(int quantityWords, string dictionaryName)
        {
            var listWordsDC = vocabularyClient.GetNotLearnedWords(quantityWords, dictionaryName);
            List<WordDTO> listWordsDTO = new List<WordDTO>();
            foreach(var item in listWordsDC)
            {
                listWordsDTO.Add(MappingWord.MappingDCtoDTO(item));
            }
            return listWordsDTO;
        }
    }
}
