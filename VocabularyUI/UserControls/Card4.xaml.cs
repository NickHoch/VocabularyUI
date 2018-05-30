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
using VocabularyUI.Windows;
using DAL.DTOs;
using BespokeFusion;
using VocabularyUI.Utils;

namespace VocabularyUI.UserControls
{
    public partial class Card4 : UserControl
    {
        private int time = 10;
        private WordDTO WordToLearn { get; set; }
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private StartLearnWindow parentWindow = Application.Current.Windows.OfType<StartLearnWindow>().FirstOrDefault();
        public Card4(WordDTO wordToLearn)
        {
            try
            {

                InitializeComponent();
                this.card4Grid.Background = new SolidColorBrush(Color.FromArgb(177, 204, 255, 204));
                WordToLearn = wordToLearn;
                wordEng.Text = wordToLearn.WordEng;
                transcription.Text = wordToLearn.Transcription;
                timer.Text = time.ToString();

                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();

                parentWindow.nextCardButton.IsEnabled = false;
            }  
            catch(Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
}

        public static readonly RoutedEvent GreetEventCard = EventManager.RegisterRoutedEvent(
        "Greet", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Card4));

        public event RoutedEventHandler Greet
        {
            add { AddHandler(Card4.GreetEventCard, value); }
            remove { RemoveHandler(Card4.GreetEventCard, value); }
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (time.Equals(1))
                {
                    dispatcherTimer.Stop();
                    timer.Text = WordToLearn.Translation;
                    recalledButton.IsEnabled = false;
                    forgotButton.IsEnabled = false;
                    parentWindow.nextCardButton.IsEnabled = true;
                }
                else
                {
                    --time;
                    timer.Text = time.ToString();
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void forgotButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dispatcherTimer.Stop();
                timer.Text = WordToLearn.Translation;
                recalledButton.IsEnabled = false;
                forgotButton.IsEnabled = false;
                parentWindow.nextCardButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private async void recalledButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                dispatcherTimer.Stop();
                recalledButton.IsEnabled = false;
                forgotButton.IsEnabled = false;
                parentWindow.WordsToLearn.Where(item => item.WordEng.Equals(WordToLearn.WordEng))
                                                 .Single()
                                                 .IsLearned[1] = true;
                timer.Text = WordToLearn.Translation;
                await Task.Delay(500);
                RaiseEvent(new RoutedEventArgs(GreetEventCard, this));
            }
            catch(Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}
