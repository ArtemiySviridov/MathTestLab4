using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MathTestLab4.Models
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }
    }
}
