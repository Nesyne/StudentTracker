using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class EvaluationPage : ContentPage
    {
        EvaluationPageViewModel _viewModel;
        Student _student;
        ClassPeriod _classPeriod;
        ObservableCollection<ClassPeriod> _classPeriods;

        public EvaluationPage(Student student, ClassPeriod classPeriod, ObservableCollection<ClassPeriod> classPeriods)
        {
            InitializeComponent();

            _student = student;
            _classPeriod = classPeriod;
            _classPeriods = classPeriods;

            BindingContext = _viewModel = new EvaluationPageViewModel(Navigation,student);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Evals.Count == 0)
                _viewModel.LoadEvalsCommand.Execute(null);
        }

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var lv = sender as ListView;

            if (lv != null)
            {
                var eval = lv.SelectedItem as Models.Eval;

                if(eval != null)
                {
                    Navigation.PushModalAsync(new NavigationPage(new NewEvalPage(eval,_student,_classPeriod,_classPeriods)));
                }
            }

           
        }
    }
}
