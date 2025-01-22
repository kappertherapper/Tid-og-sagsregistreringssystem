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

namespace WPF
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly EmployeeBLL EbLL;
        private readonly DepartmentBLL DepartBLL;
        private readonly TaskManagerBLL TaskBLL;

        private DepartmentDTO selectedDepartment;


        private EmployeeDTO selectedEmployee;
        public EmployeeDTO SelectedEmployee // Get employee from list
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }

        private DepartmentDTO selectedDep1419
        artment2;

        private TaskManagerDTO selectedTask;
        public TaskManagerDTO SelectedTask // Get task from list
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }


        public ObservableCollection<EmployeeDTO> Employees { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            EbLL = new EmployeeBLL();
            DepartBLL = new DepartmentBLL();
            TaskBLL = new TaskManagerBLL();

            DisplayEmployees();
            DisplayTasks();

            Employees = new ObservableCollection<EmployeeDTO>(EmployeeBLL.GetAllEmployees());
            DataContext = this;

            DepartmentComboBox.ItemsSource = DepartmentBLL.GetAllDepartments();
            DepartmentComboBox2.ItemsSource = DepartmentBLL.GetAllDepartments();
        }

        private void DisplayEmployees()
        {
            var employees = EmployeeBLL.GetAllEmployees();

            EmployeeListView.ItemsSource = employees;
        }

        private void DisplayTasks()
        {
            var tasks = TaskBLL.GetAllTaskManagers();

            TaskListView.ItemsSource = tasks;
        }

        private void DepartmentComboBox_Text(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedDepartment = DepartmentComboBox.SelectedItem as DepartmentDTO;

        }

        private void DepartmentComboBox2_Text(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedDepartment2 = DepartmentComboBox2.SelectedItem as DepartmentDTO;

        }

        private void Button_AddEmployee(object sender, RoutedEventArgs e)
        {
            var employee = new EmployeeDTO();

            string name = NameInput.Text.Trim();
            string cpr = CprInput.Text.Trim();

            if (!string.IsNullOrEmpty(name) || !string.IsNullOrEmpty(cpr) || selectedDepartment != null)
            {
                employee.Name = name;
                employee.Cpr = cpr;
                employee.DepartmentId = selectedDepartment.Id;
                EmployeeBLL.AddEmployee(employee);

                // Clear fields
                NameInput.Text = string.Empty;
                CprInput.Text = string.Empty;
                DepartmentComboBox.SelectedItem = null;

                DisplayEmployees();
            }
            else
            {
                MessageBox.Show("fejl i indtastning", "Fejl", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_AddTask(object sender, RoutedEventArgs e)
        {
            var task = new TaskManagerDTO();

            string title = TitleInput.Text.Trim();
            var taskNumber = int.Parse(TaskNumberInput.Text);
            string description = DescriptionInput.Text.Trim();

            if (!string.IsNullOrEmpty(title) || taskNumber > 0 || !string.IsNullOrEmpty(description) || selectedDepartment2 != null)
            {
                task.Title = title;
                task.Description = description;
                task.TaskNumber = taskNumber;
                task.DepartmentId = selectedDepartment2.Id;
                TaskBLL.AddTaskManager(task);

                TitleInput.Text = string.Empty;
                TaskNumberInput.Text = string.Empty;
                DescriptionInput.Text = string.Empty;
                DepartmentComboBox2.SelectedItem = null;

                DisplayTasks();
            }
            else
            {
                MessageBox.Show("Fejl i indtastning", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_EditEmployee(object sender, RoutedEventArgs e)
        {
            if (SelectedEmployee != null)
            {
                string updatedName = NameInput.Text.Trim();
                string updatedCpr = CprInput.Text.Trim();
                var updatedDepartment = selectedDepartment;

                if (!string.IsNullOrEmpty(updatedName) || !string.IsNullOrEmpty(updatedCpr) || updatedDepartment != null)
                {
                    SelectedEmployee.Name = !string.IsNullOrEmpty(updatedName) ? updatedName : SelectedEmployee.Name;
                    SelectedEmployee.Cpr = !string.IsNullOrEmpty(updatedCpr) ? updatedCpr : SelectedEmployee.Cpr;
                    SelectedEmployee.DepartmentId = updatedDepartment?.Id ?? SelectedEmployee.DepartmentId;

                    EmployeeBLL.EditEmployee(SelectedEmployee);

                    // Clear fields
                    NameInput.Text = string.Empty;
                    CprInput.Text = string.Empty;
                    DepartmentComboBox.SelectedItem = null;

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

        private void Button_EditTask(object sender, EventArgs e)
        {
            if (SelectedTask != null)
            {
                string updatedTitle = TitleInput.Text.Trim();
                int? updatedTaskNumber = null;
                string updatedDescription = DescriptionInput.Text.Trim();
                var updatedDepartment = selectedDepartment2;

                if (!string.IsNullOrWhiteSpace(TaskNumberInput.Text) && int.TryParse(TaskNumberInput.Text, out var taskNumber))
                {
                    updatedTaskNumber = taskNumber;
                }

                if (!string.IsNullOrEmpty(updatedTitle) || updatedTaskNumber > 0 || !string.IsNullOrEmpty(updatedDescription) || updatedDepartment != null)
                {
                    SelectedTask.Title = !string.IsNullOrEmpty(updatedTitle) ? updatedTitle : selectedTask.Title;
                    selectedTask.TaskNumber =  updatedTaskNumber ?? selectedTask.TaskNumber;
                    SelectedTask.Description = !string.IsNullOrEmpty(updatedDescription) ? updatedDescription : selectedTask.Description;
                    SelectedTask.DepartmentId = updatedDepartment?.Id ?? selectedTask.DepartmentId;

                    TaskManagerBLL.EditTaskManager(SelectedTask);

                    // Clear fields
                    TitleInput.Text = string.Empty;
                    TaskNumberInput.Text = string.Empty;
                    DescriptionInput.Text = string.Empty;
                    DepartmentComboBox2.SelectedItem = null;

                    // Update list
                    DisplayTasks();

                    MessageBox.Show("opgave opdateret", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("mindst udfyldt et felt", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("ingen opgave valgt", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
