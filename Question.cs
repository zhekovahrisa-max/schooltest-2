using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schooltest_2
{
    
        public class Question
        {
            public int Id { get; set; }
            public string QuestionText { get; set; }
            public List<string> Answers { get; set; }
            public int CorrectAnswerId { get; set; } 
            public Question(int id, string text, List<string> answers, int correctAnswerId)
            {
                this.Id = id;
                this.QuestionText = text;
                this.Answers = answers;
                this.CorrectAnswerId = correctAnswerId;
            }
        }
    
}
