using System;
using System.Collections.Generic;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class BehaviorPage : ContentPage
    {
        BehaviorPageViewModel _viewModel;

        public BehaviorPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BehaviorPageViewModel(this.Navigation);
        }
    }
}
