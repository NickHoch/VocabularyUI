using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDal
    {
        bool IsEmailAddressExists(string email);
        bool IsDictionaryNameExists(string dictionaryName, int userId);
        int? GetUserIdByCredential(CredentialDTO credentialDTO);
        bool AddUser(CredentialExtnDTO credentialDTO);
        bool AddWord(WordDTO wordDTO, int dictionaryId);
        bool DeleteWord(int wordId);
        void UpdateWord(WordDTO wordDTO);
        List<WordDTO> GetWords(int dictionaryId);
        List<WordDTO> GetNotLearnedWordsByUserId(int userId);
        List<WordDTO> GetNotLearnedWords(int dictionaryId, int quantityWords);
        List<WordDTO> GetWordsToRepeat(int userId);
        int GetQuantityUnlearnedWordsInDictionary(int dictionaryId);
        int? IsLearningProcessActive(int userId);
        void ChangeOutstandingWords(int userId);
        void ChangeCardsStatuses(Dictionary<int, string> newCardsStatuses, int dictionaryId);
        void SetToWordsStatusAsLearned(int[] wordsArr, int dictionaryId);
        void SetToWordsStatusAsUnlearned(int dictionaryId);
        void SetToWordsStatusAsUnlearned(int[] wordsId);
        void ChangeImage(int wordId, byte[] newImage);
        void ChangeSound(int wordId, byte[] newSound);
        bool AddDictionary(DictionaryExtnDTO dictionaryDTO, int userId);
        void UpdateDictionary(int dictionaryId, string newDictionaryName);
        bool DeleteDictionary(int dictionaryId);
        List<DictionaryDTO> GetDictionariesBaseInfo(int userId);

    }
}
