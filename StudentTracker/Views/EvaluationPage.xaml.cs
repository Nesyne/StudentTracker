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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Evals.Count == 0)
                _viewModel.LoadEvalsCommand.Execute(null);
        }
    }
}
