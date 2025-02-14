using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calc;


namespace CalculatorTests
{
    [TestClass]
    public class CalculatorLogicTests
    {
        #region Тесты для сложения

        [TestMethod]
        public void Addition_PositiveTest1()
        {
            // 2 + 3 = 5
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("2", display);
            display = calc.ProcessInput("+", display);
            display = calc.ProcessInput("3", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("5", display, "Ошибка: 2 + 3 должно давать 5");
        }

        [TestMethod]
        public void Addition_PositiveTest2()
        {
            // 12 + 34 = 46
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("1", display);
            display = calc.ProcessInput("2", display);
            display = calc.ProcessInput("+", display);
            // Новый ввод начинается с "0"
            display = calc.ProcessInput("3", "0");
            display = calc.ProcessInput("4", display);
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("46", display, "Ошибка: 12 + 34 должно давать 46");
        }

        #endregion

        #region Тесты для вычитания

        [TestMethod]
        public void Subtraction_PositiveTest1()
        {
            // 9 - 4 = 5
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("9", display);
            display = calc.ProcessInput("-", display);
            display = calc.ProcessInput("4", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("5", display, "Ошибка: 9 - 4 должно давать 5");
        }

        [TestMethod]
        public void Subtraction_PositiveTest2()
        {
            // 100 - 50 = 50
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("1", display);
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("-", display);
            display = calc.ProcessInput("5", "0");
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("50", display, "Ошибка: 100 - 50 должно давать 50");
        }

        #endregion

        #region Тесты для умножения

        [TestMethod]
        public void Multiplication_PositiveTest1()
        {
            // 4 * 5 = 20
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("4", display);
            display = calc.ProcessInput("*", display);
            display = calc.ProcessInput("5", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("20", display, "Ошибка: 4 * 5 должно давать 20");
        }

        [TestMethod]
        public void Multiplication_PositiveTest2()
        {
            // 12 * 3 = 36
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("1", display);
            display = calc.ProcessInput("2", display);
            display = calc.ProcessInput("*", display);
            display = calc.ProcessInput("3", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("36", display, "Ошибка: 12 * 3 должно давать 36");
        }

        #endregion

        #region Тесты для деления

        [TestMethod]
        public void Division_PositiveTest1()
        {
            // 8 / 2 = 4
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("8", display);
            display = calc.ProcessInput("/", display);
            display = calc.ProcessInput("2", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("4", display, "Ошибка: 8 / 2 должно давать 4");
        }

        [TestMethod]
        public void Division_PositiveTest2()
        {
            // 15 / 3 = 5 (вводим последовательно "1", "5", затем "/")
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("1", display);
            display = calc.ProcessInput("5", display);
            display = calc.ProcessInput("/", display);
            display = calc.ProcessInput("3", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("5", display, "Ошибка: 15 / 3 должно давать 5");
        }

        [TestMethod]
        public void Division_NegativeTest_DivisionByZero()
        {
            // Деление на 0 должно возвращать сообщение "Деление на 0 запрещено"
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("8", display);
            display = calc.ProcessInput("/", display);
            display = calc.ProcessInput("0", "0");
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("Деление на 0 запрещено", display, "Ошибка: деление на 0 не обработано корректно");
        }

        #endregion

        #region Тесты для извлечения квадратного корня

        [TestMethod]
        public void SquareRoot_PositiveTest1()
        {
            // √9 = 3
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("9", display);
            display = calc.ProcessInput("√", display);
            Assert.AreEqual("3", display, "Ошибка: √9 должно давать 3");
        }

        [TestMethod]
        public void SquareRoot_PositiveTest2()
        {
            // √16 = 4
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("1", display);
            display = calc.ProcessInput("6", display);
            display = calc.ProcessInput("√", display);
            Assert.AreEqual("4", display, "Ошибка: √16 должно давать 4");
        }

        [TestMethod]
        public void SquareRoot_NegativeTest_NegativeNumber()
        {
            // Извлечение корня из отрицательного числа (-5) должно возвращать сообщение об ошибке
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("5", display);
            display = calc.ProcessInput("+/-", display); // теперь -5
            display = calc.ProcessInput("√", display);
            Assert.AreEqual("Нельзя извлекать корень из отрицательного числа", display,
                "Ошибка: извлечение корня из отрицательного числа не обработано корректно");
        }

        #endregion

        #region Тесты для возведения в квадрат

        [TestMethod]
        public void Square_PositiveTest1()
        {
            // 5² = 25
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("5", display);
            display = calc.ProcessInput("x²", display);
            Assert.AreEqual("25", display, "Ошибка: 5² должно давать 25");
        }

        [TestMethod]
        public void Square_PositiveTest2()
        {
            // 3² = 9
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("3", display);
            display = calc.ProcessInput("x²", display);
            Assert.AreEqual("9", display, "Ошибка: 3² должно давать 9");
        }

        #endregion

        #region Тесты для вычисления обратного значения

        [TestMethod]
        public void Reciprocal_PositiveTest1()
        {
            // 1/4 = 0,25
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("4", display);
            display = calc.ProcessInput("1/x", display);
            Assert.AreEqual("0,25", display, "Ошибка: 1/4 должно давать 0,25");
        }

        [TestMethod]
        public void Reciprocal_PositiveTest2()
        {
            // 1/2 = 0,5
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("2", display);
            display = calc.ProcessInput("1/x", display);
            Assert.AreEqual("0,5", display, "Ошибка: 1/2 должно давать 0,5");
        }

        [TestMethod]
        public void Reciprocal_NegativeTest_DivisionByZero()
        {
            // Обратное значение от 0 должно возвращать сообщение "Деление на 0 запрещено"
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("1/x", display);
            Assert.AreEqual("Деление на 0 запрещено", display, "Ошибка: 1/0 не обработано корректно");
        }

        #endregion

        #region Тесты для процентного вычисления

        [TestMethod]
        public void Percent_PositiveTest1()
        {
            // 200 + 10%: 10% от 200 = 20, 200 + 20 = 220
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("2", display);
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("+", display);
            display = calc.ProcessInput("1", "0");
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("%", display);
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("220", display, "Ошибка: 200 + 10% должно давать 220");
        }

        [TestMethod]
        public void Percent_PositiveTest2()
        {
            // 500 - 20%: 20% от 500 = 100, 500 - 100 = 400
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("5", display);
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("-", display);
            display = calc.ProcessInput("2", "0");
            display = calc.ProcessInput("0", display);
            display = calc.ProcessInput("%", display);
            display = calc.ProcessInput("=", display);
            Assert.AreEqual("400", display, "Ошибка: 500 - 20% должно давать 400");
        }

        [TestMethod]
        public void Percent_NegativeTest_DivisionByZero()
        {
            // Пример негативного теста для процентной операции, где при делении на 0 должно возникать сообщение об ошибке.
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            // Имитируем операцию деления с процентом: 8 / 0 с последующим процентом.
            display = calc.ProcessInput("8", display);
            display = calc.ProcessInput("/", display);
            display = calc.ProcessInput("0", "0");
            display = calc.ProcessInput("%", display);
            Assert.AreEqual("Деление на 0 запрещено", display,
                "Ошибка: процентная операция с делением на 0 не обработана корректно");
        }

        #endregion

        #region Тесты для переключения знака

        [TestMethod]
        public void ToggleSign_PositiveTest1()
        {
            // 5 -> переключение знака = -5
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("5", display);
            display = calc.ProcessInput("+/-", display);
            Assert.AreEqual("-5", display, "Ошибка: переключение знака для 5 должно давать -5");
        }

        [TestMethod]
        public void ToggleSign_PositiveTest2()
        {
            // Переключение знака дважды должно вернуть исходное значение
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("7", display);
            display = calc.ProcessInput("+/-", display);
            display = calc.ProcessInput("+/-", display);
            Assert.AreEqual("7", display, "Ошибка: двойное переключение знака для 7 должно возвращать 7");
        }

        #endregion

        #region Негативные тесты для некорректного ввода

        [TestMethod]
        public void InvalidInput_NegativeTest()
        {
            // Передача недопустимого символа (например, "abc") не должна менять отображаемое значение.
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("abc", display);
            Assert.AreEqual("0", display, "Ошибка: некорректный ввод должен игнорироваться");
        }

        [TestMethod]
        public void MultipleComma_NegativeTest()
        {
            // При вводе нескольких запятых должна учитываться только первая.
            CalculatorLogic calc = new CalculatorLogic();
            string display = "0";
            display = calc.ProcessInput("3", display);
            display = calc.ProcessInput(",", display);
            display = calc.ProcessInput(",", display); // повторная запятая должна игнорироваться
            display = calc.ProcessInput("1", display);
            Assert.AreEqual("3,1", display, "Ошибка: ввод нескольких запятых обработан неверно");
        }

        #endregion
    }
}

