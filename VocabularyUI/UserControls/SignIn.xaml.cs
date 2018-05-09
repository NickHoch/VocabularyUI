﻿using System;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using BespokeFusion;
using DAL;
using DAL.DTOs;
using VocabularyUI.Windows;

namespace VocabularyUI.UserControls
{
    public partial class SignIn : UserControl
    {
        private ServerDAL _dal = null;
        public SignIn(ServerDAL _dal)
        {
            InitializeComponent();
            this._dal = _dal;
        }

        public static readonly RoutedEvent SignUpClick =
        EventManager.RegisterRoutedEvent("SignUpClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignIn));

        public event RoutedEventHandler ClickEvent
        {
            add { AddHandler(SignIn.SignUpClick, value); }
            remove { RemoveHandler(SignIn.SignUpClick, value); }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SignIn.SignUpClick, this));
        }

        public static readonly RoutedEvent LoginClick =
        EventManager.RegisterRoutedEvent("LoginClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignIn));

        public event RoutedEventHandler ClickEvent2
        {
            add { AddHandler(SignIn.LoginClick, value); }
            remove { RemoveHandler(SignIn.LoginClick, value); }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(loginField.Text) || String.IsNullOrEmpty(passwordField.Password))
                {
                    MaterialMessageBox.ShowError("Please, fill in all login details.");
                }
                else
                {
                    string msgErr = String.Empty;
                    string pattern = @"^\w+.*,*@\w+[.]\w+$";
                    var regex = new Regex(pattern);
                    var match = regex.Match(loginField.Text);
                    if (!match.Success)
                    {
                        msgErr = "Invalid email address\n";
                        loginField.Text = String.Empty;
                        passwordField.Password = String.Empty;
                    }

                    pattern = @"\w$";
                    regex = new Regex(pattern);
                    match = regex.Match(passwordField.Password);
                    if (!match.Success)
                    {
                        msgErr = String.Concat(msgErr, "Password must contain only numbers and letters\n");
                        passwordField.Password = String.Empty;
                    }

                    if (String.IsNullOrEmpty(msgErr))
                    {
                        CredentialDTO credentialDTO = new CredentialDTO
                        {
                            Email = loginField.Text,
                            Password = passwordField.Password
                        };
                        var userId = _dal.GetUserIdByCredential(credentialDTO);
                        if (userId.HasValue)
                        {
                            var menuWindow = new MenuWindow(_dal, (int)userId);
                            menuWindow.Show();
                            RaiseEvent(new RoutedEventArgs(SignIn.LoginClick, this));
                        }
                        else
                        {
                            MaterialMessageBox.ShowError("Invalid login credentials. Please, try again.");
                            loginField.Text = String.Empty;
                            passwordField.Password = String.Empty;
                        }
                    }
                    else
                    {
                        MaterialMessageBox.ShowError(msgErr);
                    }
                }
            }
            catch (FaultException ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
            catch(Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }

    }
}
