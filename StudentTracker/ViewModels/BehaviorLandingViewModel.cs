using Xamarin.Forms;
using System.Windows.Input;
using StudentTracker.Views;

namespace StudentTracker.ViewModels
{
    public class BehaviorLandingViewModel:BaseViewModel
    {
        ContentPage _page;

        public ICommand OpenBehaviorPageCommand { get; }

        public ICommand OpenEvaluationPageCommand { get; }

        public BehaviorLandingViewModel(ContentPage page)
        {
            _page = page;

            Title = "Behavior/Evaluation";

            OpenBehaviorPageCommand = new Command(OnBehaviorTapped);

            OpenEvaluationPageCommand = new Command(OnEvaluationTapped);
        }

        async void OnBehaviorTapped()
        {
            await _page.Navigation.PushModalAsync(new NavigationPage(new BehaviorPage()));
        }

        void OnEvaluationTapped()
        {

        }
    }
}
