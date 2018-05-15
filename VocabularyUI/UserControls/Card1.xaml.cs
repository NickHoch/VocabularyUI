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
using VocabularyUI.Utils;

namespace VocabularyUI.UserControls
{
    public partial class Card1 : UserControl
    {
        public Card1(WordDTO word)
        {
            InitializeComponent();
            wordEng.Text = word.WordEng;
            transcription.Text = word.Transcription;
            translation.Text = word.Translation;
            DataContext = Helper.LoadImage(word.Image);
        }
    }
}
