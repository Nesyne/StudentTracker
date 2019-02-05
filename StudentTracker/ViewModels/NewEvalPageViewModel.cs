using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StudentTracker.Models;
using Xamarin.Forms;

namespace StudentTracker.ViewModels
{
    public class NewEvalPageViewModel:BaseViewModel
    {
        INavigation _navigation;

        Eval _selectedEval;
        EvalDetail _evalDetails;
        Color _naBorderColor;
        Color _greenBorderColor;
        Color _yellowBorderColor;
        Color _redBorderColor;
        bool _reasonOnRed;
        bool _reasonOnYellow;
        bool _isReasonVisible;

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        public ICommand NACommand { get; }

        public ICommand GreenCommand { get; }

        public ICommand RedCommand { get; }

        public ICommand YellowCommand { get; }

        public ObservableCollection<ClassPeriod> ClassPeriods { get; set; }

        public ObservableCollection<ReasonCode> ReasonCodes { get; set; }

        public EvalDetail EvalDetails
        {
            get { return _evalDetails; }
            set
            {
                if (_evalDetails == value)
                    return;
                _evalDetails = value;
                OnPropertyChanged("EvalDetails");
            }
        }

        public Color NABorderColor
        {
            get { return _naBorderColor; }
            set
            {
                if (_naBorderColor == value)
                    return;
                _naBorderColor = value;
                OnPropertyChanged("NABorderColor");
            }
        }

        public Color GreenBorderColor
        {
            get { return _greenBorderColor; }
            set
            {
                if (_greenBorderColor == value)
                    return;
                _greenBorderColor = value;
                OnPropertyChanged("GreenBorderColor");
            }
        }

        public Color YellowBorderColor
        {
            get { return _yellowBorderColor; }
            set
            {
                if (_yellowBorderColor == value)
                    return;
                _yellowBorderColor = value;
                OnPropertyChanged("YellowBorderColor");
            }
        }

        public Color RedBorderColor
        {
            get { return _redBorderColor; }
            set
            {
                if (_redBorderColor == value)
                    return;
                _redBorderColor = value;
                OnPropertyChanged("RedBorderColor");
            }
        }

        public bool ReasonOnRed
        {
            get { return _reasonOnRed; }
            set
            {
                if (_reasonOnRed == value)
                    return;
                _reasonOnRed = value;
                OnPropertyChanged("ReasonOnRed");
            }
        }

        public bool ReasonOnYellow
        {
            get { return _reasonOnYellow; }
            set
            {
                if (_reasonOnYellow == value)
                    return;
                _reasonOnYellow = value;
                OnPropertyChanged("ReasonOnYellow");
            }
        }

        public bool IsReasonVisible
        {
            get { return _isReasonVisible; }
            set
            {
                if (_isReasonVisible == value)
                    return;
                _isReasonVisible = value;
                OnPropertyChanged("IsReasonVisible");
            }
        }

        public NewEvalPageViewModel(INavigation navigation, Eval eval)
        {
            _navigation = navigation;

            _selectedEval = eval;

            _evalDetails = new EvalDetail();

            SaveCommand = new Command(Save);

            CancelCommand = new Command(Cancel);

            NACommand = new Command(NASelected);

            GreenCommand = new Command(GreenSelected);

            YellowCommand = new Command(YellowSelected);

            RedCommand = new Command(RedSelected);

            ClassPeriods = ClassPeriodDataStore.GetClassPeriods();

            ReasonCodes = ReasonCodesDataStore.GetReasonCodes();

            IsReasonVisible = eval.ReasonOnRed || eval.ReasonOnYellow;

            NASelected();

            _evalDetails.EvalId = eval.Id;

        }

        async void Save()
        {
            await _navigation.PopModalAsync();
        }

        async void Cancel()
        {
            await _navigation.PopModalAsync();
        }

        void NASelected()
        {
            NABorderColor = Color.Black;
            GreenBorderColor = Color.Transparent;
            YellowBorderColor = Color.Transparent;
            RedBorderColor = Color.Transparent;
            _evalDetails.Level = 4;
        }

        void GreenSelected()
        {
            GreenBorderColor = Color.Black;
            NABorderColor = Color.Transparent;
            YellowBorderColor = Color.Transparent;
            RedBorderColor = Color.Transparent;
            _evalDetails.Level = 1;
        }

        void YellowSelected()
        {
            YellowBorderColor = Color.Black;
            GreenBorderColor = Color.Transparent;
            NABorderColor = Color.Transparent;
            RedBorderColor = Color.Transparent;
            _evalDetails.Level = 2;
        }

        void RedSelected()
        {
            RedBorderColor = Color.Black;
            GreenBorderColor = Color.Transparent;
            NABorderColor = Color.Transparent;
            YellowBorderColor = Color.Transparent;
            _evalDetails.Level = 3;
        }
    }
}
