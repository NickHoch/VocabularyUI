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
    public partial class DeleteDictionaryWindow : MetroWindow
    {
        private IDal _dal = null;
        private int userId = 0;
        private int selectedDictionaryId = 0;
        private string selectedDictionaryName = String.Empty;
        public DeleteDictionaryWindow(IDal _dal, int userId)
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
                selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
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
            catch(Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void DeleteDictionary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBox.SelectedItem == null)
                {
                    MaterialMessageBox.ShowError("Please choose dictionary to delete");
                }
                else
                {
                    var res = _dal.DeleteDictionary(selectedDictionaryId);
                    Helper.log.Info($"User with id: {userId} has deleted dictionary: {(comboBox.SelectedValue as DictionaryDTO).Name}");
                    if (res)
                    {
                        this.Close();
                    }
                    else
                    {
                        string error = "Removal procedure ended accidentally";
                        Helper.log.Error(error);
                        MaterialMessageBox.ShowError(error);
                    }
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
