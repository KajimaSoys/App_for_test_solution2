using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;

namespace App_for_test_solution2
{
    public partial class Form1
    {
        //Строка подключения к MS Access
        string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Questions.mdb;";

        //Поле - ссылка на экземпляр класса OleDbConnection для соединения с БД
        private OleDbConnection myConnection;

        //Библиотека System.Drawing
        Color default_color;
        Color active_color;

        //Переменные для подсчета номера активного вопроса, ответа, правильного ответа и количества правильных ответов соответственно
        int active_question = 0;
        int active_answer = 0;
        int right_answer = 0;
        int count_of_right_answer = 0;

        //Переменная для подсчета процента верных ответов
        double res;
        
        //Переменные для подсчета часов, минут и секунд
        int hour = 0;
        int min = 0;
        int sec = 0;

        //Количество выбранных вопросов
        int qty = 0;
        
        //Массив для хранения вопросов
        string[,] storage = new string[50, 6];

        //Метод, который будет заполнять массив случайными вопросами
        void Array()
        {
            Random rand = new Random();

            //Массив для хранения случайных номеров вопрсов
            int[] id = new int[qty];
            int buf;
            bool contains;
            for (int i = 0; i < id.Length; i++)
            {
                do
                {
                    buf = rand.Next(1, 51);
                    contains = false;
                    for (int index = 0; index < i; index++)
                    {
                        int n = id[index];
                        if (n == buf)
                        {
                            contains = true;
                            break;
                        }
                    }

                } while (contains);
                id[i] = buf;
            }

            //Заполнение массива данными из БД
            for (int i = 0; i < qty; i++)
            {
                //Текст запроса в БД
                string testAnswerRequest = "SELECT text_of_question, text_of_1_answer, text_of_2_answer, text_of_3_answer, text_of_4_answer, right_answer FROM TestStorage WHERE number = " + id[i];

                // создаем объект OleDbCommand для выполнения запроса к БД MS Acces
                OleDbCommand command = new OleDbCommand(testAnswerRequest,myConnection);

                //Выполняем запрос
                OleDbDataReader reader = command.ExecuteReader();

                //Сохраняем результат запроса в многомерный массив storage
                while (reader.Read())
                {
                    storage[i, 0] = (reader[0].ToString());
                    storage[i, 1] = (reader[1].ToString());
                    storage[i, 2] = (reader[2].ToString());
                    storage[i, 3] = (reader[3].ToString());
                    storage[i, 4] = (reader[4].ToString());
                    storage[i, 5] = reader[5].ToString();
                }
                reader.Close();
            }
        }
        
        //запрос данных из БД
        void DataRequest()
        {
            TestName.Text = "("+(active_question+1).ToString()+"/"+qty+") "+storage[active_question, 0];
            button1.Text = storage[active_question, 1];
            button2.Text = storage[active_question, 2];
            button3.Text = storage[active_question, 3];
            button4.Text = storage[active_question, 4];
            right_answer = Convert.ToInt32(storage[active_question, 5]);
        }

        //Окрашиваем кнопки в стандартный цвет
        void SetButtonDefaultColor()
        {
            button1.BackColor = default_color;
            button2.BackColor = default_color;
            button3.BackColor = default_color;
            button4.BackColor = default_color;
        }

        //Обработка ошибки, если не выбран ответ
        void ErrorNonSelectedAnswer()
        {
            string message = "Выберите ответ!!!";
            string caption = "Ошибка!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
        }

        //Обработка ошибки, если не выбрано количество ответов
        void ErrorNonSelectedItem()
        {
            string message = "Введите количество вопросов";
            string caption = "Ошибка!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result1;

            result1 = MessageBox.Show(message, caption, buttons);
        }

        //Настройка форма при начале теста
        void StartTest()
        {
            beginButton.Visible = false;
            TestOptions.Visible = false;
            comboBox1.Visible = false;
            BeginText.Visible = false;
            TestName.Font = new Font("Calibri", 18F);
            button5.Text = "Следующий вопрос";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            timer1.Enabled = true;
            Time.Visible = true;
            
            //Обработка начального текста для времени, чтобы на первом тике не показывались значения с прошлого прохождения теста
            if (hour<1)
                Time.Text = "Оставшееся время\n" + Convert.ToString(min) + ":0" + Convert.ToString(sec);
            else
                Time.Text = "Оставшееся время\n" + Convert.ToString(hour) + ":" + Convert.ToString(min) + ":0" + Convert.ToString(sec);
        }

        //Настройка формы при окончании теста
        void EndTest()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            endButton.Visible = false;
            TestOptions.Visible = true;
            closeButton.Visible = true;
            repeatButton.Visible = true;
            TestOptions.Location = new Point(63, 116);
            TestOptions.Font = new Font("Calibri", 20F);
            TestName.Text = "Тест окончен!!!";
            TestName.Font = new Font("Calibri", 26F);
            Time.Visible = false;
            timer1.Enabled = false;

            res = (double)count_of_right_answer / qty * 100;

            TestOptions.Text = "Количество правильных ответов: " + count_of_right_answer + " / "+qty+" \nПроцент верных ответов: " + Math.Round(res, 0) + "%";
        }

        //Настройка формы при повторе теста
        void RepeatTest()
        {
            beginButton.Visible = true;
            TestName.Text = "Тест по инструментальным средствам информационных систем";
            closeButton.Visible = false;
            repeatButton.Visible = false;
            comboBox1.Visible = true;
            BeginText.Visible = true;
            TestOptions.Location = new Point(63, 171);
            TestOptions.Font = new Font("Calibri", 14F);
            TestOptions.Visible = false;
            comboBox1.Text = "Нажмите сюда для выбора";
            comboBox1.ForeColor = Color.Gray;
            TestName.Font = new Font("Calibri", 24F);
        }
    }
}
