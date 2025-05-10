using MySqlConnector;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {
        string anotherTrash;
        string trash, lab, labTrash,gbtn;
        string[] periods= new string[6];
        string connectionString = "SERVER=localhost;DATABASE=timetable;UID=root;PASSWORD=preet@2005;";
        string day = DateTime.Now.DayOfWeek.ToString();
        List<string> subAttended = new List<string>();
        List<string> labAttended = new List<string>();
        List<string> totalSubPeriod= new List<string>();
        List<string> totalLabPeriod= new List<string>();
        
        public MainWindow()
        {
            if (day!= "Sunday")
            {
                
            InitializeComponent();
            today.Text= $" {DateTime.Now.ToString("dd-MM-yyyy")}     {DateTime.Now.DayOfWeek.ToString()}";
            subAndLabDisplay();
            subAttendDisplay();
            labAttendDisplay();
            }
            else
            {
                MessageBox.Show("Today is Sunday No changes can be done ");
            }
        }
        private void analysisWindow(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("analysisPage.xaml", UriKind.Relative));
        }
    }
    public class impVar
    {
        private int absentKey = 0;
        public int absentkey
        {
            get { return absentKey; }
            set { absentKey = value; }

        }

    }
}
