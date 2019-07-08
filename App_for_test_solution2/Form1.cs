using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;


namespace App_for_test_solution2
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // создаем экземпляр класса OleDbConnection
            myConnection = new OleDbConnection(connectString);

            // открываем соединение с БД
            myConnection.Open();

            //Задаем цвета для клавиш в состоянии покоя и в активном режиме
            default_color = Color.FromKnownColor(KnownColor.Control);
            active_color = Color.LightBlue;
        }

        //Кнопки выбора правильного ответа
        private void button1_Click(object sender, EventArgs e)
        {
            SetButtonDefaultColor();
            button1.BackColor = active_color;
            active_answer = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetButtonDefaultColor();
            button2.BackColor = active_color;
            active_answer = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetButtonDefaultColor();
            button3.BackColor = active_color;
            active_answer = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetButtonDefaultColor();
            button4.BackColor = active_color;
            active_answer = 4;
        }

        //Реализация нажатия кнопки "Запуск теста"
        private void beginButton_Click(object sender, EventArgs e)
        {
            if (qty == 0)
            {
                ErrorNonSelectedItem();
            }
            else
            {
                //Метод заполняющий массив вопросами (storage.cs)
                Array();

                //Окрашиваем кнопки в стандартный цвет (storage.cs)
                SetButtonDefaultColor();

                //Вызываем данные из массива элементов, которые получили от базы данных (storage.cs)
                DataRequest();

                //Счетчик текущего вопроса
                active_question++;

                //Изменение формы
                StartTest();
            }
        }

        //Реализация нажатия кнопки "Следующий вопрос"
        private void button5_Click(object sender, EventArgs e)
        {
            if (active_answer != 0)
            {
                if (active_answer == right_answer)
                {
                    count_of_right_answer++;
                }
                SetButtonDefaultColor();
                DataRequest();

                if (active_question < (qty-1))
                {
                    DataRequest();
                    active_question++;
                }
                else
                {
                    endButton.Text = "Завершить тест";
                    endButton.Visible = true;
                    button5.Visible = false;
                }
                active_answer = 0;
            }
            //Обработка ошибки
            else
            {
                ErrorNonSelectedAnswer();
            }
        }

        //Реализация нажатия кнопки "Завершить тест"
        private void endButton_Click(object sender, EventArgs e)
        {
            if (active_answer != 0)
            {
                if (active_answer == right_answer)
                {
                    count_of_right_answer++;
                }
                EndTest();
            }
            else
            {
                ErrorNonSelectedAnswer();
            }
        }
        
        //Реализация повторного прохождения теста
        private void repeatButton_Click(object sender, EventArgs e)
        {
            //Обновление всех переменных на изначальные
            active_question = 0;
            active_answer = 0;
            right_answer = 0;
            count_of_right_answer = 0;
            qty = 0;

            //Обновляем форму
            RepeatTest();
        }

        //Закрытие теста при нажатии кнопки "Выход из теста"
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Закрываем соединение с базой данных при закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        //Реализация таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Тик равен одной секунде, каждый тик значение секунды уменьшается
            sec--;
            if (sec == -1)
            {
                min--;
                sec = 59;
            }
            if (min == -1)
            {
                hour--;
                min = 59;
            }
            
            //Если счетчик дойдет до 0, то откроется форма, что время истекло
            if (hour ==0 && min == 0 && sec == 0)
            {
                EndTest();
                TestName.Text = "Время вышло. Тест окончен!!!";
            }

            //Вывод времени в форму
            if (hour < 1)
            {
                if (sec > 9) //12:54
                    Time.Text = "Оставшееся время\n" + Convert.ToString(min) + ":" + Convert.ToString(sec);
                else         //12:04
                    Time.Text = "Оставшееся время\n" + Convert.ToString(min) + ":0" + Convert.ToString(sec);
                
            }
            else
            {
                if (min > 9)
                {
                    if (sec > 9) //1:12:54
                        Time.Text = "Оставшееся время\n" + Convert.ToString(hour) + ":" + Convert.ToString(min) + ":" + Convert.ToString(sec);
                    else         //1:12:04
                        Time.Text = "Оставшееся время\n" + Convert.ToString(hour) + ":" + Convert.ToString(min) + ":0" + Convert.ToString(sec);
                }
                else
                {
                    if (sec > 9) //1:02:54
                        Time.Text = "Оставшееся время\n" + Convert.ToString(hour) + ":0" + Convert.ToString(min) + ":" + Convert.ToString(sec);
                    else         //1:02:04
                        Time.Text = "Оставшееся время\n" + Convert.ToString(hour) + ":0" + Convert.ToString(min) + ":0" + Convert.ToString(sec);
                }
            }
        }

        //При входе в элемент выпадающего списка цвет текста в нем становится черным
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.Black;
        }

        //Обработка события выбранного элемента из выпадающего списка
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            qty = Convert.ToInt32(comboBox1.SelectedItem);
            hour = 0;
            min = 0;
            sec = 0;
            TestOptions.Visible = true;

            //Изменение времени при соответвующем количестве вопросов
            switch (Convert.ToInt32(comboBox1.SelectedItem))
            {
                case 5:
                    hour = 0;
                    min = 10;
                    break;
                case 10:
                    hour = 0;
                    min = 20;
                    break;
                case 15:
                    hour = 0;
                    min = 30;
                    break;
                case 20:
                    hour = 0;
                    min = 40;
                    break;
                case 25:
                    hour = 0;
                    min = 50;
                    break;
                case 30:
                    hour = 1;
                    min = 0;
                    break;
                case 35:
                    hour = 1;
                    min = 10;
                    break;
                case 40:
                    hour = 1;
                    min = 20;
                    break;
                case 45:
                    hour = 1;
                    min = 30;
                    break;
                case 50:
                    hour = 1;
                    min = 40;
                    break;
            }

            //Вывод указанных параметров в TestOptions
            if (hour < 1) //Выбрано 15 вопросов; Время на выполнение: 30 минут
                TestOptions.Text = "Выбрано " + comboBox1.SelectedItem.ToString() + " вопросов\nВремя на выполнение: "+ min.ToString() + " минут";
            else          //Выбрано 50 вопросов; Время на выполнение: 1 час 40 минут
                TestOptions.Text = "Выбрано " + comboBox1.SelectedItem.ToString() + " вопросов\nВремя на выполнение: " + hour.ToString() + " час " + min.ToString() + " минут";
                          //Выбрано 30 вопросов; Время на выполнение: 1 час
            if (hour == 1 && min==0)
                TestOptions.Text = "Выбрано " + comboBox1.SelectedItem.ToString() + " вопросов\nВремя на выполнение: " + hour.ToString() + " час";
        }
    }
}
