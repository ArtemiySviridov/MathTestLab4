using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTestLab4.Models
{
    internal class EnterDataModel
    {
        public int NumberOfQuestions { get; set; }
        public int CompletionPercentage { get; set; }

        public EnterDataModel(int numberOfQuestions, int completionPercentage)
        {
            NumberOfQuestions = numberOfQuestions;
            CompletionPercentage = completionPercentage;
        }
    }
}
