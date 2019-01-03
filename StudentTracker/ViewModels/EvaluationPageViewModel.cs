﻿using System;
using System.Windows.Input;
using StudentTracker.Views;
using System.Collections.ObjectModel;
using StudentTracker.Models;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
namespace StudentTracker.ViewModels
{
    public class EvaluationPageViewModel:BaseViewModel
    {
        INavigation _navigation;

        public ObservableCollection<Eval> Evals { get; set; }

        public Command LoadEvalsCommand { get; set; }

        public EvaluationPageViewModel(INavigation navigation)
        {
            _navigation = navigation;

            Evals = new ObservableCollection<Eval>();

            LoadEvalsCommand = new Command(async () => await ExecuteLoadEvalsCommand());
        }

        async Task ExecuteLoadEvalsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Evals.Clear();
                var evals = await EvalDataStore.GetItemsAsync(true);
                foreach (var eval in evals)
                {
                    Evals.Add(eval);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
