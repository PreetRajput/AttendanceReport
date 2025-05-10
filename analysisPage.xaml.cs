using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
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

namespace student
{
    public partial class analysisPage : Page
    {
         static string connectionString =  "SERVER=localhost;DATABASE=timetable;UID=root;PASSWORD=preet@2005;";
         static  MySqlConnection connection = new MySqlConnection(connectionString);
         int editedText;
        string subOrLab;
        string editedColumn;
        int trash=0;
        public analysisPage()
        {
            InitializeComponent();
            connection.Open();
            string Task = "SELECT * FROM subattendance";
            string task1 = "SELECT * FROM labattendance";
            string task2 = "SELECT * FROM worktable";
            MySqlCommand cmd = new MySqlCommand(Task, connection);
            MySqlCommand cmd1 = new MySqlCommand(task1, connection);
            MySqlCommand cmd2 = new MySqlCommand(task2, connection);
            DataTable dt= new DataTable();
            DataTable dt1= new DataTable();
            DataTable dt2= new DataTable();
            dt.Load(cmd.ExecuteReader());
            dt1.Load(cmd1.ExecuteReader());
            dt2.Load(cmd2.ExecuteReader());
            connection.Close();
            displayGrid.ItemsSource = dt.DefaultView;
            displayGrid1.ItemsSource = dt1.DefaultView;
            displayGrid2.ItemsSource = dt2.DefaultView;
        }

        private void displayGrid_LostFocus(object sender, RoutedEventArgs e)
        {
            DataGrid dg= sender as DataGrid;
            dg.SelectedItem = null;
        }
        private void changeDone(object sender, DataGridCellEditEndingEventArgs e)
        {
            trash = 1;
            if (e.EditingElement is TextBox editedBox)
            {
                editedText = int.Parse(editedBox.Text);
            }
            var editedItem   = e.Row.Item as DataRowView;
            subOrLab     = editedItem[0].ToString();
            editedColumn = e.Column.Header.ToString();


        }

        private void displayGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName=="labs")
            {
                e.Column.IsReadOnly = true;
            }
            else if(e.PropertyName=="subjects")
            {
                e.Column.IsReadOnly = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (trash==1)
            {
                
                if (subOrLab.Contains("LAB"))
                {
                    connection.Open();
                    string task = $"UPDATE labattendance SET {editedColumn} = {editedText} WHERE labs= '{subOrLab}'";
                    MySqlCommand command = new MySqlCommand(task, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
                }
                else
                {
                    connection.Open();
                    string task = $"UPDATE subattendance SET {editedColumn} = {editedText} WHERE subjects= '{subOrLab}'";
                    MySqlCommand command = new MySqlCommand(task, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));

                }
            }
            else
            {
                this.NavigationService.Navigate(new Uri("MainWindow.xaml", UriKind.Relative));
            }
            trash= 0;

        }
        private void backButton(object sender, EventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
    public class Table
    {
        public string subject
        { get
            {
                return subject;
            } set
            {
                subject = value;
            }
         } 
        public int attendancePercentage  { get; set; }
        public int daysAttended { get; set; } 
        public int totalDays { get; set; }
    }
}
