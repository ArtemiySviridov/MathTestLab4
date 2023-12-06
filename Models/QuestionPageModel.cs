using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTestLab4.Models
{
    internal class QuestionPageModel : Question
    {
        public string UserAnswer { get; set; }

        public QuestionPageModel(Question question)
        {
            Text = question.Text;
            Answers = question.Answers;
            CorrectAnswer = question.CorrectAnswer;
        }
    }
}
