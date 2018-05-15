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
    public partial class AddDictonaryWindow : MetroWindow
    {
        private ServerDAL _dal = null;
        private int userId = 0;
        public AddDictonaryWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
        }
        private void AddDictionary_Click(object sender, RoutedEventArgs e)
        {
            if (_dal.IsDictionaryNameExists(nameField.Text, userId))
            {
                MaterialMessageBox.ShowError("Dictionary with this name already exists. Please re-enter name of the dictionary");
                nameField.Text = String.Empty;
            }
            else if (String.IsNullOrWhiteSpace(nameField.Text))
            {
                MaterialMessageBox.ShowError("Please fill in name of the dictionary");
            }
            else
            {
                var newDictionaey = new DictionaryExtnDTO
                {
                    Name = nameField.Text
                };
                _dal.AddDictionary(newDictionaey, userId);
                this.Close();
            }
        }
    }
}
