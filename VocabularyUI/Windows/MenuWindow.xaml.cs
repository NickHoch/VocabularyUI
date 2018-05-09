using MahApps.Metro.Controls;
using System.Windows;
using DAL;

namespace VocabularyUI.Windows
{
    public partial class MenuWindow : MetroWindow
    {
        private int userId;
        private ServerDAL _dal = null;
        public MenuWindow(ServerDAL _dal, int userId)
        {
            InitializeComponent();
            this._dal = _dal;
            this.userId = userId;
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
            //var editWindow = new EditWindow(userId);
            //editWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //var deleteDictionaryWindow = new DeleteDictionaryWindow(userId);
            //deleteDictionaryWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
