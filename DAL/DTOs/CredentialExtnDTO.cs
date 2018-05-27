using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    [Serializable]
    public class CredentialExtnDTO : CredentialDTO
    {
        public ICollection<DictionaryExtnDTO> Dictionaries { get; set; }
        public CredentialExtnDTO() { }
    }
}