using DAL.DTOs;
using DAL.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ServerDAL
    {
        private ServiceVocabulary.VocabularyClient vocabularyClient = new ServiceVocabulary.VocabularyClient();
        public bool IsEmailAddressExists(string email)
        {
            return vocabularyClient.IsEmailAddressExists(email);
        }
        public bool IsDictionaryNameExists(string dictionaryName, int userId)
        {
            return vocabularyClient.IsDictionaryNameExists(dictionaryName, userId);
        }
        public int? GetUserIdByCredential(CredentialDTO credentialDTO)
        {
            var credentialDC = MappingCredential.CredentialDTOtoDC(credentialDTO);
            return vocabularyClient.GetUserIdByCredential(credentialDC);
        }
        public bool AddUser(CredentialDTO credentialDTO)
        {
            var credentialDC = MappingCredential.CredentialDTOtoDC(credentialDTO);
            return vocabularyClient.AddUser(credentialDC);
        }
        public bool AddWord(WordDTO wordDTO, int dictionaryId)
        {
            var wordDC = MappingWord.MappingDTOtoDC(wordDTO);
            return vocabularyClient.AddWord(wordDC, dictionaryId);
        }
        public bool DeleteWord(int wordId)
        {
            return vocabularyClient.DeleteWord(wordId);
        }
        public void UpdateWord(WordDTO wordDTO)
        {
            var wordDC = MappingWord.MappingDTOtoDC(wordDTO);
            vocabularyClient.UpdateWord(wordDC);
        }
        public List<DictionaryDTO> GetDictionariesNameAndId(int userId)
        {
            List<DictionaryDTO> listDictionariesDTO = new List<DictionaryDTO>();
            var listDictionariesDC = vocabularyClient.GetDictionariesNameAndId(userId).ToList();
            listDictionariesDC.ForEach(x => listDictionariesDTO.Add(MappingDictionary.CredentialDCtoDTO(x)));
            return listDictionariesDTO;
        }
        public List<WordDTO> GetWords(int dictionaryId)
        {
            List<WordDTO> listWordsDTO = new List<WordDTO>();
            var listWordsDC = vocabularyClient.GetWords(dictionaryId).ToList();
            listWordsDC.ForEach(x => listWordsDTO.Add(MappingWord.MappingDCtoDTO(x)));
            return listWordsDTO;
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
        public void SetToWordsStatusAsUnlearned(int dictionaryId)
        {
            vocabularyClient.SetToWordsStatusAsUnlearned(dictionaryId);
        }
        public void ChangeImage(int wordId, byte[] newImage)
        {
            vocabularyClient.ChangeImage(wordId, newImage);
        }
        public void ChangeSound(int wordId, byte[] newSound)
        {
            vocabularyClient.ChangeSound(wordId, newSound);
        }
        public bool AddDictionary(DictionaryDTO dictionaryDTO, int userId)
        {
            var dictionaryDC = MappingDictionary.CredentialDTOtoDC(dictionaryDTO);
            return vocabularyClient.AddDictionary(dictionaryDC, userId);
        }
        public bool DeleteDictionary(int dictionaryId)
        {
            return vocabularyClient.DeleteDictionary(dictionaryId);
        }
    }
}
