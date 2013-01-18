using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorModel
    {
        private int? _operand1;
        private char? _operator;
        private int? _operand2;
        private int? _result;
        private String _display;

        public int? Result
        {
            get
            {
                if (!_result.HasValue)
                {
                    throw new InvalidOperationException();
                }
                return _result;
            }
        }

        public String Display
        {
            get
            {
                return _display;
            }
        }

        public CalculatorModel()
        {
            Clear();
        }

        public bool CanDoOperator()
        {
            return _operand1.HasValue && !_operator.HasValue;
        }

        public void Plus()
        {
            DoOperator('+');
        }

        public void Minus()
        {
            DoOperator('-');
        }

        public void Times()
        {
            DoOperator('*');
        }

        public void Over()
        {
            DoOperator('/');
        }

        private void DoOperator(char o)
        {
            if (!CanDoOperator())
            {
                throw new InvalidOperationException();
            }

            _operator = o;
            _display += " " + o + " ";
        }

        public bool CanDoNumber()
        {
            return !_result.HasValue;
        }

        public void Number(int num)
        {
            if (!CanDoNumber())
            {
                throw new InvalidOperationException();
            }

            if ((num < 0) || (num > 9))
            {
                throw new ArgumentException();
            }

            if (!_operator.HasValue)
            {
                if (!_operand1.HasValue)
                {
                    _operand1 = num;
                    _display = num.ToString();
                }
                else
                {
                    _operand1 = _operand1 * 10 + num;
                    _display += num;
                }
            }
            else
            {
                if (!_operand2.HasValue)
                {
                    _operand2 = num;
                }
                else
                {
                    _operand2 = _operand2 * 10 + num;
                }

                _display += num;
            }
        }

        public bool CanDoEquals()
        {
            return (_operand1.HasValue && _operator.HasValue && _operand2.HasValue && !_result.HasValue);
        }

        public void Equals()
        {
            if (!CanDoEquals())
            {
                throw new InvalidOperationException();
            }

            switch (_operator)
            {
                case '+':
                    _result = _operand1 + _operand2;
                    break;
                case '-':
                    _result = _operand1 - _operand2;
                    break;
                case '*':
                    _result = _operand1 * _operand2;
                    break;
                case '/':
                    _result = _operand1 / _operand2;
                    break;
            }

            _display = _result.ToString();
        }

        public bool CanDoClear()
        {
            return true;
        }

        public void Clear()
        {
            _operand1 = null;
            _operator = null;
            _operand2 = null;
            _result = null;
            _display = "0";
        }
    }
}
