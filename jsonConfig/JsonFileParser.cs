using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathTestLab4.Models;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace MathTestLab4.jsonConfig
{
    public static class JsonFileParser
    {

        static readonly string path = "C:\\Users\\User\\Desktop\\поучиться\\Лабы инфа\\Programming2\\Lab4\\MathTestLab4\\jsonConfig\\questions.json";

        public static ObservableCollection<Question> LoadQuestionsList(string filePath)
        {
            string jsonContent = System.IO.File.ReadAllText(filePath);


            JObject jsonObject = JObject.Parse(jsonContent);

            JArray questionsArray = (JArray)jsonObject["Questions"];

            IList<Question> questions = questionsArray.ToObject<IList<Question>>();

            var questionsCollection = new ObservableCollection<Question>();

            foreach (var quest in questions) 
            {
                questionsCollection.Add(quest);
            }

            return questionsCollection;
        }
    }
}
