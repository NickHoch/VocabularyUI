﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServerDAL
    {
        private ServiceVocabulary.VocabularyClient vocabularyClient = new ServiceVocabulary.VocabularyClient();
        public int? CheckCredential(string login, string password)
        {
            return vocabularyClient.CheckCredential(login, password);
        }
        public bool IsEmailAddressFree(string email)
        {
            return vocabularyClient.IsEmailAddressFree(email);
        }
    }
}
