using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    public class WordDTO
    {
        public int Id { get; set; }
        public string WordEng { get; set; }
        public string Transcription { get; set; }
        public string Translation { get; set; }
        public byte[] Sound { get; set; }
        public byte[] Image { get; set; }
        public List<Boolean> IsLearned = new List<Boolean>();
        public bool IsLearnedWord { get; set; } = false;
        public DictionaryDTO Dictionary { get; set; }
    }
}
