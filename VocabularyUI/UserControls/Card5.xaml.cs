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
using System.Windows.Threading;
using BespokeFusion;
using DAL.DTOs;
using VocabularyUI.Utils;
using VocabularyUI.Windows;

namespace VocabularyUI.UserControls
{
    public partial class Card5 : UserControl
    {
        private WordDTO wordToLearn = new WordDTO();
        private StartLearnWindow parentWindow = Application.Current.Windows.OfType<StartLearnWindow>().FirstOrDefault();
        public Card5(WordDTO wordToLearn)
        {
            try
            {
                InitializeComponent();
                border.Background = new SolidColorBrush(Color.FromArgb(177, 204, 229, 255));
                this.wordToLearn = wordToLearn;
                translation.Text = wordToLearn.Translation;
                StringBuilder starsString = new StringBuilder();
                for (int i = 0; i < wordToLearn.WordEng.Count(); i++)
                {
                    starsString.Append('*');
                }
                stars.Text = starsString.ToString();

                Dispatcher.BeginInvoke(DispatcherPriority.Input,
                new Action(delegate () { enteredWord.Focus(); Keyboard.Focus(enteredWord); }));
                parentWindow.nextCardButton.IsEnabled = false;
            }
            catch(Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        public static readonly RoutedEvent GreetEventCard = EventManager.RegisterRoutedEvent(
        "Greet", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Card5));

        public event RoutedEventHandler Greet
        {
            add { AddHandler(Card5.GreetEventCard, value); }
            remove { RemoveHandler(Card5.GreetEventCard, value); }
        }
        private void answerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wordEng.Text = wordToLearn.WordEng;
                enteredWord.IsReadOnly = true;
                answerButton.IsEnabled = false;
                compareButton.IsEnabled = false;
                parentWindow.nextCardButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private async void compareButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enteredWord.IsReadOnly = true;
                answerButton.IsEnabled = false;
                compareButton.IsEnabled = false;
                if (wordToLearn.WordEng.Equals(enteredWord.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    parentWindow.WordsToLearn.Where(item => item.WordEng.Equals(wordToLearn.WordEng)).SingleOrDefault().IsCardPassed[5] = true;
                    wordEng.Text = "true";
                    await Task.Delay(500);
                    RaiseEvent(new RoutedEventArgs(GreetEventCard, this));
                }
                else
                {
                    compareButton.IsEnabled = false;
                    wordEng.Text = wordToLearn.WordEng;
                    parentWindow.nextCardButton.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}
