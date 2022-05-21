using MyApp.Data0;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp
{
     class ListWorkerDataBase
    {
        private static string[] FirstName = { "Казинак", "Шамиль", "Иван", "Шмель", "Зулейка", "Рахат", "Ирина", "Анастасия", "Джо" };
        private static string[] LastName = { "Петручо", "Кашица", "Дуралий", "Дайпюва", "Наклейка", "Камнепад", "Погань", "Иванов", "Сардина" };
        private static string[] SecondName = { "Кларович", "Вахтанговна", "Петрович", "Мюслимович", "Батьковна", "Дуралеевич", "Капнуглубокович", "Ирисковна", "АлександровичЪ" };

        private static string[] PhonePrefix = { "495", "499" }; // Приставка к телефону
        

        private Random random = new Random();

        public ObservableCollection<Worker> Workers { get; set; }

        public ListWorkerDataBase  ()
        {
            Workers = new ObservableCollection<Worker>();
            GenerateListWorkers(30);
        }


        private string GenerateFirstName()
        {
            string firstname = FirstName[random.Next(0, 9)];
            return firstname;

        }

        private string GenerateLastName()
        {
            string lastname = LastName[random.Next(0, 9)];
            return lastname;

        }

        private string GenerateSecondName()
        {
            string secondname = SecondName[random.Next(0, 9)];
            return secondname;

        }

        private string GeneratePhone()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("+7").Append(PhonePrefix[random.Next(0, 2)]);
            for (int i = 0; i < 6; i++)
            {
                stringBuilder.Append(random.Next(0, 10)) ;
            }
            return stringBuilder.ToString();
        }

        private void GenerateListWorkers(int count)
        {
            Workers.Clear();

            string firstname = GenerateFirstName();
            string lastname =  GenerateLastName();
            string secondname = GenerateSecondName();
            var department = (WorkerDepartment)random.Next(0, 7);
            int cash = 1000 * random.Next(3, 11);
            bool twoormorediploma = random.Next(0, 2) == 0 ? false : true;
            var status = (WorkerStatus)random.Next(0, 3);

            for (int i = 0; i < count; i++)
            {
                if (random.Next(0, 2) == 0)
                {
                    firstname = GenerateFirstName();
                    lastname = GenerateLastName();
                    secondname = GenerateSecondName();
                    department = (WorkerDepartment)random.Next(0, 7);
                    cash = 1000 * random.Next(3, 11);
                    twoormorediploma = random.Next(0, 2) == 0 ? false : true;
                    status = (WorkerStatus)random.Next(0, 3);
                    
                }
                string phone = GeneratePhone();
                Workers.Add(new Worker(firstname, lastname, secondname, cash, department, phone, twoormorediploma, status));

            }
        }
    }
}
