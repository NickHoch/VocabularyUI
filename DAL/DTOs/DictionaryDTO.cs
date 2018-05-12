using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class DictionaryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CredentialDTO Credential { get; set; }
        public ICollection<WordDTO> Words { get; set; }
    }
}
