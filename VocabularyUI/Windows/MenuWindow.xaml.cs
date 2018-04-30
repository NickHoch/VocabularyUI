using MahApps.Metro.Controls;
using System.Windows;

namespace VocabularyUI.Windows
{
    public partial class MenuWindow : MetroWindow
    {
        private int userId;
        public MenuWindow(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //var startLearnWindow = new StartLearnWindow(userId);
            //startLearnWindow.Show();
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
