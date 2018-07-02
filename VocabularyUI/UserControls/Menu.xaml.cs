using BespokeFusion;
using DAL;
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
using VocabularyUI.Utils;
using VocabularyUI.Windows;

namespace VocabularyUI.UserControls
{
    public partial class Menu : UserControl
    {
        private int userId;
        private ServerDAL _dal = null;
        public Menu(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
        }
        public static readonly RoutedEvent ExitClick = EventManager.RegisterRoutedEvent(
            "ExitClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));
        public event RoutedEventHandler ClickEvent
        {
            add { AddHandler(Menu.ExitClick, value); }
            remove { RemoveHandler(Menu.ExitClick, value); }
        }
        public static readonly RoutedEvent LogOutClick = EventManager.RegisterRoutedEvent(
            "LogOutClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));
        public event RoutedEventHandler ClickEvent2
        {
            add { AddHandler(Menu.LogOutClick, value); }
            remove { RemoveHandler(Menu.LogOutClick, value); }
        }
        private void StartLearn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectDictionaryWindow = new SelectDictionaryWindow(_dal, userId);
                selectDictionaryWindow.Show();
                Helper.log.Info($"User with id {userId} start to learn words");
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void AddDictionary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var addDictionaryWindow = new AddDictonaryWindow(_dal, userId);
                addDictionaryWindow.Show();
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }            
        }
        private void EditWords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editWordsWindow = new EditWordsWindow(_dal, userId);
                editWordsWindow.Show();
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }           
        }
        private void EditDictionaryName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var editDictionaryName = new EditDictonaryNameWindow(_dal, userId);
                editDictionaryName.Show();
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }          
        }
        private void DeleteDictionary_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var deleteDictionaryWindow = new DeleteDictionaryWindow(_dal, userId);
                deleteDictionaryWindow.Show();
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }           
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Helper.log.Info($"User with id {userId} log out");
                RaiseEvent(new RoutedEventArgs(Menu.ExitClick, this));
            }
            catch (Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }            
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Helper.log.Info($"User with id {userId} log out");
                RaiseEvent(new RoutedEventArgs(Menu.LogOutClick, this));
            }
            catch(Exception ex)
            {
                Helper.log.Error(ex.ToString());
                MaterialMessageBox.ShowError(ex.ToString());
            }           
        }
    }
}
