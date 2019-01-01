using System;
using System.Collections.Generic;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class EvaluationPage : ContentPage
    {
        EvaluationPageViewModel _viewModel;

        public EvaluationPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new EvaluationPageViewModel(this.Navigation);
        }
    }
}
