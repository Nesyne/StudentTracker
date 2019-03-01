using Xamarin.Forms;
using System.Windows.Input;
using StudentTracker.Views;
using System.Collections.ObjectModel;
using StudentTracker.Models;
using System.Threading.Tasks;
using StudentTracker.Services;
using System;
using System.Diagnostics;

namespace StudentTracker.ViewModels
{
    public class BehaviorLandingViewModel:BaseViewModel
    {
        private const string V = "Beval";
        INavigation _navigation;
        Student _student;
        ClassPeriod _classPeriod;
        DataAccess _dataAccess;

        public Command LoadDataSourcesCommand { get; set; }

        public ICommand OpenBehaviorPageCommand { get; }

        public ICommand OpenEvaluationPageCommand { get; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<ClassPeriod> ClassPeriods { get; set; }


        public BehaviorLandingViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = V;

            _dataAccess = new DataAccess();

            LoadDataSourcesCommand = new Command(async () => await ExecuteLoadDataSourcesCommand());

            OpenBehaviorPageCommand = new Command(OnBehaviorTapped, CanExecuteTapped);

            OpenEvaluationPageCommand = new Command(OnEvaluationTapped, CanExecuteTapped);

            LoadDataSourcesCommand.Execute(null);
        }
        public bool IsEnabled
        {
            get { return Student != null && ClassPeriod != null; }
        }

        public Student Student
        {
            get { return _student; }
            set
            {
                if (_student == value)
                    return;
                _student = value;
                OnPropertyChanged("Student");
            }
        }

        public ClassPeriod ClassPeriod
        {
            get { return _classPeriod; }
            set
            {
                if (_classPeriod == value)
                    return;
                _classPeriod = value;
                OnPropertyChanged("ClassPeriod");

            }
        }

        async Task ExecuteLoadDataSourcesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _dataAccess.GetAllCollections();

                Students = _dataAccess.Students;

                ClassPeriods = _dataAccess.ClassPeriods;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanExecuteTapped()
        {
            return IsEnabled;
        }

        async void OnBehaviorTapped()
        {
            await _navigation.PushModalAsync(new NavigationPage(new BehaviorPage(_student,_classPeriod,_dataAccess)));
        }

        async void OnEvaluationTapped()
        {
            await _navigation.PushAsync(new NavigationPage(new EvaluationPage(_student, _classPeriod, ClassPeriods)));
        }

    }
}
