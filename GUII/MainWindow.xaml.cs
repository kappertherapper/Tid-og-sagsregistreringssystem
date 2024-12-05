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
    public partial class MainWindow : Window
    {
        private EmployeeBLL EbLL;
        private DepartmentBLL DepartBLL;
        private DepartmentDTO selectedDepartment;

        public MainWindow()
        {
            InitializeComponent();
            EbLL = new EmployeeBLL();
            DepartBLL = new DepartmentBLL();


            DisplayEmployees();
            DepartmentComboBox.ItemsSource = DepartBLL.GetAllDepartments();
        }

        private void DisplayEmployees()
        {
            List<EmployeeDTO> employees = EbLL.GetAllEmployees();

            EmployeeListView.ItemsSource = employees;
        }

        private void DepartmentComboBox_Text(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedDepartment = DepartmentComboBox.SelectedItem as DepartmentDTO;

        }

        private void Button_AddEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeDTO employee = new EmployeeDTO();

            string name = NameInput.Text.Trim();
            string cpr = CprInput.Text.Trim();

            if (name != null || cpr != null || selectedDepartment != null)
            {
                employee.Name = name;
                employee.Cpr = cpr;
                employee.DepartmentId = selectedDepartment.Id;
                EbLL.AddEmployee(employee);

                NameInput.Text = string.Empty;
                CprInput.Text = string.Empty;

                DisplayEmployees();
            }
            else
            {
                MessageBox.Show("fejl i indtastning", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
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
