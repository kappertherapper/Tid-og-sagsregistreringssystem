using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private TaskManagerBLL TaskBLL;

        private DepartmentDTO selectedDepartment;
        private EmployeeDTO selectedEmployee;

        public ObservableCollection<EmployeeDTO> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            EbLL = new EmployeeBLL();
            DepartBLL = new DepartmentBLL();
            TaskBLL = new TaskManagerBLL();


            DisplayEmployees();
            DisplayTasks();
            DepartmentComboBox.ItemsSource = DepartBLL.GetAllDepartments();
        }

        private void DisplayEmployees()
        {
            List<EmployeeDTO> employees = EbLL.GetAllEmployees();

            EmployeeListView.ItemsSource = employees;
        }

        private void DisplayTasks()
        {
            List<TaskManagerDTO> tasks = TaskBLL.GetAllTaskManagers();

            TaskListView.ItemsSource = tasks;
        }

        public EmployeeDTO SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
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

            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(cpr) || selectedDepartment != null)
            {
                employee.Name = name;
                employee.Cpr = cpr;
                employee.DepartmentId = selectedDepartment.Id;
                EbLL.AddEmployee(employee);

                // Clear fields
                NameInput.Text = string.Empty;
                CprInput.Text = string.Empty;

                DisplayEmployees();
            }
            else
            {
                MessageBox.Show("fejl i indtastning", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void RemoveEmployee(EmployeeDTO employee)
        {
            //MyItems.Remove(item);
        }

        private void Button_EditEmployee(object sender, RoutedEventArgs e)
        {
            if (selectedEmployee != null)
            {
                string updatedName = NameInput.Text.Trim();
                string updatedCpr = CprInput.Text.Trim();
                DepartmentDTO updatedDepartment = selectedDepartment;

                if (!string.IsNullOrEmpty(updatedName) || !string.IsNullOrEmpty(updatedCpr) || updatedDepartment != null)
                {
                    selectedEmployee.Name = updatedName;
                    selectedEmployee.Cpr = updatedCpr;
                    selectedEmployee.DepartmentId = updatedDepartment.Id;

                    EbLL.EditEmployee(selectedEmployee);

                    // Clear fields
                    NameInput.Text = string.Empty;
                    CprInput.Text = string.Empty;

                    // Update list
                    DisplayEmployees();

                    MessageBox.Show("medarbejder opdateret", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("mindst udfyldt et felt", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("ingen medarbejder valgt", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
