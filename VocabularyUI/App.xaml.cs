using System.Windows;
using System.ComponentModel;
using BespokeFusion;
using System;

namespace VocabularyClient
{
    public partial class App : Application
    {
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isExit;

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);
                ShutdownMode = ShutdownMode.OnMainWindowClose;

                log4net.Config.XmlConfigurator.Configure();

                MainWindow = new MainWindow();
                MainWindow.Closing += MainWindow_Closing;
                _notifyIcon = new System.Windows.Forms.NotifyIcon();
                _notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
                _notifyIcon.Icon = VocabularyUI.Properties.Resources.icon;
                _notifyIcon.Visible = true;
                _notifyIcon.Text = "Vocabulary";
                CreateContextMenu();
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void CreateContextMenu()
        {
            try
            {
                _notifyIcon.ContextMenuStrip =
                  new System.Windows.Forms.ContextMenuStrip();
                _notifyIcon.ContextMenuStrip.Items.Add("Open...").Click += (s, e) => ShowMainWindow();
                _notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void ExitApplication()
        {
            try
            {
                _isExit = true;
                MainWindow.Close();
                _notifyIcon.Dispose();
                _notifyIcon = null;
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void ShowMainWindow()
        {
            try
            {
                if (MainWindow.IsVisible)
                {
                    if (MainWindow.WindowState == WindowState.Minimized)
                    {
                        MainWindow.WindowState = WindowState.Normal;
                    }
                    MainWindow.Activate();
                }
                else
                {
                    MainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (!_isExit)
                {
                    e.Cancel = true;
                    MainWindow.Hide();
                }
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.ToString());
            }
        }
    }
}
