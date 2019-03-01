using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StudentTracker.Models;
using Xamarin.Forms;

namespace StudentTracker.ViewModels
{
    public class BehaviorPageViewModel: BaseViewModel
    {
        INavigation _navigation;
        Student _student;
        ClassPeriod _classPeriod;
        DateTime _incidentDate = DateTime.Now;
        TimeSpan _incidentTime = new TimeSpan(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
        BehaviorDetail _behaviorDetail = new BehaviorDetail();
        private Location _selectedLocation;
        private Activity _selectedActivity;
        private Antecedent _selectedAntecedent;
        private Models.Behavior _selectedBehavior;
        private Consequence _selectedConsequence;
        private Intensity _selectedIntensity;
        private DataAccess _dataAccess;

        public BehaviorPageViewModel(INavigation navigation, Student student, ClassPeriod classPeriod,DataAccess dataAccess)
        {
            _navigation = navigation;
            _student = student;
            _classPeriod = classPeriod;
            _dataAccess = dataAccess;
            Title = student.Name;

            TimePeriod = classPeriod.Period;

            _behaviorDetail.ClassPeriodId = classPeriod.Id;

            SaveCommand = new Command(Save);

            CancelCommand = new Command(Cancel);

            
        }

        public ObservableCollection<Location> Locations { get { return _dataAccess.Locations; } }
        public ObservableCollection<Activity> Activities { get { return _dataAccess.Activities; } }
        public ObservableCollection<Antecedent> Antecedents { get { return _dataAccess.Antecedents; } }
        public ObservableCollection<Models.Behavior> Behaviors { get { return _dataAccess.Behaviors; } }
        public ObservableCollection<Consequence> Consequences { get { return _dataAccess.Consequences; } }
        public ObservableCollection<Intensity> Intensities { get { return _dataAccess.Intensities; } }

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        public string TimePeriod { get; }

        public DateTime IncidentDate
        {
            get { return _incidentDate; }
            set
            {
                if (_incidentDate == value)
                    return;
                _incidentDate = value;
                UpdateTime();
                OnPropertyChanged("IncidentDate");
            }
        }

        public TimeSpan IncidentTime
        {
            get { return _incidentTime; }
            set
            {
                if (_incidentTime == value)
                    return;
                _incidentTime = value;
                UpdateTime();
                OnPropertyChanged("IncidentTime");
            }
        }

        public BehaviorDetail BehaviorDetail
        {
            get { return _behaviorDetail; }
            set
            {
                if (_behaviorDetail == value)
                    return;
                _behaviorDetail = value;
                OnPropertyChanged("BehaviorDetail");
            }
        }

        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                if (_selectedLocation == value)
                    return;
                _selectedLocation = value;
                _behaviorDetail.LocationId = value.Id;
                OnPropertyChanged("SelectedLocation");
            }
        }

        public Activity SelectedActivity
        {
            get { return _selectedActivity; }
            set
            {
                if (_selectedActivity == value)
                    return;
                _selectedActivity = value;
                _behaviorDetail.ActivityId = value.Id;
                OnPropertyChanged("SelectedActivity");
            }
        }

        public Antecedent SelectedAntecedent
        {
            get { return _selectedAntecedent; }
            set
            {
                if (_selectedAntecedent == value)
                    return;
                _selectedAntecedent = value;
                _behaviorDetail.AntecedentId = value.Id;
                OnPropertyChanged("SelectedAntecedent");
            }
        }

        public Models.Behavior SelectedBehavior
        {
            get { return _selectedBehavior; }
            set
            {
                if (_selectedBehavior == value)
                    return;
                _selectedBehavior = value;
                _behaviorDetail.BehaviorId = value.Id;
                OnPropertyChanged("SelectedBehavior");
            }
        }

        public Consequence SelectedConsequence
        {
            get { return _selectedConsequence; }
            set
            {
                if (_selectedConsequence == value)
                    return;
                _selectedConsequence = value;
                _behaviorDetail.ConsequenceId = value.Id;
                OnPropertyChanged("SelectedConsequence");
            }
        }

        public Intensity SelectedIntensity
        {
            get { return _selectedIntensity; }
            set
            {
                if (_selectedIntensity == value)
                    return;
                _selectedIntensity = value;
                _behaviorDetail.IntensityId = value.Id;
                OnPropertyChanged("SelectedIntensity");
            }
        }

        void UpdateTime()
        {
            try
            {
                _behaviorDetail.StartTime = _incidentDate + _incidentTime;
            }
            catch 
            {
                throw;
            }
        }

        async void Save()
        {
            await _navigation.PopModalAsync();
        }

        async void Cancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}
