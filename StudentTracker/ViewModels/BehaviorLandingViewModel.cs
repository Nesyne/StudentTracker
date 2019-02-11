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

        public Command LoadDataSourcesCommand { get; set; }

        public ICommand OpenBehaviorPageCommand { get; }

        public ICommand OpenEvaluationPageCommand { get; }

        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<ClassPeriod> ClassPeriods { get; set; }

        public ObservableCollection<Location> Locations { get; set; }

        public ObservableCollection<Activity> Activities { get; set; }

        public ObservableCollection<Antecedent> Antecedents { get; set; }

        public ObservableCollection<Models.Behavior> Behaviors { get; set; }

        public ObservableCollection<Consequence> Consequences { get; set; }

        public ObservableCollection<Intensity> Intensities { get; set; }


        public BehaviorLandingViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = V;

            LoadDataSourcesCommand = new Command(async () => await ExecuteLoadDataSourcesCommand());

            OpenBehaviorPageCommand = new Command(OnBehaviorTapped);

            OpenEvaluationPageCommand = new Command(OnEvaluationTapped);

            LoadDataSourcesCommand.Execute(null);
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
                await GetStudents();
                await GetClassPeriods();
                await GetLocations();
                await GetActivities();
                await GetAntecedents();
                await GetBehaviors();
                await GetConsequences();
                await GetIntensities();
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

        async Task GetStudents()
        {
            if (Students != null)
                Students.Clear();
            else
                Students = new ObservableCollection<Student>();

            var items = await StudentDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Students.Add(item);
            }
        }

        async Task GetClassPeriods()
        {
            if (ClassPeriods != null)
                ClassPeriods.Clear();
            else
                ClassPeriods = new ObservableCollection<ClassPeriod>();

            var items = await ClassPeriodDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                ClassPeriods.Add(item);
            }
        }
        async Task GetLocations()
        {

            if (Locations != null)
                Locations.Clear();
            else
                Locations = new ObservableCollection<Location>();

            var locations = await LocationDataStore.GetItemsAsync(true);
            foreach (var location in locations)
            {
                Locations.Add(location);
            }
        }

        async Task GetActivities()
        {
            if (Activities != null)
                Activities.Clear();
            else
                Activities = new ObservableCollection<Activity>();

            var activities = await ActivityDataStore.GetItemsAsync(true);
            foreach (var activity in activities)
            {
                Activities.Add(activity);
            }
        }

        async Task GetAntecedents()
        {
            if (Antecedents != null)
                Antecedents.Clear();
            else
                Antecedents = new ObservableCollection<Antecedent>();

            var items = await AntecedentDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Antecedents.Add(item);
            }
        }

        async Task GetBehaviors()
        {
            if (Behaviors != null)
                Behaviors.Clear();
            else
            {
                Behaviors = new ObservableCollection<Models.Behavior>();
            }

            var items = await BehaviorDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Behaviors.Add(item);
            }
        }

        async Task GetConsequences()
        {
            if (Consequences != null)
                Consequences.Clear();
            else
                Consequences = new ObservableCollection<Consequence>(); 

            var items = await ConsequenceDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Consequences.Add(item);
            }
        }

        async Task GetIntensities()
        {
            if (Intensities != null)
                Intensities.Clear();
            else
                Intensities = new ObservableCollection<Intensity>();

            var items = await IntensityDataStore.GetItemsAsync(true);
            foreach (var item in items)
            {
                Intensities.Add(item);
            }
        }


        async void OnBehaviorTapped()
        {
            await _navigation.PushModalAsync(new NavigationPage(new BehaviorPage(_student,_classPeriod)));
        }

        async void OnEvaluationTapped()
        {
            await _navigation.PushAsync(new NavigationPage(new EvaluationPage(_student, _classPeriod, ClassPeriods)));
        }

    }
}
