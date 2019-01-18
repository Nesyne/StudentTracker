using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace StudentTracker.ViewModels
{
    public class NewEvalPageViewModel:BaseViewModel
    {
        INavigation _navigation;

        public NewEvalPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            SaveCommand = new Command(Save);

            CancelCommand = new Command(Cancel);
        }

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }


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
