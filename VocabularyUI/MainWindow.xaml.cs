using BespokeFusion;
using DAL;
using DAL.DTOs;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Windows;
using System.Windows.Threading;
using VocabularyUI.UserControls;
using VocabularyUI.Utils;
using VocabularyUI.Windows;
using Ninject;

namespace VocabularyClient
{
    public partial class MainWindow : MetroWindow
    {
        private SignIn signIn;
        private SignUp signUp;
        private Menu menu;
        private int? userId;
        private IDal _dal;
        public static Random rand = new Random();
        private IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForAssembly();
        public DispatcherTimer popupTimer= new DispatcherTimer();
        //autorun
        private string path;
        private string fileName;
        public bool IsLearningWindowClosed = true;
        public MainWindow(IDal dal)
        {
            try
            {
                MessageBox.Show("test");
                _dal = dal;
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
            userId = _dal.GetUserIdByCredential(credential);
            if (userId.HasValue)
            {
                Helper.log.Info($"Login: {credential.Email} Password: {credential.Password} UserId: {userId} entered in the app");
                menu = new Menu(_dal, (int)userId);
                contentControl.Content = menu;
                menu.AddHandler(Menu.ExitClick, new RoutedEventHandler(ExitButton));
                menu.AddHandler(Menu.LogOutClick, new RoutedEventHandler(LogOutButton));
                PopupTimerStart();
            }
            else
            {
                signIn = new SignIn(_dal);
                contentControl.Content = signIn;
                signIn.AddHandler(SignIn.SignUpClick, new RoutedEventHandler(SignUpButton));
                signIn.AddHandler(SignIn.LoginClick, new RoutedEventHandler(LoginButton));
            }
        }
        private void PopupTimerStart()
        {
            popupTimer.Interval = new TimeSpan(0, 0, 5);
            popupTimer.Tick += new EventHandler(PopupTimer_Tick);
            popupTimer.Start();
        }
        private void PopupTimer_Tick(object sender, EventArgs e)
        {
            _dal.ChangeOutstandingWords((int)userId);
            var words =_dal.GetWordsToRepeat((int)userId);
            if(words.Count > 0)
            {
                popupTimer.Stop();
                var learningWindow = new LearningWindow(_dal, (int)userId, true);
                learningWindow.Show();
                IsLearningWindowClosed = false;
            }
            else
            {
                var dictionaryId = _dal.IsLearningProcessActive((int)userId);
                if (IsLearningWindowClosed && dictionaryId.HasValue)
                {
                    popupTimer.Stop();
                    var learningWindow = new LearningWindow(_dal, (int)userId, false, (int)dictionaryId);
                    learningWindow.Show();
                    IsLearningWindowClosed = false;
                }
            }
        }
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
                PopupTimerStart();
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
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                Helper.log.Error($"Exception: {ex.ToString()}");
                MaterialMessageBox.ShowError(ex.ToString());
            }
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
