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
using Microsoft.Win32;
using System.Threading.Tasks;
using System.ServiceModel;
using BespokeFusion;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using log4net;
using System.Reflection;
using VocabularyUI.Utils;
using System.Threading;
using System.Windows.Threading;
using VocabularyUI.Windows;

namespace VocabularyClient
{
    public class IdEventArgs : EventArgs
    {
        public readonly int id;
        public IdEventArgs(int id)
        {
            this.id = id;
        }
    }
    public partial class MainWindow : MetroWindow
    {
        private SignIn signIn;
        private SignUp signUp;
        private Menu menu;
        private ServerDAL _dal = new ServerDAL();
        public static Random rand = new Random();
        private IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
        //autorun
        private string path;
        private string fileName;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                //autorun
                GetExeLocation();
                StartExeWhenPcStartup(fileName, path);
                ResizeMode = ResizeMode.NoResize;
                BinaryFormatter formatter = new BinaryFormatter();
                CredentialDTO credential = new CredentialDTO();
                using (var stream = store.OpenFile("credential.cfg", FileMode.OpenOrCreate, FileAccess.Read)) // this snipet of the code checks for the file user`s credential and decides how to start app
                {
                    if (stream.Length != 0)
                    {
                        credential = (CredentialDTO)formatter.Deserialize(stream);
                    }
                }
                var userId = _dal.GetUserIdByCredential(credential);
                if (userId.HasValue)
                {
                    Helper.log.Info($"Login: {credential.Email} Password: {credential.Password} UserId: {userId} entered in the app");
                    menu = new Menu(_dal, (int)userId);
                    contentControl.Content = menu;
                    menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
                    menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
                    //StartCounting((int)userId);
                }
                else
                {
                    signIn = new SignIn(_dal);
                    contentControl.Content = signIn;
                    signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
                    signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
                }
                
            }
            catch (FaultException ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }

        //private void StartCounting(int userId)
        //{
        //    Thread.Sleep(10000);
        //    var thread = new Thread(ShowWindow);

        //    thread.SetApartmentState(ApartmentState.STA);

        //    thread.Start(userId);
        //    thread.Join();
        //}
        private async void StartCounting(int userId)
        {
            await Task.Delay(10000);
            //await Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(10000);
            //});
            ShowWindow(userId);
        }
        public void ShowWindow(object userid)
        {
            PopupWindow popupWindow = new PopupWindow();
            popupWindow.contentControl = new Card1(new WordDTO { WordEng = "test" });
            popupWindow.Show();
        }

        #region
        public void GetExeLocation() //mathods puts app in autorun folder
        {
            try
            {
                path = System.Reflection.Assembly.GetEntryAssembly().Location;
                fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        public void StartExeWhenPcStartup(string filename, string filepath)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                key.SetValue(filename, filepath);
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        #endregion
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (signIn.rememberChk.IsChecked == true) // method creates or refreshes user`s config file if checkbox is selected
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
                StartCounting((int)signUp.userId);
                menu = new Menu(_dal, (int)signIn.userId);
                contentControl.Content = menu;
                menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
                menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
            }
            catch(Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void SignUpButton(object sender, RoutedEventArgs e)
        {
            try
            {
                signUp = new SignUp(_dal);
                contentControl.Content = signUp;
                signUp.AddHandler(SignUp.CancelClick, new RoutedEventHandler(CancelButton));
                signUp.AddHandler(SignUp.ContinueClick, new RoutedEventHandler(ContinueButton));

            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void ContinueButton(object sender, RoutedEventArgs e)
        {
            try
            {
                menu = new Menu(_dal, (int)signUp.userId);
                contentControl.Content = menu;
                menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
                menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
                StartCounting((int)signUp.userId);
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void CancelButton(object sender, RoutedEventArgs e)
        {
            try
            {
                signIn = new SignIn(_dal);
                contentControl.Content = signIn;
                signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
                signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void ExitButton(object sender, RoutedEventArgs e) // methods closes app. Doesn`t hide app in tray
        {
            Application.Current.Shutdown();
        }
        private void LogOutButton(object sender, RoutedEventArgs e) // method deletes user`s config file with cedential
        {
            try
            {
                store.DeleteFile("credential.cfg");
                signIn = new SignIn(_dal);
                contentControl.Content = signIn;
                signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
                signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}
