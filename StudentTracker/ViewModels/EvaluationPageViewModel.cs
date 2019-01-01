using System;
using System.Windows.Input;
using StudentTracker.Views;
using Xamarin.Forms;
namespace StudentTracker.ViewModels
{
    public class EvaluationPageViewModel:BaseViewModel
    {
        INavigation _navigation;

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        public EvaluationPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            SaveCommand = new Command(Save);

            CancelCommand = new Command(Cancel);
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
