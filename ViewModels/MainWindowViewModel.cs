using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathTestLab4.Models;
using MathTestLab4.jsonConfig;
using Newtonsoft.Json;
using MathTestLab4.Commands;
using System.Windows.Input;

namespace MathTestLab4.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private int _currentPage = 0;
        private ObservableCollection<QuestionPageModel> questionPages;
        public ObservableCollection<QuestionPageModel> QuestionPages
        {
            get { return questionPages; }
            set
            {
                if (questionPages != value)
                {
                    questionPages = value;
                    OnPropertyChanged(nameof(QuestionPages));
                }
            }
        }

        private QuestionPageModel _currentQ;
        public QuestionPageModel CurrentQ
        {
            get 
            {
                return _currentQ; 
            }
            set
            {
                if (_currentQ != value)
                {
                    _currentQ = value;
                    OnPropertyChanged(nameof(CurrentQ));
                }
            }
        }

        //public string YourViewModelProperty
        //{
        //    get { return yourViewModelProperty; }
        //    set
        //    {
        //        if (yourViewModelProperty != value)
        //        {
        //            yourViewModelProperty = value;
        //            OnPropertyChanged(nameof(YourViewModelProperty));
        //        }
        //    }
        //}


        private string _selectedUserAnswer;

        public MainWindowViewModel(int quantity, int percentage)
        {
            ObservableCollection<Question> allQuestions = JsonFileParser.LoadQuestionsList("C:\\Users\\User\\Desktop\\поучиться\\Лабы инфа\\Programming2\\Lab4\\MathTestLab4\\jsonConfig\\questions.json");
            var random = new Random();

            var randomQuestions = allQuestions.OrderBy(x => random.Next()).Take(quantity);

            QuestionPages = new ObservableCollection<QuestionPageModel>();

            foreach (var question in randomQuestions) 
            {
                var questionPage = new QuestionPageModel(question);
                QuestionPages.Add(questionPage);
            }

            CurrentQ = QuestionPages[_currentPage];
        }

        public string UserAnswer
        {
            get { return _selectedUserAnswer; }
            
            set
            {
                if (_selectedUserAnswer != value)
                {
                    _selectedUserAnswer = value;
                    OnPropertyChanged(nameof(UserAnswer));
                }
            }
        }
        
        void NextQuestion()
        {  
            if (_currentPage < QuestionPages.Count - 1) 
            {
                _currentQ = QuestionPages.ElementAt(_currentPage + 1);
                _currentPage++;
            }
        }

        private ICommand _goToNextQuestionCommand;
        public ICommand GoToNextQuestionCommand
        {
            get
            {
                if (_goToNextQuestionCommand == null)
                {
                    _goToNextQuestionCommand = new RelayCommand(NextQuestion);
                }
                return _goToNextQuestionCommand;
            }
        }
    }

}
