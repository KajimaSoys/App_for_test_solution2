using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace App_for_test_solution2
{
    public partial class Form1
    {
        //Массив для хранения вопросов
        string[,] storage = new string[15, 6];

        //Метод, который будет заполнять массив случайными вопросами
        void Array()
        {
            Random rand = new Random();

            //Массив для хранения случайных номеров вопрсов
            int[] id = new int[15];
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
            for (int i = 0; i < 15; i++)
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
            TestName.Text = (active_question+1).ToString()+") "+storage[active_question, 0];
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

        void Error()
        {
            string message = "Выберите ответ!!!";
            string caption = "Ошибка!";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
        }

        //Задаем видимость для элементов формы после нажатия кнопки Начать тест
        void StartTest()
        {
            beginButton.Visible = false;
            TestOptions.Visible = false;
            TestName.Font = new Font("Calibri", 18F);
            button5.Text = "Следующий вопрос";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            timer1.Enabled = true;
            Time.Visible = true;
            button5.Location = new Point(305, 359);
        }

        void EndTest()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            TestOptions.Visible = true;
            closeButton.Visible = true;
            repeatButton.Visible = true;
            TestName.Text = "Тест окончен!!!";
            TestName.Font = new Font("Calibri", 26F);

            res = (double)count_of_right_answer / 15 * 100;

            TestOptions.Text = "Количество правильных ответов: " + count_of_right_answer + " / 15 \nПроцент верных ответов: " + Math.Round(res, 0) + "%";
        }
    }
}
