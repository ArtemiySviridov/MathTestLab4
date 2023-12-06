using MathTestLab4.Commands;
using MathTestLab4.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MathTestLab4.ViewModels
{
    internal class EnterWindowViewModel : ViewModelBase
    {
        private ObservableCollection<int> _numberOfQuestions;
        private int _selectedQuestionNumber;
        private ObservableCollection<int> _completionPercentages;
        private int _selectedCompletionPercentage;

        public EnterWindowViewModel()
        {
            _numberOfQuestions = new ObservableCollection<int> { 0, 1, 2, 3, 4, 5 };
            _completionPercentages = new ObservableCollection<int> { 100, 80, 60, 40, 20 };

            SelectedQuestionNumber = _numberOfQuestions[0];
            SelectedCompletionPercentage = _completionPercentages[0];
        }

        public ObservableCollection<int> NumbersOfQuestions
        {
            get { return _numberOfQuestions; }
            set { Set(ref _numberOfQuestions, value); }
        }

        public int SelectedQuestionNumber
        {
            get { return _selectedQuestionNumber; }
            set
            {
                if (_selectedQuestionNumber != value)
                {
                    _selectedQuestionNumber = value;
                    OnPropertyChanged(nameof(SelectedQuestionNumber));
                }
            }
        }

        public ObservableCollection<int> CompletionPercentage
        {
            get { return _completionPercentages; }
            set { Set(ref _completionPercentages, value); }
        }

        public int SelectedCompletionPercentage
        {
            get { return _selectedCompletionPercentage; }
            set
            {
                if (_selectedCompletionPercentage != value)
                {
                    _selectedCompletionPercentage = value;
                    OnPropertyChanged(nameof(SelectedCompletionPercentage));
                }
            }
        }

        private ICommand _openMainWindowCommand;

        public ICommand OpenMainWindowCommand
        {
            get
            {
                if (_openMainWindowCommand == null)
                {
                    _openMainWindowCommand = new RelayCommand(OpenMainWindow);
                }
                return _openMainWindowCommand;
            }
        }

        private void OpenMainWindow()
        {
            MainWindow testMainWindow = new MainWindow();
            testMainWindow.DataContext = new MainWindowViewModel(_selectedQuestionNumber, _selectedCompletionPercentage);
            testMainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            testMainWindow.Show();
        }
    }
}
