using System;

namespace Calc
{
    internal class CalculatorLogic
    {
        private double _currentValue = 0;
        private double _previousValue = 0;
        private string _operation = "";
        private bool _isNewEntry = true;
        private string _expression = "";
        private string _persentOperation = "";

        public string SecondaryDisplay { get; private set; } = "";

        public string ProcessInput(string input, string currentDisplay)
        {
            // Проверяем, что входной символ - это разрешенный символ (цифры, запятая, знаки операций)
            if (IsValidInput(input))
            {
                if (input == "-" || input == "+" || input == "/" || input == "*") 
                    _persentOperation = input;
                else if (input== "=")                
                    _persentOperation = "";
                
               
                switch (input)
                {
                    case string s when (double.TryParse(s, out _) || s == ","):
                        return HandleNumberInput(input, currentDisplay);
                    case "+/-":
                        return ToggleSign(currentDisplay);
                    default:
                        return HandleOperation(input, currentDisplay);

                }
            }
            return currentDisplay; // Возвращаем текущее отображение, если ввод недопустимый
        }

        // Проверяем, является ли вводимое значение допустимым
        private bool IsValidInput(string input) => double.TryParse(input, out _) || input == "," || "+-*/=CCE⌫√x²1/x%".Contains(input);
      

        private string HandleNumberInput(string input, string currentDisplay)
        {
            if (_isNewEntry || currentDisplay == "0")
            {
                _isNewEntry = false;
                if (string.IsNullOrEmpty(_operation))
                {
                    _expression = "";
                    SecondaryDisplay = "";
                }
                return input == "," ? "0," : input;
            }
            if (input == "," && currentDisplay.Contains(","))
                return currentDisplay;
            return currentDisplay + input;
        }

        private string HandleOperation(string operation, string currentDisplay)
        {
            switch (operation)
            {
                case "C":
                    ResetCalculator();
                    return "0";

                case "CE":
                    _isNewEntry = true;
                    return "0";

                case "⌫":
                    return currentDisplay.Length > 1 ? currentDisplay.Substring(0, currentDisplay.Length - 1) : "0";
            }

            if (!double.TryParse(currentDisplay, out _currentValue))
                _currentValue = 0;

            if (operation == "=" || IsSpecialOperation(operation))
            {
                if (!string.IsNullOrEmpty(_operation) || IsSpecialOperation(operation))
                {
                    if (IsSpecialOperation(operation))
                    {
                        _operation = operation;
                        _expression = operation + "(" + _currentValue.ToString() + ")";
                        SecondaryDisplay = _expression + " =";
                    }                   
                    else if (_operation == "%")                    
                        return _previousValue.ToString();
                    
                    else
                    {
                        _expression += " " + currentDisplay;
                        SecondaryDisplay = _expression + " =";
                    }

                    try
                    {
                        ExecuteOperation();
                    }
                    catch (DivideByZeroException)
                    {
                        return "Деление на 0 запрещено";
                    }
                    catch (ArgumentException ex)
                    {
                        return ex.Message;
                    }

                    _operation = "";
                    _isNewEntry = true;
                    string result = _previousValue.ToString();
                    _expression = "";
                    return result;
                }
                else
                {
                    return currentDisplay;
                }
            }

            if (!string.IsNullOrEmpty(_operation))
            {
                try
                {
                    ExecuteOperation();
                }
                catch (DivideByZeroException)
                {
                    return "Деление на 0 запрещено";
                }
                catch (ArgumentException ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                _previousValue = _currentValue;
            }

            _expression = _currentValue.ToString() + " " + operation;
            SecondaryDisplay = _expression;
            _operation = operation;
            _isNewEntry = true;
            return _previousValue.ToString();
        }

        private void ExecuteOperation()
        {
            switch (_operation)
            {
                case "+":
                    _previousValue = _previousValue + _currentValue;
                    break;

                case "-":
                    _previousValue = _previousValue - _currentValue;
                    break;

                case "*":
                    _previousValue = _previousValue * _currentValue;
                    break;

                case "/":
                    if (_currentValue == 0)
                        throw new DivideByZeroException();
                    _previousValue = _previousValue / _currentValue;
                    break;

                case "√":
                    if (_currentValue < 0)
                        throw new ArgumentException("Нельзя извлекать корень из отрицательного числа");
                    _previousValue = Math.Sqrt(_currentValue);
                    break;

                case "x²":
                    _previousValue = Math.Pow(_currentValue, 2);
                    break;

                case "1/x":
                    if (_currentValue == 0)
                        throw new DivideByZeroException();
                    _previousValue = 1 / _currentValue;
                    break;

                case "%":
                    double percentage = (_previousValue * _currentValue) / 100;
                    switch (_persentOperation)
                    {
                        case "+":
                            _previousValue += percentage; // Добавляем процент
                            break;

                        case "-":
                            _previousValue -= percentage; // Вычитаем процент
                            break;

                        case "*":
                            _previousValue *= percentage; // Умножаем на процент
                            break;

                        case "/":
                            if (_currentValue == 0)
                                throw new DivideByZeroException();
                            _previousValue /= percentage; // Делим на процент
                            break;

                        default:
                            _previousValue = percentage;
                            break;
                    }
                    _persentOperation = "";
                    break;
            }
        }

        private void ResetCalculator()
        {
            _currentValue = _previousValue = 0;
            _operation = "";
            _isNewEntry = true;
            _expression = "";
            SecondaryDisplay = "";
        }

        private bool IsSpecialOperation(string operation) => operation == "√" || operation == "x²" || operation == "1/x" || operation == "%";
        
        private string ToggleSign(string currentDisplay)
        {
            if (!double.TryParse(currentDisplay, out _currentValue))
                return currentDisplay;

            _currentValue = -_currentValue;
            _expression = _currentValue.ToString();
            SecondaryDisplay = _expression;
            return _currentValue.ToString();
        }
    }
}
