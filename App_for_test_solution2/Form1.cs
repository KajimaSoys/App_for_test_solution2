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
    public partial class Form1 : Form
    {
        //Строка подключения к MS Access
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Questions.mdb;";
        //public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Questions.mdb;";

        //Поле - ссылка на экземпляр класса OleDbConnection для соединения с БД
        private OleDbConnection myConnection;

        //Библиотека System.Drawing
        Color default_color;
        Color active_color;

        int active_question = 0;
        int active_answer = 0;
        int right_answer = 0;
        int count_of_right_answer = 0;

        string[,] storage = new string[15, 6];

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
            Array();

            //Вызываем данные из массива элементов, которые получили от базы данных
            DataRequest();

            active_question++;

            //Задаем видимость для элементов формы после нажатия кнопки Начать тест
            beginButton.Visible = false;
            TestOptions.Visible = false;
            TestName.Font = new Font("Calibri", 18F);
            button5.Text = "Следующий вопрос";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            
        }

        //создадим массив для хранения вопросов
        public void Array()
        {
            Random rand = new Random();

            //Создали массив для хранения случайных номеров вопрсов
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

            //создадим массив для хранения самих данных вопроса
            
            for (int i = 0; i < 15; i++)
            {
                //Текст запроса в БД
                string testAnswerRequest = "SELECT text_of_question, text_of_1_answer, text_of_2_answer, text_of_3_answer, text_of_4_answer, right_answer FROM TestStorage WHERE number = "+id[i];
               
                // создаем объект OleDbCommand для выполнения запроса к БД MS Acces
                OleDbCommand command = new OleDbCommand(testAnswerRequest, myConnection);

                //Выполняем запрос
                OleDbDataReader reader = command.ExecuteReader();

                //Сохраняем результат запроса в многомерный массив storage
                while (reader.Read())
                {
                    storage[i,0] = (reader[0].ToString());
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
            //for (int i = 0; i<)

            //Выводим результат в TestName и в кнопки выбора ответа
            //while (reader.Read())
            //{
            TestName.Text = storage[active_question, 0];
            button1.Text = storage[active_question, 1];
            button2.Text = storage[active_question, 2];
            button3.Text = storage[active_question, 3];
            button4.Text = storage[active_question, 4];
            right_answer = Convert.ToInt32(storage[active_question, 5]);
            //}
            //reader.Close();
        }
        
        //Окрашиваем кнопки в стандартный цвет
        void SetButtonDefaultColor()
        {
            button1.BackColor = default_color;
            button2.BackColor = default_color;
            button3.BackColor = default_color;
            button4.BackColor = default_color;
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
                button5.Visible = false;
                endButton.Visible = true;
                endButton.Text = "Завершить тест";
            }
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            if (active_answer == right_answer)
            {
                count_of_right_answer++;
            }
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            TestOptions.Visible = true;
            TestName.Text = "Тест окончен!!!";
            TestName.Font = new Font("Calibri", 26F);
            TestOptions.Text = "Количество верных ответов: " + count_of_right_answer + " / 15";
            endButton.Visible = false;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрываем соединение с базой данных
            myConnection.Close();
        }
    }
}
