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
        public List<DictionaryDTO> GetDictionariesNameAndId(int userId)
        {
            List<DictionaryDTO> listDictionariesDTO = new List<DictionaryDTO>();
            var listDictionariesDC = vocabularyClient.GetDictionariesNameAndId(userId).ToList();
            listDictionariesDC.ForEach(x => listDictionariesDTO.Add(MappingDictionary.CredentialDCtoDTO(x)));
            return listDictionariesDTO;
        }
        public List<WordDTO> GetNotLearnedWords(int quantityWords, int dictionaryId)
        {
            List<WordDTO> listWordsDTO = new List<WordDTO>();
            var listWordsDC = vocabularyClient.GetNotLearnedWords(quantityWords, dictionaryId).ToList();
            listWordsDC.ForEach(x => listWordsDTO.Add(MappingWord.MappingDCtoDTO(x)));
            return listWordsDTO;
        }
        public void SetToWordsStatusAsLearned(int quantityWords, int dictionaryId)
        {
            vocabularyClient.SetToWordsStatusAsLearned(quantityWords, dictionaryId);
        }
    }
}
