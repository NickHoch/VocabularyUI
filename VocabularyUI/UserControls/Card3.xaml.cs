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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL.DTOs;
using VocabularyClient;
using VocabularyUI.Windows;
using VocabularyUI.Utils;
using BespokeFusion;

namespace VocabularyUI.UserControls
{
    public partial class Card3 : UserControl
    {
        private WordDTO wordToLearn = new WordDTO();
        private bool translationFromEngToUk;
        private bool wasError = false;
        private StartLearnWindow parentWindow = Application.Current.Windows.OfType<StartLearnWindow>().FirstOrDefault();
        public Card3(WordDTO wordToLearn, List<WordDTO> wordsList, bool translationFromEngToUk)
        {
            try
            {

                InitializeComponent();
                this.Card3Grid.Background = new SolidColorBrush(Color.FromArgb(177, 255, 255, 204));
                this.wordToLearn = wordToLearn;
                this.translationFromEngToUk = translationFromEngToUk;
                if (translationFromEngToUk)
                {
                    wordEng.Text = wordToLearn.WordEng;
                    transcription.Text = wordToLearn.Transcription;
                }
                else
                {
                    wordEng.Text = wordToLearn.Translation;
                }

                int i = 0;
                int index = 0;
                int randIndex = MainWindow.rand.Next(0, wordsList.Count < 6 ? wordsList.Count : 6);
                foreach (var item in Card3Grid.Children)
                {
                    if (index > wordsList.Count)
                    {
                        break;
                    }
                    if (translationFromEngToUk)
                    {
                        if (item is Button && index.Equals(randIndex))
                        {
                            index++;
                            (item as Button).Content = wordToLearn.Translation;
                        }
                        else if (item is Button)
                        {
                            index++;
                            (item as Button).Content = wordsList[i++].Translation;
                        }
                        Helper.PlaySoundFromBytes(wordToLearn.Sound);
                    }
                    else
                    {
                        if (item is Button && index.Equals(randIndex))
                        {
                            index++;
                            (item as Button).Content = wordToLearn.WordEng;
                        }
                        else if (item is Button)
                        {
                            index++;
                            (item as Button).Content = wordsList[i++].WordEng;
                        }
                    }
                }
                foreach (var item in Card3Grid.Children)
                {
                    if (item is Button && (item as Button).Content == null)
                    {
                        (item as Button).Visibility = Visibility.Hidden;
                    }
                }
                parentWindow.nextCardButton.IsEnabled = false;
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        public static readonly RoutedEvent GreetEventCard = EventManager.RegisterRoutedEvent(
        "Greet", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Card3));

        public event RoutedEventHandler Greet
        {
            add { AddHandler(Card3.GreetEventCard, value); }
            remove { RemoveHandler(Card3.GreetEventCard, value); }
        }
        private void ReturnButtonBackground()
        {
            try
            {
                foreach (var item in Card3Grid.Children)
                {
                    if (item is Button)
                    {
                        (item as Button).ClearValue(BackgroundProperty);
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void CorrectChoice(object sender)
        {
            try
            {
                ReturnButtonBackground();
                (sender as Button).Background = Brushes.LightGreen;
                parentWindow.nextCardButton.IsEnabled = true;
                foreach (var item in Card3Grid.Children)
                {
                    if (item is Button)
                    {
                        (item as Button).IsHitTestVisible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void IncorrectChoice(object sender)
        {
            try
            {
                wasError = true;
                ReturnButtonBackground();
                (sender as Button).Background = Brushes.IndianRed;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (translationFromEngToUk)
                {
                    if ((sender as Button).Content.Equals(wordToLearn.Translation))
                    {
                        if (!wasError)
                        {
                            parentWindow.WordsToLearn.Where(item => item.WordEng.Equals(wordToLearn.WordEng))
                                                   .Single()
                                                   .IsLearned[0] = true;
                        }
                        CorrectChoice(sender);
                    }
                    else
                    {
                        IncorrectChoice(sender);
                    }
                }
                else
                {
                    if ((sender as Button).Content.Equals(wordToLearn.WordEng))
                    {
                        if (!wasError)
                        {
                            parentWindow.WordsToLearn.Where(item => item.WordEng.Equals(wordToLearn.WordEng))
                                                   .Single()
                                                   .IsLearned[2] = true;
                        }
                        CorrectChoice(sender);
                    }
                    else
                    {
                        IncorrectChoice(sender);
                    }
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}
