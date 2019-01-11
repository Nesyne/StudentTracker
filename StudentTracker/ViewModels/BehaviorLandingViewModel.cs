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
        INavigation _navigation;

        public ICommand OpenBehaviorPageCommand { get; }

        public ICommand OpenEvaluationPageCommand { get; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<ClassPeriod> ClassPeriods { get; set; }

        public BehaviorLandingViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = "Behavior or Evaluation";

            OpenBehaviorPageCommand = new Command(OnBehaviorTapped);

            OpenEvaluationPageCommand = new Command(OnEvaluationTapped);

            Students = StudentDataStore.GetStudents();

            ClassPeriods = ClassPeriodDataStore.GetClassPeriods();


        }

        async void OnBehaviorTapped()
        {
            await _navigation.PushModalAsync(new NavigationPage(new BehaviorPage()));
        }

        async void OnEvaluationTapped()
        {
            await _navigation.PushAsync(new NavigationPage(new EvaluationPage()));
        }

    }
}
