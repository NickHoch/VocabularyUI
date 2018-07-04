using BespokeFusion;
using DAL;
using DAL.DTOs;
using MahApps.Metro.Controls;
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
using VocabularyClient;
using VocabularyUI.Utils;

namespace VocabularyUI.Windows
{
    public partial class SelectDictionaryWindow : MetroWindow
    {
        public static Random rand = new Random();
        public IDal _dal;
        private int userId = 0;
        private int dictionaryId = 0;
        private Window mainWindow = Application.Current.MainWindow;
        public SelectDictionaryWindow(IDal _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
        }
        private void ComboBox_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                var dictionaries = _dal.GetDictionariesBaseInfo(userId);
                comboBox.DisplayMemberPath = "Name";
                comboBox.ItemsSource = dictionaries;
                comboBox.SelectedIndex = 0;
                dictionaryId = dictionaries[0].Id;
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
                dictionaryId = (comboBox.SelectedValue as DictionaryDTO).Id;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            var res = _dal.IsLearningProcessActive(userId);
            if (res != dictionaryId && res != null)
            {
                MaterialMessageBox.ShowError($"The process of learning the words of \"{res}\" dictionary isn`t completed. Please try again after completion of the process");
                return;
            }
            else if(res == null)
            {
                var quantityReturnedWords = _dal.GetQuantityUnlearnedWordsInDictionary(dictionaryId);
                if (quantityReturnedWords == 0)
                {
                    MaterialMessageBox.ShowError("The dictionary is empty or all the words from the dictionary have been studied");
                    return;
                }
                else if (quantityReturnedWords < 3)
                {
                    MaterialMessageBox.ShowError("Please add words to the dictionary. Minimum quantity of the words - 3");
                    return;
                }
            }

            var learningWindow = new LearningWindow(_dal, userId, false, dictionaryId);
            learningWindow.Show();
            (mainWindow as MainWindow).popupTimer.Start();
            (mainWindow as MainWindow).IsLearningWindowClosed = false;

            Helper.log.Info($"User with id: {userId} start to learn words from dictionary id: {dictionaryId}");
            this.Close();
        }
    }
}