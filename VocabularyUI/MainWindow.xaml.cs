using MahApps.Metro.Controls;
using System.Windows;
using VocabularyUI.UserControls;
using DAL;
using System;

namespace VocabularyClient
{
    public partial class MainWindow : MetroWindow
    {
        private SignIn signIn = null;
        private ServerDAL _dal = new ServerDAL();
        public static Random rand = new Random();
        public MainWindow()
        {
            InitializeComponent();
            signIn = new SignIn(_dal);
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            //signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }
        private void SignUpButton(object sender, RoutedEventArgs e)
        {
            var signUp = new SignUp(_dal);
            contentControl.Content = signUp;
            e.Handled = true;
            signUp.AddHandler(SignUp.ContinueClick, new RoutedEventHandler(ContinueButton));
            signUp.AddHandler(SignUp.CancelClick, new RoutedEventHandler(CancelButton));
        }
        //private void LoginButton(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            signIn = new SignIn(_dal);
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            //signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            signIn = new SignIn(_dal);
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            //signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
