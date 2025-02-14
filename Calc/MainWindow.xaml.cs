using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Экземпляр логики калькулятора.
        private CalculatorLogic calc = new CalculatorLogic();

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            string input = string.Empty;

            // Проверяем нажатые клавиши и задаем соответствующий ввод
            switch (e.Key)
            {
                case Key.D0: 
                    input = "0"; 
                    break;

                case Key.D1:
                    input = "1"; 
                    break;

                case Key.D2: 
                    input = "2"; 
                    break;

                case Key.D3: 
                    input = "3"; 
                    break;

                case Key.D4: 
                    input = "4"; 
                    break;

                case Key.D5: 
                    input = "5"; 
                    break;

                case Key.D6: 
                    input = "6";
                    break;

                case Key.D7: 
                    input = "7";
                    break;

                case Key.D8:
                    input = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift) ? "*" : "8";
                    break;

                case Key.D9: 
                    input = "9";
                    break;

                case Key.Add: 
                    input = "+";
                    break;

                case Key.Subtract: 
                    input = "-"; 
                    break;

                case Key.Multiply: 
                    input = "*"; 
                    break;

                case Key.Divide: 
                    input = "/"; 
                    break;

                case Key.Enter: 
                    input = "="; 
                    break;

                case Key.Back:
                    input = "⌫"; 
                    break; // Добавить поддержку "⌫" для удаления символа

                case Key.C: 
                    input = "C";
                    break; // Очистка экрана

                // Добавляем обработку символов `Shift` + `число`
                case Key.OemMinus: 
                    input = "-"; 
                    break; // Минус

                case Key.OemPlus: 
                    input = "+"; 
                    break; // Плюс
                          
                case Key.OemQuestion: 
                    input = "/"; 
                    break; // Знак деления (для дополнительной клавиатуры)
            }

            // Если нажата одна из клавиш, передаем ввод в калькулятор
            if (!string.IsNullOrEmpty(input))
            {
                string mainResult = calc.ProcessInput(input, DisplayMain.Text);
                DisplayMain.Text = mainResult;
                DisplaySecondary.Text = calc.SecondaryDisplay;
                e.Handled = true; // Отмечаем событие как обработанное
            }
        }

        // Обработчик нажатия кнопок калькулятора.       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string input = button.Content.ToString();
                // Обновляем основное табло
                string mainResult = calc.ProcessInput(input, DisplayMain.Text);
                DisplayMain.Text = mainResult;
                // Обновляем дополнительное табло (выражение)
                DisplaySecondary.Text = calc.SecondaryDisplay;
            }
        }
    }
}
