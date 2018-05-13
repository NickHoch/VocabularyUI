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
        public static readonly RoutedEvent ExitClick =
        EventManager.RegisterRoutedEvent("ExitClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));
        public event RoutedEventHandler ClickEvent
        {
            add { AddHandler(Menu.ExitClick, value); }
            remove { RemoveHandler(Menu.ExitClick, value); }
        }
        public static readonly RoutedEvent LogOutClick =
        EventManager.RegisterRoutedEvent("LogOutClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Menu));
        public event RoutedEventHandler ClickEvent2
        {
            add { AddHandler(Menu.LogOutClick, value); }
            remove { RemoveHandler(Menu.LogOutClick, value); }
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var startLearnWindow = new StartLearnWindow(_dal, userId);
            startLearnWindow.Show();
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            //var newDictionaryWindow = new NewDictionaryWindow(userId);
            //newDictionaryWindow.Show();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EditWindow(_dal, userId);
            editWindow.Show();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //var deleteDictionaryWindow = new DeleteDictionaryWindow(userId);
            //deleteDictionaryWindow.Show();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Menu.ExitClick, this));
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Menu.LogOutClick, this));
        }
    }
}
