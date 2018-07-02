using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BespokeFusion;
using MahApps.Metro.Controls;
using DAL.DTOs;
using VocabularyUI.Utils;
using DAL;
using System.IO;
using System.Media;
using VocabularyUI.UserControls;
using System.ComponentModel;
using VocabularyClient;

namespace VocabularyUI.Windows
{
    public partial class LearningWindow : MetroWindow
    {
        public static Random rand = new Random();
        public ServerDAL _dal;
        private int userId = 0;
        private int dictionaryId = 0;
        private int quantityWordsToLearn = 10;
        private int quantityReturnedWords = 0;
        private bool isAllWordsPassedCard1 = false;
        private List<WordDTO> Dictionary = new List<WordDTO>();
        public List<WordDTO> WordsToLearn = new List<WordDTO>();
        private Window mainWindow = Application.Current.MainWindow;
        public LearningWindow(ServerDAL _dal, int userId, int dictionaryId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
            this.dictionaryId = dictionaryId;
            nextCardButton.IsEnabled = false;
            Closing += OnWindowClosing;
            Start();
        }

        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            this.Hide();
            Dictionary<int, string> learnedWordsCards = new Dictionary<int, string>();
            foreach (var item in WordsToLearn)
            {
                learnedWordsCards.Add(item.Id, item.IsCardPassed);
            }
            _dal.ChangeCardsStatuses(learnedWordsCards, dictionaryId);
            (mainWindow as MainWindow).IsLearningWindowClosed = true;
        }
        private void Start()
        {
            try
            {
                WordsToLearn = _dal.GetNotLearnedWords(dictionaryId, quantityWordsToLearn);
                quantityReturnedWords = WordsToLearn.Count();

                nextCardButton.IsEnabled = true;
                nextCardButton.Focus();
                contentControl.AddHandler(Card3.GreetEventCard, new RoutedEventHandler(GreeterCard));
                contentControl.AddHandler(Card4.GreetEventCard, new RoutedEventHandler(GreeterCard));
                contentControl.AddHandler(Card5.GreetEventCard, new RoutedEventHandler(GreeterCard));

                foreach (var item in WordsToLearn)
                {
                    if (item.IsCardPassed[0] == '0')
                    {
                        contentControl.Content = new Card1(item);
                        if (item.Sound != null)
                        {
                            Helper.PlaySoundFromBytes(item.Sound);
                        }
                        StringBuilder temp = new StringBuilder(item.IsCardPassed);
                        temp[0] = '1';
                        item.IsCardPassed = temp.ToString();
                        isAllWordsPassedCard1 = false;
                        return;
                    }
                }
                isAllWordsPassedCard1 = true;
                GenerationCards();
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        private WordDTO RandWord(int index)
        {
            try
            {
                WordDTO wordToLearn;
                do
                {
                    wordToLearn = WordsToLearn[rand.Next(0, WordsToLearn.Count)];
                } while (wordToLearn.IsCardPassed[index] == '1');
                return wordToLearn;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
                return null;
            }
        }
        private void FormationCard3(int index, bool translationFromEngToUk)
        {
            try
            {
                WordDTO wordToLearn = RandWord(index);
                WordDTO wordToList;
                var listWords = new List<WordDTO>();
                for (int i = 0; i < WordsToLearn.Count() - 1; i++)
                {
                    do
                    {
                        wordToList = WordsToLearn[rand.Next(0, WordsToLearn.Count)];
                    } while (wordToList.Equals(wordToLearn) || listWords.Contains(wordToList));
                    listWords.Add(wordToList);
                }
                contentControl.Content = new Card3(wordToLearn, listWords, translationFromEngToUk);
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void FormationCard4()
        {
            try
            {
                WordDTO wordToLearn = RandWord(3);
                Helper.PlaySoundFromBytes(wordToLearn.Sound);
                contentControl.Content = new Card4(wordToLearn);
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void FormationCard5()
        {
            try
            {
                WordDTO wordToLearn = RandWord(5);
                contentControl.Content = new Card5(wordToLearn);
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void GenerationCards()
        {
            bool flag = true;
            while (flag)
            {
                int cardSequenceNumber = rand.Next(1, 6);
                switch (cardSequenceNumber)
                {
                    case 1:
                        var wordsToLearn = WordsToLearn.Where(x => x.IsCardPassed[1] == '0').Take(5).ToList();
                        if (wordsToLearn.Count > 1)
                        {
                            contentControl.Content = new Card2(wordsToLearn);
                            flag = false;
                        }
                        else if (wordsToLearn.Count > 0)
                        {
                            WordDTO wordToList;
                            var wordsForExpansion = new List<WordDTO>();
                            for (int i = 0; i < 2; i++)
                            {
                                do
                                {
                                    wordToList = WordsToLearn[rand.Next(0, WordsToLearn.Count)];
                                } while (wordToList.Equals(wordsToLearn[0]) || wordsForExpansion.Contains(wordToList));
                                //wordToList.WordEng = String.Concat(wordToList.WordEng, " added");
                                wordsForExpansion.Add(wordToList);
                            }
                            wordsToLearn.AddRange(wordsForExpansion);
                            contentControl.Content = new Card2(wordsToLearn);
                            flag = false;
                        }
                        break;
                    case 2:
                        if (WordsToLearn.Count(x => x.IsCardPassed[2] == '0') > 0)
                        {
                            FormationCard3(2, true);
                            flag = false;
                        }
                        break;
                    case 3:
                        if (WordsToLearn.Count(x => x.IsCardPassed[3] == '0') > 0)
                        {
                            FormationCard4();
                            flag = false;
                        }
                        break;
                    case 4:
                        if (WordsToLearn.Count(x => x.IsCardPassed[4] == '0') > 0)
                        {
                            FormationCard3(4, false);
                            flag = false;
                        }
                        break;
                    case 5:
                        if (WordsToLearn.Count(x => x.IsCardPassed[5] == '0') > 0)
                        {
                            FormationCard5();
                            flag = false;
                        }
                        break;
                }
            }
        }
       
        private void NextCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isAllWordsPassedCard1)
                {
                    int countCard = 0;
                    foreach (var item in WordsToLearn)
                    {
                        countCard++;
                        if (item.IsCardPassed[0] == '0')
                        {
                            contentControl.Content = new Card1(item);
                            if (item.Sound != null)
                            {
                                Helper.PlaySoundFromBytes(item.Sound);
                            }
                            StringBuilder temp = new StringBuilder(item.IsCardPassed);
                            temp[0] = '1';
                            item.IsCardPassed = temp.ToString();
                            if (countCard == WordsToLearn.Count)
                            {
                                isAllWordsPassedCard1 = true;
                            }
                            return;
                        }
                    }
                }

                bool isAllWordsLearned = true;
                bool breakFromCycle = false;
                foreach (var item in WordsToLearn)
                {
                    foreach (var item2 in item.IsCardPassed.ToCharArray())
                    {
                        if (item2 == '0')
                        {
                            isAllWordsLearned = false;
                            breakFromCycle = true;
                            break;
                        }
                    }
                    if (breakFromCycle)
                    {
                        break;
                    }
                }
                if (isAllWordsLearned)
                {
                    this.Hide();
                    MaterialMessageBox.Show($"\tCongratulations. You have learned {quantityReturnedWords} words");
                    var wordsId = WordsToLearn.Select(x => x.Id).ToArray();
                    _dal.SetToWordsStatusAsLearned(wordsId, dictionaryId);
                    Helper.log.Info($"User with id: {userId} has studied {quantityReturnedWords} words in the dictionary, which id is: {dictionaryId}");
                    return;
                }
                GenerationCards();
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        void GreeterCard(Object sender, RoutedEventArgs e)
        {
            NextCardButton_Click(sender, e);
            e.Handled = true;
        }
    }
}
