using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace App_for_test_solution2
{
    partial class Form1 : Form
    {
        //Строка подключения к MS Access
        string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Questions.mdb;";

        //Поле - ссылка на экземпляр класса OleDbConnection для соединения с БД
        private OleDbConnection myConnection;

        //Библиотека System.Drawing
        Color default_color;
        Color active_color;

        int active_question = 0;
        int active_answer = 0;
        int right_answer = 0;
        int count_of_right_answer = 0;
        double res;
        //Переменные для подсчета минут и секунд
        int min = 30;
        int sec = 0;


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

        private void beginButton_Click(object sender, EventArgs e)
        {
            //Метод заполняющий массив вопросами (storage.cs)
            Array();

            SetButtonDefaultColor();

            //Вызываем данные из массива элементов, которые получили от базы данных (storage.cs)
            DataRequest();

            active_question++;

            StartTest();
        }

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

        //Кнопка Следующего вопроса
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

                if (active_question < 14)
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
                Error();
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
                endButton.Visible = false;
            }
            else
            {
                Error();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрываем соединение с базой данных
            myConnection.Close();
        }

        //Реализация повторного прохождения теста
        private void repeatButton_Click(object sender, EventArgs e)
        {
            //Обновление всех переменных на изначальные
            active_question = 0;
            active_answer = 0;
            right_answer = 0;
            count_of_right_answer = 0;

            min = 30;
            sec = 0;

            beginButton.Visible = true;
            TestName.Text = "Тест по инструментальным средствам информационных систем";

            TestOptions.Text = "15 вопросов; 30 минут";
            closeButton.Visible = false;
            repeatButton.Visible = false;
            TestName.Font = new Font("Calibri", 24F);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Реализация таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Тик равен одной секунде, каждую тик значение секунды уменьшается
            sec--;
            if (sec == -1)
            {
                min--;
                sec = 59;
            }
            //Если счетчик дойдет до 0, то откроется форма, что время истекло
            if (min == 0 && sec == 0)
            {
                EndTest();
                TestName.Text = "Время вышло. Тест окончен!!!";
                button5.Visible = false;
                timer1.Enabled = false;
                Time.Visible = false;
            }
            //Вывод времени в форму
            Time.Text ="Время\n" +Convert.ToString(min) + ":"+Convert.ToString(sec);

        }
    }
}
