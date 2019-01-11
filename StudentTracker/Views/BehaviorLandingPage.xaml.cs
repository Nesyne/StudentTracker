using System;
using System.Collections.Generic;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class BehaviorLandingPage : ContentPage
    {
        BehaviorLandingViewModel _viewModel;

        public BehaviorLandingPage()
        {
            InitializeComponent();
            
            BindingContext = _viewModel = new BehaviorLandingViewModel(Navigation);
        }
    }
}
