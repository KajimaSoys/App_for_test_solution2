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

        int active_question = -1;
        int active_answer = 0;
        int right_answer = 0;
        int count_of_right_answer = 0;


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
            //Вызываем данные из базы
            DataRequest();

            //Задаем видимость для элементов формы после нажатия кнопки Начать тест
            beginButton.Visible = false;
            TestOptions.Visible = false;
            TestName.Font = new Font("Calibri", 20F);
            button5.Text = "Следующий вопрос";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }

        //запрос данных из БД
        void DataRequest()
        {
            //Текст запроса в БД
            string testAnswerRequest = "SELECT text_of_question, text_of_1_answer, text_of_2_answer, text_of_3_answer, text_of_4_answer, right_answer FROM TestStorage ORDER BY number = 1";

            // создаем объект OleDbCommand для выполнения запроса к БД MS Acces
            OleDbCommand command = new OleDbCommand(testAnswerRequest, myConnection);

            //Выполняем запрос
            OleDbDataReader reader = command.ExecuteReader();
            
            //Выводим результат в TestName и в кнопки выбора ответа
            while (reader.Read())
            {
                TestName.Text = (reader[0].ToString());
                button1.Text = (reader[1].ToString());
                button2.Text = (reader[2].ToString());
                button3.Text = (reader[3].ToString());
                button4.Text = (reader[4].ToString());
                right_answer = Convert.ToInt32(reader[5].ToString());
            }
            reader.Close();
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрываем соединение с базой данных
            myConnection.Close();
        }
    }
}
