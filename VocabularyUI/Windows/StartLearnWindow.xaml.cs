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
        private int quantityWordsToLearn = 10;
        private int quantityReturnesWords = 0;
        private List<WordDTO> Dictionary = new List<WordDTO>();
        private static MediaPlayer mplayer = new MediaPlayer();
        private List<int> RangeList = new List<int>();
        private int selectedDictionaryId = 0;
        public List<WordDTO> WordsToLearn = new List<WordDTO>();
        private System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public StartLearnWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
            nextCardButton.IsEnabled = false;
        }
        private WordDTO RandWord(int index)
        {
            try
            {
                WordDTO wordToLearn;
                do
                {
                    wordToLearn = WordsToLearn[rand.Next(0, WordsToLearn.Count)];
                } while (wordToLearn.IsLearned[index].Equals(true));
                return wordToLearn;
            }
            catch (Exception ex)
            {
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
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WordsToLearn = _dal.GetNotLearnedWords(quantityWordsToLearn, selectedDictionaryId);
                WordsToLearn.ForEach(x => x.IsLearned = new List<Boolean> { false, false, false, false });
                quantityReturnesWords = WordsToLearn.Count();
                if (quantityReturnesWords == 0)
                {
                    MaterialMessageBox.ShowError("You have studied all the words from this dictionary. Please choose another dictionary");
                }
                else if (quantityReturnesWords < 3)
                {
                    MaterialMessageBox.ShowError("Please add words to the dictionary. Minimum quantity of the words - 3");
                }
                else
                {
                    nextCardButton.IsEnabled = true;
                    comboBox.IsEnabled = false;
                    launchButton.IsEnabled = false;
                    FormationCard2();
                    contentControl.Content = new UserControls.Card1(WordsToLearn[cardCount]);
                    nextCardButton.Focus();
                    contentControl.AddHandler(UserControls.Card3.GreetEventCard, new RoutedEventHandler(GreeterCard));
                    contentControl.AddHandler(UserControls.Card4.GreetEventCard, new RoutedEventHandler(GreeterCard));
                    contentControl.AddHandler(UserControls.Card5.GreetEventCard, new RoutedEventHandler(GreeterCard));
                    if (WordsToLearn[cardCount].Sound != null)
                    {
                        Helper.PlaySoundFromBytes(WordsToLearn[cardCount].Sound);
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void FormationCard2()
        {
            quantityCard = Convert.ToInt32(Math.Ceiling(quantityWordsToLearn / 5.0));
        }
        private void FormationCard3(int indexIsLearnedList, bool translationFromEngToUk)
        {
            try
            {
                WordDTO wordToLearn = RandWord(indexIsLearnedList);
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
                contentControl.Content = new UserControls.Card3(wordToLearn, listWords, translationFromEngToUk);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void FormationCard4()
        {
            try
            {
                WordDTO wordToLearn = RandWord(1);
                Helper.PlaySoundFromBytes(wordToLearn.Sound);
                contentControl.Content = new UserControls.Card4(wordToLearn);
            }
            catch(Exception ex)
            {
                ex.ToString();
            }          
        }
        private void FormationCard5()
        {
            try
            {
                WordDTO wordToLearn = RandWord(3);
                contentControl.Content = new UserControls.Card5(wordToLearn);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void NextCardButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cardCount < quantityReturnesWords - 1)
                {
                    Helper.PlaySoundFromBytes(WordsToLearn[++cardCount].Sound);
                    contentControl.Content = new UserControls.Card1(WordsToLearn[cardCount]);
                }
                //else if (cardCount < quantityReturnesWords - 1 + quantityCard)
                //{
                //    contentControl.Content = new UserControls.Card2(WordsToLearn.Skip(5 * index).Take(5).ToList());
                //    index++;
                //    cardCount++;
                //}
                //else if (WordsToLearn.Any(item => item.IsLearned[0].Equals(false)))
                //{
                //    FormationCard3(0, true);
                //}
                //else if (WordsToLearn.Any(item => item.IsLearned[1].Equals(false)))
                //{
                //    FormationCard4();
                //}
                //else if (WordsToLearn.Any(item => item.IsLearned[2].Equals(false)))
                //{
                //    FormationCard3(2, false);
                //}
                else if (WordsToLearn.Any(item => item.IsLearned[3].Equals(false)))
                {
                    FormationCard5();
                }
                else
                {
                    _dal.SetToWordsStatusAsLearned(quantityReturnesWords, selectedDictionaryId);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
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
