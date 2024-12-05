using System;
using System.Collections.Generic;
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
using BLL.BLL;
using DTO.Models;

namespace GUII
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeBLL EbLL;

        public MainWindow()
        {
            InitializeComponent();
            EbLL = new EmployeeBLL();

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            List<EmployeeDTO> employees = EbLL.GetAllEmployees();

            EmployeeListView.ItemsSource = employees;
        }

        public void AddEmployee()
        {
            //MyItems.Add("New Item");
        }

        public void RemoveEmployee(EmployeeDTO employee)
        {
            //MyItems.Remove(item);
        }
    }
}
