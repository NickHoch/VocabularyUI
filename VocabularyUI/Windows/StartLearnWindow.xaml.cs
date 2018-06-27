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

namespace VocabularyUI.Windows
{
    public partial class StartLearnWindow : MetroWindow
    {
        public static Random rand = new Random();
        public ServerDAL _dal;
        private int index = 0;
        private int userId = 0;
        private int cardCount = 0;
        private int quantityCard = 0;
        private int selectedDictionaryId = 0;
        private int quantityWordsToLearn = 10;
        private int quantityReturnedWords = 0;
        private bool isAllWordsPassedCard1 = false;
        private List<WordDTO> Dictionary = new List<WordDTO>();
        public List<WordDTO> WordsToLearn = new List<WordDTO>();

        public StartLearnWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
            nextCardButton.IsEnabled = false;
            Closing += OnWindowClosing;
        }
        private void OnWindowClosing(object sender, CancelEventArgs e)
        {
            this.Hide();
            Dictionary<int, bool[]> learnedWordsCards = new Dictionary<int, bool[]>();
            foreach (var item in WordsToLearn)
            {
                learnedWordsCards.Add(item.Id, item.IsCardPassed);
            }
            _dal.ChangeCardsStatuses(learnedWordsCards, selectedDictionaryId);
        }
        private WordDTO RandWord(int index)
        {
            try
            {
                WordDTO wordToLearn;
                do
                {
                    wordToLearn = WordsToLearn[rand.Next(0, WordsToLearn.Count)];
                } while (wordToLearn.IsCardPassed[index] == true);
                return wordToLearn;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
                return null;
            }
        }
        private void ComboBox_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                var res = _dal.GetDictionariesBaseInfo(userId);
                comboBox.DisplayMemberPath = "Name";
                comboBox.ItemsSource = res;
                comboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                selectedDictionaryId = (comboBox.SelectedValue as DictionaryDTO).Id;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
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
            catch(Exception ex)
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
                        var wordsToLearn = WordsToLearn.Where(x => x.IsCardPassed[1] == false).Take(5).ToList();
                        if (wordsToLearn.Count > 1)
                        {
                            contentControl.Content = new Card2(wordsToLearn);
                            flag = false;
                        }
                        else if(wordsToLearn.Count > 0)
                        {
                            WordDTO wordToList;
                            var wordsForExpansion = new List<WordDTO>();
                            for (int i = 0; i < 2; i++)
                            {
                                do
                                {
                                    wordToList = WordsToLearn[rand.Next(0, WordsToLearn.Count)];
                                } while (wordToList.Equals(wordsToLearn[0]) || wordsForExpansion.Contains(wordToList));
                                String.Concat(wordToList.WordEng, " added");
                                wordsForExpansion.Add(wordToList);
                            }
                            wordsToLearn.AddRange(wordsForExpansion);
                            contentControl.Content = new Card2(wordsToLearn);
                            flag = false;
                        }
                        break;
                    case 2:
                        if (WordsToLearn.Count(x => x.IsCardPassed[2] == false) > 0)
                        {
                            FormationCard3(2, true);
                            flag = false;
                        }
                        break;
                    case 3:
                        if (WordsToLearn.Count(x => x.IsCardPassed[3] == false) > 0)
                        {
                            FormationCard4();
                            flag = false;
                        }
                        break;
                    case 4:
                        if (WordsToLearn.Count(x => x.IsCardPassed[4] == false) > 0)
                        {
                            FormationCard3(4, false);
                            flag = false;
                        }
                        break;
                    case 5:
                        if (WordsToLearn.Count(x => x.IsCardPassed[5] == false) > 0)
                        {
                            FormationCard5();
                            flag = false;
                        }
                        break;
                }
            }
        }
        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WordsToLearn = _dal.GetNotLearnedWords(quantityWordsToLearn, selectedDictionaryId);
                quantityReturnedWords = WordsToLearn.Count();
                if (quantityReturnedWords == 0)
                {
                    MaterialMessageBox.ShowError("The dictionary is empty or all the words from the dictionary have been studied");
                }
                else if (quantityReturnedWords < 3)
                {
                    MaterialMessageBox.ShowError("Please add words to the dictionary. Minimum quantity of the words - 3");
                }
                else
                {
                    nextCardButton.IsEnabled = true;
                    comboBox.IsEnabled = false;
                    launchButton.IsEnabled = false;
                    nextCardButton.Focus();
                    contentControl.AddHandler(Card3.GreetEventCard, new RoutedEventHandler(GreeterCard));
                    contentControl.AddHandler(Card4.GreetEventCard, new RoutedEventHandler(GreeterCard));
                    contentControl.AddHandler(Card5.GreetEventCard, new RoutedEventHandler(GreeterCard));

                    foreach (var item in WordsToLearn)
                    {
                        if (item.IsCardPassed[0] == false)
                        {
                            contentControl.Content = new Card1(item);
                            if (item.Sound != null)
                            {
                                Helper.PlaySoundFromBytes(item.Sound);
                            }
                            item.IsCardPassed[0] = true;
                            isAllWordsPassedCard1 = false;
                            return;
                        }
                    }
                    isAllWordsPassedCard1 = true;
                    GenerationCards();
                }
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void NextCardButton_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                if(!isAllWordsPassedCard1)
                {
                    int countCard = 0;
                    foreach (var item in WordsToLearn)
                    {
                        countCard++;
                        if (item.IsCardPassed[0] == false)
                        {
                            contentControl.Content = new Card1(item);
                            if (item.Sound != null)
                            {
                                Helper.PlaySoundFromBytes(item.Sound);
                            }
                            item.IsCardPassed[0] = true;
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
                foreach(var item in WordsToLearn)
                {
                    foreach(var item2 in item.IsCardPassed)
                    {
                        if(item2 == false)
                        {
                            isAllWordsLearned = false;
                            breakFromCycle = true;
                            break;
                        }
                    }
                    if(breakFromCycle)
                    {
                        break;
                    }
                }
                if(isAllWordsLearned)
                {
                    _dal.SetToWordsStatusAsLearned(quantityReturnedWords, selectedDictionaryId);
                    Helper.log.Info($"User with id: {userId} has studied {quantityReturnedWords} words in the dictionary, which id is: {selectedDictionaryId}");
                    this.Close();
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
