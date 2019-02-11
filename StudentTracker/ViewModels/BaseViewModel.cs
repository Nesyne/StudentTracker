using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using StudentTracker.Models;
using StudentTracker.Services;

namespace StudentTracker.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        public IDataStore<Eval> EvalDataStore => DependencyService.Get<IDataStore<Eval>>() ?? new EvalDataStore();

        public IDataStore<AcademicGoal> AcademicGoalDataStore => DependencyService.Get<IDataStore<AcademicGoal>>() ?? new AcademicGoalDataStore();

        public IDataStore<Location> LocationDataStore => DependencyService.Get<IDataStore<Location>>() ?? new LocationDataStore();

        public IDataStore<Activity> ActivityDataStore => DependencyService.Get<IDataStore<Activity>>() ?? new ActivityDataStore();

        public IDataStore<Antecedent> AntecedentDataStore => DependencyService.Get<IDataStore<Antecedent>>() ?? new AntecedentDataStore();

        public IDataStore<Models.Behavior> BehaviorDataStore => DependencyService.Get<IDataStore<Models.Behavior>>() ?? new BehaviorDataStore();

        public IDataStore<Consequence> ConsequenceDataStore => DependencyService.Get<IDataStore<Consequence>>() ?? new ConsequenceDataStore();

        public IDataStore<Intensity> IntensityDataStore => DependencyService.Get<IDataStore<Intensity>>() ?? new IntensityDataStore();

        public IDataStore<Student> StudentDataStore => DependencyService.Get<IDataStore<Student>>() ??  new StudentDataStore();

        public IDataStore<ClassPeriod> ClassPeriodDataStore => DependencyService.Get<IDataStore<ClassPeriod>>() ?? new ClassPeriodDataStore();

        public ReasonCodeDataStore ReasonCodesDataStore = new ReasonCodeDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
