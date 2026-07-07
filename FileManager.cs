using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

namespace schooltest_2
{
   
        public class FileManager
        {
            private readonly string inputFilePath;

            public FileManager(string inputFilePath)
            {
                this.inputFilePath = inputFilePath;
            }

            // toq clas proverqva dali ima izbrani testove ot predi
            public bool CheckIfTestsExist()
            {
                return File.Exists("test1.txt"); // gabi ako test 1 sushtestvuva e pusnata predi 
            }

            // tui prochita vuprositge ot faila
            public List<Question> LoadQuestions()
            {
                List<Question> questions = new List<Question>();

                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException($"Грешка: Входящият файл '{inputFilePath}' не е намерен!");
                }

                string[] lines = File.ReadAllLines(inputFilePath);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split(','); 

                    if (parts.Length >= 7)
                    {
                        int id = int.Parse(parts[0].Trim());
                        string text = parts[1].Trim();
                        List<string> answers = new List<string>
                    {
                        parts[2].Trim(), parts[3].Trim(), parts[4].Trim(), parts[5].Trim()
                    };
                        int correctAnswer = int.Parse(parts[6].Trim()); 

                        questions.Add(new Question(id, text, answers, correctAnswer));
                    }
                }

                return questions;
            }

            // yui zappisva edin test vuv fail
            public void SaveTest(string fileName, List<Question> questions, int testNumber)
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"================ ТЕСТ №{testNumber} ================");
                    writer.WriteLine($"Генериран на: {DateTime.Now}");
                    writer.WriteLine("==================================================\n");

                    int counter = 1;
                    foreach (var q in questions)
                    {
                        writer.WriteLine($"{counter}. {q.QuestionText}");

                        char option = 'А';
                        foreach (var ans in q.Answers)
                        {
                            writer.WriteLine($"   {option}) {ans}");
                            option++;
                        }
                        writer.WriteLine();
                        counter++;
                    }
                }
            }
        }
    
}

