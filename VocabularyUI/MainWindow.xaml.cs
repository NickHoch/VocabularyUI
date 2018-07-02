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
using System.Linq;

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
        private DispatcherTimer popupTimer;
        //autorun
        private string path;
        private string fileName;
        public bool IsLearningWindowClosed = true;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                //autorun
                GetExeLocation();
                PutAppToStartUpFolder(fileName, path);

                ResizeMode = ResizeMode.NoResize;
                StartApp();
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

        #region
        //mathods put app in autorun folder
        public void GetExeLocation()
        {
            try
            {
                path = Assembly.GetEntryAssembly().Location;
                fileName = Assembly.GetExecutingAssembly().GetName().Name;
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        public void PutAppToStartUpFolder(string filename, string filepath)
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
        private void StartApp()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            CredentialDTO credential = new CredentialDTO();
            using (var stream = store.OpenFile("credential.cfg", FileMode.OpenOrCreate, FileAccess.Read)) // this snipet of the code checks the user credential file and decides how to start the app
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
                StartCounting((int)userId);
            }
            else
            {
                signIn = new SignIn(_dal);
                contentControl.Content = signIn;
                signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
                signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
            }
        }
        public async void StartCounting(int userId)
        {
            var dictionaryId = _dal.IsLearningProcessActive(userId);
            while (dictionaryId != null)
            {
                await Task.Delay(new TimeSpan(0, 0, 5));
                if (IsLearningWindowClosed)
                {
                    var learningWindow = new LearningWindow(_dal, userId, (int)dictionaryId);
                    learningWindow.Show();
                    IsLearningWindowClosed = false;
                }
                dictionaryId = _dal.IsLearningProcessActive(userId);
                //popupTimer = new DispatcherTimer();

                //// Work out interval as time you want to popup - current time
                //popupTimer.Interval = new DateTime(2018, 7, 2, 22, 55, 0) - DateTime.Now;
                //popupTimer.IsEnabled = true;
                //popupTimer.Tick += new EventHandler(popupTimer_Tick);
            }
            //Thread thread = new Thread(() =>
            //{
            //    var dictionaryId = _dal.IsLearningProcessActive(userId);
            //    var learningWindow = new LearningWindow(_dal, userId, (int)dictionaryId);
            //    learningWindow.Show();
            //    learningWindow.Closed += (sender1, e1) => learningWindow.Dispatcher.InvokeShutdown();

            //    System.Windows.Threading.Dispatcher.Run();

            //});
            //thread.SetApartmentState(ApartmentState.STA);
            //thread.IsBackground = true;
            //thread.Start();
        }
        //private void popupTimer_Tick(object sender, EventArgs e)
        //{
        //    popupTimer.IsEnabled = false;
        //    // Show popup
        //    // ......
        //}
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
                menu = new Menu(_dal, (int)signIn.userId);
                contentControl.Content = menu;
                menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
                menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
                //StartCounting((int)signUp.userId);
            }
            catch (Exception ex)
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
                //StartCounting((int)signUp.userId);
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
        // methods closes app. It doesn`t hide app in tray
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        // method deletes user`s config file with cedential
        private void LogOutButton(object sender, RoutedEventArgs e)
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
