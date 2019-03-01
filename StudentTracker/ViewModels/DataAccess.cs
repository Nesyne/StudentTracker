using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using StudentTracker.Models;
using System.Diagnostics;

namespace StudentTracker.ViewModels
{
    public class DataAccess : BaseViewModel
    {
        public ObservableCollection<Student> Students { get; set; }

        public ObservableCollection<ClassPeriod> ClassPeriods { get; set; }

        public ObservableCollection<Location> Locations { get; set; }

        public ObservableCollection<Activity> Activities { get; set; }

        public ObservableCollection<Antecedent> Antecedents { get; set; }

        public ObservableCollection<Models.Behavior> Behaviors { get; set; }

        public ObservableCollection<Consequence> Consequences { get; set; }

        public ObservableCollection<Intensity> Intensities { get; set; }

        public DataAccess()
        {

        }

        public async Task GetAllCollections()
        {

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
        }

        public async Task GetStudents()
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

        public async Task GetClassPeriods()
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
        public async Task GetLocations()
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

        public async Task GetActivities()
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

        public async Task GetAntecedents()
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

        public async Task GetBehaviors()
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

        public async Task GetConsequences()
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

        public async Task GetIntensities()
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
    }
}
