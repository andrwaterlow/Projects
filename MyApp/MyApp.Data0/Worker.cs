using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Data0
{
    public class Worker : INotifyPropertyChanged, ICloneable 
    {
        private string firstName;
        private string lastName;
        private string secondName;
        private int cashInMounth;
        private WorkerDepartment department;
        private string phone;
        private WorkerStatus status;
        private bool twoOrMoreDiploma;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string FirstName { get { return firstName; } set { firstName = value; NotifyPropertyChanged(); } }

        public string LastName { get { return lastName; } set { lastName = value; NotifyPropertyChanged(); } }

        public string SecondName { get { return secondName; } set { secondName = value; NotifyPropertyChanged(); } }

        public int CashInMounth { get { return cashInMounth; } set { cashInMounth = value; NotifyPropertyChanged(); } }

        public  WorkerDepartment Department { get { return department; } set { department = value; NotifyPropertyChanged(); } }

        public string Phone { get { return phone; } set { phone = value; NotifyPropertyChanged(); } }

        public WorkerStatus Status { get { return status; } set { status = value; NotifyPropertyChanged(); } }

        public bool TwoOrMoreDiploma { get { return twoOrMoreDiploma; } set { twoOrMoreDiploma = value; NotifyPropertyChanged(); } }


        public override string ToString()
        {
            return $"{LastName} {FirstName} {SecondName} {Department} {CashInMounth} {Phone}";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public Worker(string firstname, string lastname, string secondname, int cash, WorkerDepartment department, string phone, bool twoormorediploma, WorkerStatus status)
        {
            FirstName = firstname;
            LastName = lastname;
            SecondName = secondname;
            CashInMounth = cash;
            Department = department;
            Phone = phone;
            TwoOrMoreDiploma = twoormorediploma;
            Status = status;
        }
         public string FIO
        {
            get { return $"{LastName} {FirstName} {SecondName} "; }
        }

        public event PropertyChangedEventHandler PropertyChanged;



    }
}
