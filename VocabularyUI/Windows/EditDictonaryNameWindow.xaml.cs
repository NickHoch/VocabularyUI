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
using VocabularyUI.Utils;

namespace VocabularyUI.Windows
{
    /// <summary>
    /// Interaction logic for EditDictonaryNameWindow.xaml
    /// </summary>
    public partial class EditDictonaryNameWindow : MetroWindow
    {

        private IDal _dal = null;
        private int userId = 0;
        private int selectedDictionaryId = 0;
        private string selectedDictionaryName = String.Empty;
        public EditDictonaryNameWindow(IDal _dal, int userId)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            this._dal = _dal;
            this.userId = userId;
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
                selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void UpdateDictionaryName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dictNameCmb.SelectedItem == null)
                {
                    MaterialMessageBox.ShowError("Please choose dictionary to update");
                }
                else if (nameField.Text == String.Empty)
                {
                    MaterialMessageBox.ShowError("Please enter new name of the dictionary");
                }
                else if (_dal.IsDictionaryNameExists(nameField.Text, userId))
                {
                    MaterialMessageBox.ShowError("Dictionary with the name you entered exists. Please enter another name");
                }
                else
                {
                    try
                    {
                        _dal.UpdateDictionary(selectedDictionaryId, nameField.Text);
                        int currentValue = -1;
                        if (dictNameCmb.SelectedValue != null)
                        {
                            currentValue = (int)(dictNameCmb.SelectedValue as DictionaryDTO).Id;
                        }
                        dictNameCmb.SelectionChanged -= ComboBox_SelectionChanged;
                        var ds = _dal.GetDictionariesBaseInfo(userId);
                        dictNameCmb.ItemsSource = ds;
                        dictNameCmb.DisplayMemberPath = "Name";
                        if (currentValue != -1)
                        {
                            dictNameCmb.SelectedValue = currentValue;
                        }
                        dictNameCmb.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        Helper.log.Error(ex.ToString());
                        MaterialMessageBox.ShowError(ex.ToString());
                    }
                    finally
                    {
                        Helper.log.Info($"User with id: {userId} has update dictionary name. Dictionary id: {(dictNameCmb.SelectedValue as DictionaryDTO).Id} New name: {nameField.Text}");
                        dictNameCmb.SelectionChanged += ComboBox_SelectionChanged;
                    }
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
