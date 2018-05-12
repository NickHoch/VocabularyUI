using BespokeFusion;
using DAL;
using DAL.DTOs;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace VocabularyUI.Windows
{
    public partial class EditWindow : MetroWindow
    {
        private ObservableCollection<WordDTO> wordsObCollection = null;
        private WordDTO newWord = new WordDTO();
        private int userId;
        private ServerDAL _dal = null;

        public EditWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            dataGrid.ItemsSource = null;
            this.userId = userId;
            this.DataContext = newWord;
            //wordsObCollection = vocabularyContext.Words.Local;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(wordField.Text)
                || String.IsNullOrWhiteSpace(transcriptionField.Text)
                || String.IsNullOrWhiteSpace(translationField.Text))
            {
                MaterialMessageBox.ShowError("Please, fill in all required fields");
            }
            else
            {
                var selectedDictionaryName = comboBox.SelectedItem as string;
                newWord.WordEng = wordField.Text;
                newWord.Transcription = transcriptionField.Text;
                newWord.Translation = translationField.Text;
                //newWord.DictionaryId = vocabularyContext.Dictionaries.Where(x => x.Name == selectedDictionaryName).Select(x => x.Id).Single();
                //vocabularyContext.Words.Add(newWord);
                //vocabularyContext.SaveChanges();
                //dataGrid.ItemsSource = null; // refresh datagrid
                //dataGrid.ItemsSource = vocabularyContext.Words.Where(x => x.DictionaryId == vocabularyContext.Dictionaries.Where(y => y.Name == selectedDictionaryName)
                //                                                                                                      .Select(y => y.Id)
                //                                                                                                      .FirstOrDefault())
                //                                              .ToList();
                wordField.Text = String.Empty; // refresh textbox
                transcriptionField.Text = String.Empty;
                translationField.Text = String.Empty;
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                var selectedDictionaryName = comboBox.SelectedItem as string;
                //vocabularyContext.Words.Remove((dataGrid.SelectedItem as Word));
                //vocabularyContext.SaveChanges();

                //dataGrid.ItemsSource = null; // refresh datagrid
                //dataGrid.ItemsSource = vocabularyContext.Words.Where(x => x.DictionaryId == vocabularyContext.Dictionaries.Where(y => y.Name == selectedDictionaryName)
                //                                                                                                      .Select(y => y.Id)
                //                                                                                                      .FirstOrDefault())
                //                                              .ToList();
            }
            else
            {
                MaterialMessageBox.ShowError("Please, choose row to delete");
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                //vocabularyContext.SaveChanges();
                dataGrid.Items.Refresh();
            }
            else
            {
                MaterialMessageBox.ShowError("Please, choose row to update");
            }
        }
        private void ComboBox_Load(object sender, RoutedEventArgs e)
        {
            //var comboBox = sender as ComboBox;
            ////vocabularyContext.Dictionaries.Load(); /// del
            ////comboBox.ItemsSource = vocabularyContext.Dictionaries.Where(x => x.UserId == userId).Select(x => x.Name).ToList(); /// del
            //comboBox.ItemsSource = _dal.GetDictionariesNameByUserId(userId);
            //comboBox.SelectedIndex = 0;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedItem = sender as ComboBox;
            //var selectedDictionaryName = selectedItem.SelectedItem as string;
            //dataGrid.ItemsSource = vocabularyContext.Words.Where(x => x.DictionaryId == vocabularyContext.Dictionaries.Where(y => y.Name == selectedDictionaryName)
            //                                                                                                          .Select(y => y.Id)
            //                                                                                                          .FirstOrDefault())
            //                                              .ToList();
        }
        private void Sound_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".mp3";
            dlg.Filter = "Sound files (.mp3)|*.mp3";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                newWord.Sound = File.ReadAllBytes(dlg.FileName);
            }
        }
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpeg";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                newWord.Image = File.ReadAllBytes(dlg.FileName);
            }
        }
    }
}
