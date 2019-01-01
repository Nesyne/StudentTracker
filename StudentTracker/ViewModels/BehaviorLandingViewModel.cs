using Xamarin.Forms;
using System.Windows.Input;
using StudentTracker.Views;

namespace StudentTracker.ViewModels
{
    public class BehaviorLandingViewModel:BaseViewModel
    {
        INavigation _navigation;

        public ICommand OpenBehaviorPageCommand { get; }

        public ICommand OpenEvaluationPageCommand { get; }

        public BehaviorLandingViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Title = "Behavior/Evaluation";

            OpenBehaviorPageCommand = new Command(OnBehaviorTapped);

            OpenEvaluationPageCommand = new Command(OnEvaluationTapped);
        }

        async void OnBehaviorTapped()
        {
            await _navigation.PushModalAsync(new NavigationPage(new BehaviorPage()));
        }

        async void OnEvaluationTapped()
        {
            await _navigation.PushModalAsync(new NavigationPage(new EvaluationPage()));
        }
    }
}
