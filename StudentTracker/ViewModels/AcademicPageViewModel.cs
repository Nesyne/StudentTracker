using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using StudentTracker.Models;
using Xamarin.Forms;

namespace StudentTracker.ViewModels
{
    public class AcademicPageViewModel: BaseViewModel
    {
        INavigation _navigation;

        public ObservableCollection<AcademicGoal> Academics { get; set; }

        public Command LoadAcademicsCommand { get; set; }

        public AcademicPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Academics = new ObservableCollection<AcademicGoal>();

            LoadAcademicsCommand = new Command(async () => await ExecuteLoadAcademicGoalsCommand());
        }

        async Task ExecuteLoadAcademicGoalsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Academics.Clear();
                var academics = await AcademicGoalDataStore.GetItemsAsync(true);
                foreach (var academic in academics)
                {
                    Academics.Add(academic);
                }
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
    }
}
