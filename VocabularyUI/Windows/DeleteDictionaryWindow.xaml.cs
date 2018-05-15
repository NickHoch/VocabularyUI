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

namespace VocabularyUI.Windows
{
    public partial class DeleteDictionaryWindow : MetroWindow
    {
        private ServerDAL _dal = null;
        private int userId = 0;
        private int selectedDictionaryId = 0;
        private string selectedDictionaryName = String.Empty;
        public DeleteDictionaryWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
        }
        private void ComboBox_Load(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var res = _dal.GetDictionariesBaseInfo(userId);
            comboBox.DisplayMemberPath = "Name";
            comboBox.ItemsSource = res;
            comboBox.SelectedIndex = 0;
            selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
        }
        private void DeleteDictionary_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem == null)
            {
                MaterialMessageBox.ShowError("Please choose dictionary to delete");
            }
            else
            {
                var res = _dal.DeleteDictionary(selectedDictionaryId);
                if(res)
                {
                    this.Close();
                }
                else
                {
                    MaterialMessageBox.ShowError("Removal procedure ended accidentally");
                }
            }
        }
    }
}
