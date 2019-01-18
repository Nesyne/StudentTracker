using System;
using System.Collections.Generic;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class AcademicPage : ContentPage
    {
        AcademicPageViewModel _viewModel;

        public AcademicPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new AcademicPageViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Academics.Count == 0)
                _viewModel.LoadAcademicsCommand.Execute(null);
        }
    }
}
