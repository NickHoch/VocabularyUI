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
    /// <summary>
    /// Interaction logic for EditDictonaryNameWindow.xaml
    /// </summary>
    public partial class EditDictonaryNameWindow : MetroWindow
    {

        private ServerDAL _dal = null;
        private int userId = 0;
        private int selectedDictionaryId = 0;
        private string selectedDictionaryName = String.Empty;
        public EditDictonaryNameWindow(ServerDAL _dal, int userId)
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
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            selectedDictionaryId = (int)(comboBox.SelectedValue as DictionaryDTO).Id;
        }
        private void UpdateDictionaryName_Click(object sender, RoutedEventArgs e)
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
                _dal.UpdateDictionary(selectedDictionaryId, nameField.Text);
                try
                {
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
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    dictNameCmb.SelectionChanged += ComboBox_SelectionChanged;
                }
            }
        }
    }
}
