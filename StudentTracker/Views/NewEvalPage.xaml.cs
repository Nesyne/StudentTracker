using System;
using System.Collections.Generic;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class NewEvalPage : ContentPage
    {
        NewEvalPageViewModel _viewModel;

        public NewEvalPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NewEvalPageViewModel(Navigation);
        }
    }
}
