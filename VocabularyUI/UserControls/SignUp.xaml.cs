﻿using BespokeFusion;
using DAL;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using DAL.DTOs;
using VocabularyUI.Windows;
using System.IO;

namespace VocabularyUI.UserControls
{
    public partial class SignUp : UserControl
    {
        private ServerDAL _dal = null;
        public int? userId = null;
        public SignUp(ServerDAL _dal)
        {
            InitializeComponent();
            this._dal = _dal;
        }

        public static readonly RoutedEvent ContinueClick =
        EventManager.RegisterRoutedEvent("ContinueClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignUp));
        public event RoutedEventHandler ClickEvent
        {
            add { AddHandler(SignUp.ContinueClick, value); }
            remove { RemoveHandler(SignUp.ContinueClick, value); }
        }

        public static readonly RoutedEvent CancelClick =
        EventManager.RegisterRoutedEvent("CancelClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignUp));
        public event RoutedEventHandler ClickEvent2
        {
            add { AddHandler(SignUp.CancelClick, value); }
            remove { RemoveHandler(SignUp.CancelClick, value); }
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string msgErr = String.Empty;
                string pattern = @"^\w+.*,*@\w+.\w+$";
                var regex = new Regex(pattern);
                var match = regex.Match(loginField.Text);
                if (!match.Success)
                {
                    msgErr = "Invalid email address\n";
                    loginField.Text = String.Empty;
                }
                if (String.IsNullOrEmpty(msgErr))
                {
                    var res = _dal.IsEmailAddressFree(loginField.Text);
                    if (res)
                    {
                        msgErr = String.Concat(msgErr, "Email address already exists. Please, re-enter email address");
                        loginField.Text = String.Empty;
                    }
                }

                pattern = @"\w$";
                regex = new Regex(pattern);
                match = regex.Match(passwordField.Password);
                if (!match.Success)
                {
                    msgErr = String.Concat(msgErr, "Password must contain only numbers and letters\n");
                }
                if (passwordField.Password.Length < 6)
                {
                    msgErr = String.Concat(msgErr, "Password must be at least 6 characters\n");
                }
                if (passwordField.Password.Length > 20)
                {
                    msgErr = String.Concat(msgErr, "Password must be no more than 20 characters\n");
                }
                if (passwordField.Password != confirmPasswordField.Password)
                {
                    msgErr = String.Concat(msgErr, "Password do not match\n");
                }
                if (String.IsNullOrEmpty(msgErr))
                {
                    CredentialDTO credentialDTO = new CredentialDTO
                    {
                        Email = loginField.Text,
                        Password = passwordField.Password
                    };
                    var res = _dal.AddUser(credentialDTO);
                    if(res)
                    {
                        userId = _dal.GetUserIdByCredential(credentialDTO);
                        RaiseEvent(new RoutedEventArgs(SignUp.ContinueClick, this));
                    }
                }
                else
                {
                    MaterialMessageBox.ShowError(msgErr);
                    passwordField.Password = String.Empty;
                    confirmPasswordField.Password = String.Empty;
                }
            }
            catch (FaultException ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.ShowError(ex.Message);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SignUp.CancelClick, this));
        }
    }
}
