﻿using BespokeFusion;
using DAL;
using DAL.DTOs;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class EditWordsWindow : MetroWindow
    {
        private int userId = 0;
        private WordDTO newWord = null;
        private ServerDAL _dal = null;
        private byte[] soundArr = null;
        private byte[] imageArr = null;
        private byte[] bytesArr = null;
        private int selectedDictionaryId = 0;

        public EditWordsWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(wordField.Text)
               || String.IsNullOrWhiteSpace(transcriptionField.Text)
               || String.IsNullOrWhiteSpace(translationField.Text))
                {
                    MaterialMessageBox.ShowError("Please fill in all required fields");
                }
                else
                {
                    var selectedDictionaryName = comboBox.SelectedItem as string;
                    newWord = new WordDTO();
                    newWord.WordEng = wordField.Text;
                    newWord.Transcription = transcriptionField.Text;
                    newWord.Translation = translationField.Text;
                    newWord.Image = imageArr;
                    newWord.Sound = soundArr;
                    _dal.AddWord(newWord, selectedDictionaryId);

                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = _dal.GetWords(selectedDictionaryId);
                    wordField.Text = String.Empty;
                    transcriptionField.Text = String.Empty;
                    translationField.Text = String.Empty;
                    imageArr = null;
                    soundArr = null;
                }
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                {
                    int wordId = (dataGrid.SelectedItem as WordDTO).Id;
                    _dal.DeleteWord(wordId);
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = _dal.GetWords(selectedDictionaryId);
                }
                else
                {
                    MaterialMessageBox.ShowError("Please choose row to delete");
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGrid.SelectedItem != null)
                {
                    var wordToUpdate = (dataGrid.SelectedItem as WordDTO);
                    wordToUpdate.Dictionary = null;
                    _dal.UpdateWord(wordToUpdate);
                }
                else
                {
                    MaterialMessageBox.ShowError("Please choose row to update");
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
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
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var comboBox = sender as ComboBox;
                selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
                dataGrid.ItemsSource = _dal.GetWords(selectedDictionaryId);
            }
            catch(Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
        private void SoundAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".mp3";
                dlg.Filter = "Sound files (.mp3)|*.mp3";
                var result = dlg.ShowDialog();
                if (result == true)
                {
                    soundArr = File.ReadAllBytes(dlg.FileName);
                }
            }
            catch(Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
        private void ImageAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".jpeg";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                var result = dlg.ShowDialog();
                if (result == true)
                {
                    imageArr = File.ReadAllBytes(dlg.FileName);
                }
            }
            catch(Exception ex)
            {
                MaterialMessageBox.Show(ex.Message);
            }
        }
        private void SoundChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".mp3";
                dlg.Filter = "Sound files (.mp3)|*.mp3";
                if (dlg.ShowDialog() == true)
                {
                    var size = new FileInfo(dlg.FileName).Length;
                    if (size > 262144)
                    {
                        MaterialMessageBox.ShowError("The size of the selected file more than 256KB. Please select another file");
                        return;
                    }
                    bytesArr = File.ReadAllBytes(dlg.FileName);
                    var word = (dataGrid.SelectedItem as WordDTO);
                    _dal.ChangeSound(word.Id, bytesArr);
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = _dal.GetWords(selectedDictionaryId);
                }
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        private void ImageChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".jpeg";
                dlg.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (dlg.ShowDialog() == true)
                {
                    var size = new FileInfo(dlg.FileName).Length;
                    if (size > 262144)
                    {
                        MaterialMessageBox.ShowError("The size of the selected file more than 256KB. Please select another file");
                        return;
                    }
                    bytesArr = File.ReadAllBytes(dlg.FileName);
                    var word = (dataGrid.SelectedItem as WordDTO);
                    _dal.ChangeImage(word.Id, bytesArr);
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = _dal.GetWords(selectedDictionaryId);
                }
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        public class MediaPlayer
        {
            System.Media.SoundPlayer soundPlayer;

            public MediaPlayer(byte[] buffer)
            {
                var memoryStream = new MemoryStream(buffer, true);
                soundPlayer = new System.Media.SoundPlayer(memoryStream);
            }

            public void Play()
            {
                soundPlayer.Play();
            }

            public void Play(byte[] buffer)
            {
                soundPlayer.Stream.Seek(0, SeekOrigin.Begin);
                soundPlayer.Stream.Write(buffer, 0, buffer.Length);
                soundPlayer.Play();
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var word = (dataGrid.SelectedItem as WordDTO);
                if (word.Sound != null)
                {
                    Utils.Helper.PlaySoundFromBytes(word.Sound, word.WordEng);
                }           
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        private void UncheckAllWords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MaterialMessageBox.ShowWithCancel("Do you want to change status of all words in this dictionary to unlearned?");
                if (result == MessageBoxResult.OK)
                {
                    _dal.SetToWordsStatusAsUnlearned(selectedDictionaryId);
                    dataGrid.ItemsSource = null;
                    dataGrid.ItemsSource = _dal.GetWords(selectedDictionaryId);
                }
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
    }
}
