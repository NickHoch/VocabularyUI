using MahApps.Metro.Controls;
using System.Windows;
using VocabularyUI.UserControls;
using DAL;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.IsolatedStorage;
using System.IO;
using DAL.DTOs;

namespace VocabularyClient
{
    public partial class MainWindow : MetroWindow
    {
        private SignIn signIn = null;
        private SignUp signUp = null;
        private Menu menu = null;
        private ServerDAL _dal = new ServerDAL();
        public static Random rand = new Random();
        private IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
        public MainWindow()
        {
            InitializeComponent();
            BinaryFormatter formatter = new BinaryFormatter();
            CredentialDTO credential = new CredentialDTO();

            using (var stream = store.OpenFile("credential.cfg", FileMode.OpenOrCreate, FileAccess.Read))
            {
                if(stream.Length != 0)
                {
                    credential = (CredentialDTO)formatter.Deserialize(stream);
                }                
            }
            var userId = _dal.GetUserIdByCredential(credential);
            if (userId.HasValue)
            {
                menu = new Menu(_dal, (int)userId);
                contentControl.Content = menu;
                menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
                menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
            }
            else
            {
                signIn = new SignIn(_dal);
                contentControl.Content = signIn;
                signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
                signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
            }         
        }
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            if(signIn.rememberChk.IsChecked == true)
            {
                CredentialDTO credential = new CredentialDTO
                {
                    Email = signIn.loginField.Text,
                    Password = signIn.passwordField.Password
                };
                BinaryFormatter formatter = new BinaryFormatter();
                using (var stream = store.OpenFile("credential.cfg", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    formatter.Serialize(stream, credential);
                }
            }
            menu = new Menu(_dal, (int)signIn.userId);
            contentControl.Content = menu;
            menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
            menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
        }
        private void SignUpButton(object sender, RoutedEventArgs e)
        {
            signUp = new SignUp(_dal);
            contentControl.Content = signUp;
            signUp.AddHandler(SignUp.CancelClick, new RoutedEventHandler(CancelButton));
            signUp.AddHandler(SignUp.ContinueClick, new RoutedEventHandler(ContinueButton));
        }
        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            menu = new Menu(_dal, (int)signUp.userId);
            contentControl.Content = menu;
            menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
            menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            signIn = new SignIn(_dal);
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LogOutButton(object sender, RoutedEventArgs e)
        {
            store.DeleteFile("credential.cfg");
            signIn = new SignIn(_dal);
            contentControl.Content = signIn;
            signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
            signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
        }
    }
}
