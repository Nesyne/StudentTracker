using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class NewEvalPage : ContentPage
    {
        NewEvalPageViewModel _viewModel;

        public NewEvalPage(Models.Eval eval, Student student, ClassPeriod classPeriod, ObservableCollection<ClassPeriod> classPeriods)
        {
            InitializeComponent();

            Title = student.Name;

            BindingContext = _viewModel = new NewEvalPageViewModel(Navigation,eval,student,classPeriod,classPeriods);
        }

        void TimePeriod_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (sender is Picker picker && picker.SelectedItem != null)
                {
                    if (picker.SelectedItem is Models.ClassPeriod selectedItem)
                        _viewModel.EvalDetails.ClassPeriodId = selectedItem.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        void ReasonCode_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (sender is Picker picker && picker.SelectedItem != null)
                {
                    if (picker.SelectedItem is Models.ReasonCode selectedItem)
                        _viewModel.EvalDetails.ReasonCodeId = selectedItem.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        void TimeMissed_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    bool isValid = e.NewTextValue.ToCharArray().All(x => char.IsDigit(x)); //Make sure all characters are numbers

                    ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);

                    int val = 0;

                    bool results = int.TryParse(e.NewTextValue, out val);

                    if (results)
                        _viewModel.EvalDetails.TimeMissed = val;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        void Notes_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    _viewModel.EvalDetails.Notes = e.NewTextValue;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
