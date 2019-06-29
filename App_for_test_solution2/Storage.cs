using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_for_test_solution2
{
    class Storage
    {
        public string question;
        public string[] answers = new string[4];
        public int right_answer;

        public Storage(string l_question, string answer_1, string answer_2, string answer_3, string answer_4, int l_right_answer)
        {
            question = l_question;

            answers[0] = answer_1;
            answers[1] = answer_2;
            answers[2] = answer_3;
            answers[3] = answer_4;

            right_answer = l_right_answer;
        }

    }
}
