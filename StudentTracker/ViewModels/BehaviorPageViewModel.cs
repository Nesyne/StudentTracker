using System;
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

        public BehaviorPageViewModel(INavigation navigation, Student student, ClassPeriod classPeriod)
        {
            _navigation = navigation;
            _student = student;
            _classPeriod = classPeriod;

            Title = student.Name;

            TimePeriod = classPeriod.Period;

            SaveCommand = new Command(Save);

            CancelCommand = new Command(Cancel);
        }

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
                OnPropertyChanged("IncidentTime");
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
