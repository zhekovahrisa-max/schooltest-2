using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace schooltest_2
{
     
        public class Engine
        {
            private readonly FileManager fileManager;
            private readonly TestGenerator testGenerator;

            public Engine()
            {
                // Инициализираме другите класове (компоненти)
                this.fileManager = new FileManager("questions.txt");
                this.testGenerator = new TestGenerator();
            }

            public void Run()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                // tuka e popravkata za starite vuprosi
                if (fileManager.CheckIfTestsExist())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Внимание: Открити са съществуващи тестове (test1.txt) от предходно пускане!");
                    Console.WriteLine("Моля, изтрийте ги или ги преместете ръчно, преди ново генериране.");
                    Console.ResetColor();
                    return; // Спираме изпълнението
                }

                // zarejdaneto na vuprosi e tuk 
                List<Question> allQuestions;
                try
                {
                    allQuestions = fileManager.LoadQuestions();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                // potrbiterlsko menyu
                Console.WriteLine("=== Проект: ГЕНЕРАТОР НА УЧИЛИЩНИ ТЕСТОВЕ ===");
                Console.Write("Въведете брой тестове за генериране: ");
                int testsCount = int.Parse(Console.ReadLine());

                Console.Write("Въведете брой въпроси за всеки тест: ");
                int questionsPerTest = int.Parse(Console.ReadLine());

                // validaciq
                if (questionsPerTest > allQuestions.Count)
                {
                    Console.WriteLine($"Грешка! В базата има само {allQuestions.Count} въпроса, а вие искате {questionsPerTest} в тест.");
                    return;
                }

                
                for (int i = 1; i <= testsCount; i++)
                {
                    List<Question> selectedQuestions = testGenerator.GetRandomQuestions(allQuestions, questionsPerTest);
                    
                    foreach (var q in selectedQuestions)
                    {
                        q.Answers = testGenerator.ShuffleAnswers(q.Answers); 
                    }

                   
                    string fileName = $"test{i}.txt"; 
                    fileManager.SaveTest(fileName, selectedQuestions, i);
                    Console.WriteLine($"Успешно генериран: {fileName}");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nВсички тестове са създадени успешно!");
                Console.ResetColor();
            }
        }
   
}
