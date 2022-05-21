using MyApp.Data0;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppsControl
{
    /// <summary>
    /// Логика взаимодействия для WorkerControls.xaml
    /// </summary>
    public partial class WorkerControls : UserControl, INotifyPropertyChanged
    {
        private Worker Worker;

        public Worker worker { get { return Worker; } set { Worker = value; NotifyPropertyChanged(); } }

        public ObservableCollection<WorkerStatus> ListStatus = new ObservableCollection<WorkerStatus>();

        public ObservableCollection<WorkerDepartment> ListDepartment = new ObservableCollection<WorkerDepartment>();


        public  WorkerControls()
        {
            InitializeComponent();

            this.DataContext = this;
            ListStatus.Add(WorkerStatus.Fired);
            ListStatus.Add(WorkerStatus.InWork);
            ListStatus.Add(WorkerStatus.None);
            ListStatus.Add(WorkerStatus.Vacation);

            ListDepartment.Add(WorkerDepartment.Eduation);
            ListDepartment.Add(WorkerDepartment.Food);
            ListDepartment.Add(WorkerDepartment.IT);
            ListDepartment.Add(WorkerDepartment.Killer);
            ListDepartment.Add(WorkerDepartment.Medicine);
            ListDepartment.Add(WorkerDepartment.None);
            ListDepartment.Add(WorkerDepartment.Services);
            ListDepartment.Add(WorkerDepartment.Washman);

            cb_Department.ItemsSource = Enum.GetValues(typeof(WorkerDepartment)).Cast<WorkerDepartment>();
            cb_Status.ItemsSource = Enum.GetValues(typeof(WorkerStatus)).Cast<WorkerStatus>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

       
        



    }
}
