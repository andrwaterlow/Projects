using AppsControl;
using MyApp.Data0;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace MyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListWorkerDataBase dataBase = new ListWorkerDataBase();

        public ObservableCollection<Worker> Workers { get; set; }

        public Worker SelectedWorker { get; set; }





        public MainWindow()
        {
           
            InitializeComponent();
            this.DataContext = this;
            Workers = dataBase.Workers;
            
        }

        private void ListOfWorkers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          if(  e.AddedItems.Count > 0 )
            {
                workerControls.worker = (Worker)SelectedWorker.Clone();
            }
        }

        private void btn_Apply_Click(object sender, RoutedEventArgs e)
        {
            if(ListOfWorkers.SelectedItems.Count < 1)
            {
                return;
            }
            Workers[Workers.IndexOf(SelectedWorker)] = workerControls.worker;
           
            
        }
        

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListOfWorkers.SelectedItems.Count < 1)
            {
                return;
            }
            if (MessageBox.Show("Подтвердить действие?", "Удаление контакта",
            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                dataBase.Workers.Remove((Worker)ListOfWorkers.SelectedItems[0]);
                
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {

            string firstname = "Имя";
            string lastname = "Фамилия";
            string secondname = "Отчевство";
            var department = (WorkerDepartment)7; ;
            int cash = 0;
            bool twoormorediploma = (bool)false;
            var status = (WorkerStatus)3;
            string phone = "Телефон";
            dataBase.Workers.Add(new Worker(firstname, lastname, secondname, cash, department, phone, twoormorediploma, status));
            
        }
    }
}
