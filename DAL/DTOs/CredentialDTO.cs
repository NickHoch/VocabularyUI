using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class CredentialDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<DictionaryExtnDTO> Dictionaries { get; set; }
    }
}
