using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using DemoApp;

namespace Calculator
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        private CalculatorModel _calc;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand NumberCommand { get; private set; }
        public RelayCommand PlusCommand { get; private set; }
        public RelayCommand MinusCommand { get; private set; }
        public RelayCommand TimesCommand { get; private set; }
        public RelayCommand OverCommand { get; private set; }
        public RelayCommand EqualsCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }
        public String Display
        {
            get
            {
                return _calc.Display;
            }
        }

        public CalculatorViewModel(CalculatorModel calculator)
        {
            _calc = calculator;

            NumberCommand = new RelayCommand(param => { _calc.Number(Convert.ToInt32(param)); UpdateDisplay(); },
                                            param => _calc.CanDoNumber());

            PlusCommand = new RelayCommand(param => { _calc.Plus(); UpdateDisplay(); },
                                            param => _calc.CanDoOperator());

            MinusCommand = new RelayCommand(param => { _calc.Minus(); UpdateDisplay(); },
                                            param => _calc.CanDoOperator());

            TimesCommand = new RelayCommand(param => { _calc.Times(); UpdateDisplay(); },
                                            param => _calc.CanDoOperator());

            OverCommand = new RelayCommand(param => { _calc.Over(); UpdateDisplay(); },
                                            param => _calc.CanDoOperator());

            EqualsCommand = new RelayCommand(param => { _calc.Equals(); UpdateDisplay(); },
                                            param => _calc.CanDoEquals());

            ClearCommand = new RelayCommand(param => { _calc.Clear(); UpdateDisplay(); },
                                            param => _calc.CanDoClear());
        }

        private void UpdateDisplay()
        {
            NotifyPropertyChanged("Display");
            CommandManager.InvalidateRequerySuggested();
        }

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
