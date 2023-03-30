using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;

namespace PopUp_App
{
    public partial class MainPage : ContentPage
    {

        
        private char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); // массив букв алфавита

        public MainPage()
        {
            InitializeComponent();

            this.BackgroundColor = Color.LightCoral;
        }
        
        async void OnCheckButtonClicked(object sender, EventArgs e)
        {
            // Получаем имя пользователя
            string name = await DisplayPromptAsync("Введите ваше имя", "");

            // Получаем выбранный множитель
            string[] pages = { "умножаем на 1", "умножаем на 2", "умножаем на 3", "умножаем на 4", "умножаем на 5", "умножаем на 6", "умножаем на 7", "умножаем на 8", "умножаем на 9" };
            string page = await DisplayActionSheet("Выберите множитель", "Отмена", null, pages);

            // Получаем введенное пользователем число
            string input = await DisplayPromptAsync("Введите число от 1 до 10", "");

            // Проверяем правильность ввода и отображаем соответствующую страницу
            if (int.TryParse(input, out int number) && number >= 1 && number <= 10)
            {
                switch (page)
                {
                    case "умножаем на 1":
                        await DisplayAlert("Ответ", $"{number} x 1 = {number}", "OK");
                        break;
                    case "умножаем на 2":
                        await DisplayAlert("Ответ", $"{number} x 2 = {number * 2}", "OK");
                        break;
                    case "умножаем на 3":
                        await DisplayAlert("Ответ", $"{number} x 3 = {number * 3}", "OK");
                        break;
                    case "умножаем на 4":
                        await DisplayAlert("Ответ", $"{number} x 4 = {number * 4}", "OK");
                        break;
                    case "умножаем на 5":
                        await DisplayAlert("Ответ", $"{number} x 5 = {number * 5}", "OK");
                        break;
                    case "умножаем на 6":
                        await DisplayAlert("Ответ", $"{number} x 6 = {number * 6}", "OK");
                        break;
                    case "умножаем на 7":
                        await DisplayAlert("Ответ", $"{number} x 7 = {number * 7}", "OK");
                        break;
                    case "умножаем на 8":
                        await DisplayAlert("Ответ", $"{number} x 8 = {number * 8}", "OK");
                        break;
                    case "умножаем на 9":
                        await DisplayAlert("Ответ", $"{number} x 9 = {number * 9}", "OK");
                        break;
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Введите число от 1 до 10", "OK");
                return; // выходим из функции, если введенное число не подходит
            }

            // Предлагаем что-либо выполнить
            bool answer = await DisplayAlert("Повторить?", "Хотите повторить тест?", "Да", "Нет");
            if (answer)
            {
                // Если пользоват
                OnCheckButtonClicked(sender, e);
            }
        }
            async void OnCheckAlphabetClicked(object sender, EventArgs e)
            {
                await DisplayAlert("Проверка знания алфавита", "Нажмите OK, чтобы начать", "OK");

                bool repeat = true;
                while (repeat)
                {
                    // Вывод случайной буквы алфавита
                    Random random = new Random();
                    char letter = alphabet[random.Next(alphabet.Length)];

                    // Получение ввода пользователя
                    string input = await DisplayPromptAsync($"Введите букву после {letter}", "");

                    // Проверка правильности ввода
                    if (string.IsNullOrEmpty(input))
                    {
                        await DisplayAlert("Ошибка", "Вы не ввели букву", "OK");
                    }
                    else if (char.ToUpper(input[0]) == letter + 1)
                    {
                        await DisplayAlert("Правильно", $"Буква {input.ToUpper()} следует за буквой {letter}", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Неправильно", $"Буква {input.ToUpper()} не следует за буквой {letter}", "OK");
                    }

                    // Предложение повторить тест
                    repeat = await DisplayAlert("Повторить?", "Хотите повторить тест?", "Да", "Нет");
                }
            }
        }
    }

