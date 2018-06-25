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
using System.Windows.Media.Animation;
using BespokeFusion;

namespace VocabularyUI.UserControls
{
    public partial class Card2 : UserControl
    {
        private string wordEng;
        private string translation;
        private int CountCorrectlySelectedWords = 0;
        private List<WordDTO> wordsToLearn;
        private Button wordEngButtom;

        private StartLearnWindow parentWindow = Application.Current.Windows.OfType<StartLearnWindow>().FirstOrDefault();
        public Card2(List<WordDTO> wordsToLearn)
        {
            try
            {
                InitializeComponent();
                card2Grid.Background = new SolidColorBrush(Color.FromArgb(1, 71, 147, 223));
                this.wordsToLearn = wordsToLearn;

                List<int> indeciesList = new List<int>();
                RandIndecies(ref indeciesList, wordsToLearn.Count);

                int i = 0;
                foreach (UIElement item in card2Grid.Children)
                {
                    if (i == wordsToLearn.Count)
                    {
                        break;
                    }
                    if (Grid.GetColumn(item).Equals(0) && item is Button)
                    {
                        (((((item as Button).Content)as Viewbox).Child)as TextBlock).Text = wordsToLearn[indeciesList[i++]].WordEng;
                    }
                }

                indeciesList.Clear();
                RandIndecies(ref indeciesList, wordsToLearn.Count);
                i = 0;
                foreach (UIElement item in card2Grid.Children)
                {
                    if (i == wordsToLearn.Count)
                    {
                        break;
                    }
                    if (Grid.GetColumn(item).Equals(1) && item is Button)
                    {
                        (((((item as Button).Content) as Viewbox).Child) as TextBlock).Text = wordsToLearn[indeciesList[i++]].Translation;
                    }
                }
                parentWindow.nextCardButton.IsEnabled = false;

                foreach (var item in card2Grid.Children)
                {
                    if (item is Button && (item as Button).Content == null)
                    {
                        (item as Button).Visibility = Visibility.Hidden;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        private void RandIndecies(ref List<int> indeciesList, int quantityWords)
        {
            try
            {
                for (int i = 0; i < quantityWords; i++)
                {
                    int index = 0;
                    do
                    {
                        index = MainWindow.rand.Next(0, quantityWords);
                    } while (indeciesList.Contains(index));
                    indeciesList.Add(index);
                }
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        private void WordEng_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wordEng = (((((sender as Button).Content) as Viewbox).Child) as TextBlock).Text;
                wordEngButtom = (sender as Button);
                var word = wordsToLearn.Where(item => item.WordEng == wordEng).FirstOrDefault();
                Helper.PlaySoundFromBytes(word.Sound);
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        private void Translation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (wordEng != null)
                {
                    translation = (((((sender as Button).Content) as Viewbox).Child) as TextBlock).Text;
                    WordDTO word = wordsToLearn.Where(item => item.WordEng == wordEng).Single();
                    if (word.Translation == translation)
                    {
                        (sender as Button).Background = Brushes.LightGreen;
                        (sender as Button).IsHitTestVisible = false;
                        wordEngButtom.Background = Brushes.LightGreen;
                        wordEngButtom.IsHitTestVisible = false;
                        CountCorrectlySelectedWords++;
                        parentWindow.WordsToLearn.Where(x => x.Id == word.Id).SingleOrDefault().IsCardPassed[1] = true;
                    }
                    else
                    {
                        Storyboard sb = FindResource("mistakeAnimation") as Storyboard;
                        Storyboard.SetTarget(sb, (sender as Button));
                        sb.Begin();

                        (sender as Button).Focusable = false;
                        foreach (var item in card2Grid.Children)
                        {
                            if (item is Button && (item as Button).Content != null && (item as Button).Content.Equals(wordEng))
                            {
                                (item as Button).Background = Brushes.Transparent;
                            }
                        }
                    }
                    if (CountCorrectlySelectedWords.Equals(wordsToLearn.Count))
                    {
                        parentWindow.nextCardButton.IsEnabled = true;
                    }
                    wordEng = null;
                }
            }
            catch(Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}
