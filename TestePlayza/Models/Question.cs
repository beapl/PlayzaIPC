using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playza.Models // Atenção: muda para o nome do teu projeto!
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
