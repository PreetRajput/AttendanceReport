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
using MySqlConnector;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace student
{
    public partial class MainWindow
    {
        public void updatePercentage()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string task = "UPDATE subattendance SET attendancePercentage = ( CASE WHEN totalDays= 0 then 0 ELSE ((daysAttended/totalDays)*100) END)";
            MySqlCommand command = new MySqlCommand(task, connection);
            command.ExecuteNonQuery();
            subAttendDisplay();
            string task2 = "UPDATE labattendance SET attendancePercentage= (CASE WHEN totalDays = 0 THEN 0 ELSE ((daysAttended/totalDays)*100) END)";
            MySqlCommand command2 = new MySqlCommand(task2, connection);
            command2.ExecuteNonQuery();
            labAttendDisplay();
            connection.Close();
        }
    }
}
