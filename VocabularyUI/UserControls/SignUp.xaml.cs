using BespokeFusion;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VocabularyUI.UserControls
{
    public partial class SignUp : UserControl
    {
        private readonly ServerDAL _dal = new ServerDAL();
        public SignUp()
        {
            InitializeComponent();
        }

        public static readonly RoutedEvent ContinueClick =
        EventManager.RegisterRoutedEvent("ContinueClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignUp));

        public event RoutedEventHandler ClickEvent
        {
            add { AddHandler(SignUp.ContinueClick, value); }
            remove { RemoveHandler(SignUp.ContinueClick, value); }
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
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
                                //vocabularyContext.Credentials.Add(new Credential { Email = loginField.Text, Password = passwordField.Password });
                //vocabularyContext.SaveChanges();
                //var userId = vocabularyContext.Credentials.Where(x => x.Email == loginField.Text && x.Password == passwordField.Password).Select(x => x.Id).SingleOrDefault();
                //vocabularyContext.Dictionaries.Add(new Dictionary { Name = "Animals", UserId = userId });
                //vocabularyContext.SaveChanges();
                //var dictionaryId = vocabularyContext.Dictionaries.Where(x => x.Name == "Animals" && x.UserId == userId).Select(x => x.Id).SingleOrDefault();
                //vocabularyContext.Words.AddRange(
                //    new List<Word>
                //    {
                //        new Word
                //        {
                //            WordEng = "cat",
                //            Transcription = "|kæt|",
                //            Translation = "кіт",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/cat.jpg"),
                //            Sound = File.ReadAllBytes("Sound/cat.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "dog",
                //            Transcription = "|dɔːɡ|",
                //            Translation = "пес",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/dog.jpg"),
                //            Sound = File.ReadAllBytes("Sound/dog.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "bear",
                //            Transcription = "|ber|",
                //            Translation = "ведмідь",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/bear.jpeg"),
                //            Sound = File.ReadAllBytes("Sound/bear.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "penguin",
                //            Transcription = "|ˈpeŋɡwɪn|",
                //            Translation = "пінгвін",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/penguin.png"),
                //            Sound = File.ReadAllBytes("Sound/penguin.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "parrot",
                //            Transcription = "|ˈpærət|",
                //            Translation = "папуга",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/parrot.png"),
                //            Sound = File.ReadAllBytes("Sound/parrot.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "donkey",
                //            Transcription = "|ˈdɔːŋki|",
                //            Translation = "осел",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/donkey.jpg"),
                //            Sound = File.ReadAllBytes("Sound/donkey.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "rat",
                //            Transcription = "|ræt|",
                //            Translation = "пацюк",
                //            DictionaryId = dictionaryId,
                //              Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/rat.png"),
                //            Sound = File.ReadAllBytes("Sound/rat.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "mosquito",
                //            Transcription = "|məˈskiːtoʊ|",
                //            Translation = "комар",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/mosquito.jpg"),
                //            Sound = File.ReadAllBytes("Sound/mosquito.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "fox",
                //            Transcription = "|fɑːks|",
                //            Translation = "лисиця",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/fox.png"),
                //            Sound = File.ReadAllBytes("Sound/fox.mp3")
                //        },
                //        new Word
                //        {
                //            WordEng = "ratel",
                //            Transcription = "|ˈreɪt(ə)l|",
                //            Translation = "медоїд",
                //            DictionaryId = dictionaryId,
                //            Image = File.ReadAllBytes($"{Environment.CurrentDirectory}/Image/ratel.jpg"),
                //            Sound = File.ReadAllBytes("Sound/ratel.mp3")
                //        }
                //    });
                //vocabularyContext.SaveChanges();
                //var menuWindow = new MenuWindow(vocabularyContext, userId);
                //menuWindow.Show();
                //RaiseEvent(new RoutedEventArgs(SignUp.ContinueClick, this));
            }
            else
            {
                MaterialMessageBox.ShowError(msgErr);
                passwordField.Password = String.Empty;
                confirmPasswordField.Password = String.Empty;
            }
        }

        public static readonly RoutedEvent CancelClick =
        EventManager.RegisterRoutedEvent("CancelClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignUp));

        public event RoutedEventHandler ClickEvent2
        {
            add { AddHandler(SignUp.CancelClick, value); }
            remove { RemoveHandler(SignUp.CancelClick, value); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SignUp.CancelClick, this));
        }
    }
}
