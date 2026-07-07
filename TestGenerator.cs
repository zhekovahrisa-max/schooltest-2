using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace schooltest_2
{
    
        public class TestGenerator
        {
            private readonly Random random;

            public TestGenerator()
            {
                this.random = new Random();
            }

            
            public List<Question> GetRandomQuestions(List<Question> allQuestions, int count)
            {
                
                List<Question> shuffledList = new List<Question>(allQuestions);

                for (int i = shuffledList.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    var temp = shuffledList[i];
                    shuffledList[i] = shuffledList[j];
                    shuffledList[j] = temp;
                }

                
                return shuffledList.GetRange(0, count);   // samo iskanata broika vzimame
        }

            
            public List<string> ShuffleAnswers(List<string> originalAnswers)
            {
                List<string> shuffled = new List<string>(originalAnswers);
                for (int i = shuffled.Count - 1; i > 0; i--)
                {
                    int j = random.Next(i + 1);
                    string temp = shuffled[i];
                    shuffled[i] = shuffled[j];
                    shuffled[j] = temp;
                }
                return shuffled;
            }
        }
    
}
