using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace App_for_test_solution2
{
    public partial class Form1 : Form
    {

        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=Questions.mdb;";

        Color default_color;
        Color active_color;


        int active_question = -1;
        int active_answer = 0;

        int count_of_right_answer = 0;




        public Form1()
        {
            InitializeComponent();

            default_color = Color.FromKnownColor(KnownColor.Control);
            active_color = Color.LightBlue;

        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            beginButton.Visible = false;
            TestOptions.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;

            //SetButtonDefaultColor();

            button5.Text = "Следующий вопрос";

        }

        void SetButtonDefaultColor()
        {
            button1.BackColor = default_color;
            button2.BackColor = default_color;
            button3.BackColor = default_color;
            button4.BackColor = default_color;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
