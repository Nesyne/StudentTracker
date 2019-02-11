using System;
using System.Collections.Generic;
using System.Linq;
using StudentTracker.Models;
using StudentTracker.ViewModels;
using Xamarin.Forms;

namespace StudentTracker.Views
{
    public partial class BehaviorPage : ContentPage
    {
        BehaviorPageViewModel _viewModel;

        public BehaviorPage(Student student, ClassPeriod classPeriod)
        {
            InitializeComponent();

            BindingContext = _viewModel = new BehaviorPageViewModel(this.Navigation,student,classPeriod);
        }

        void Duration_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    bool isValid = e.NewTextValue.ToCharArray().All(x => char.IsDigit(x)); //Make sure all characters are numbers

                    ((Entry)sender).Text = isValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);

                    int val = 0;

                    bool results = int.TryParse(e.NewTextValue, out val);

                    //if (results)
                        //_viewModel.EvalDetails.TimeMissed = val;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
