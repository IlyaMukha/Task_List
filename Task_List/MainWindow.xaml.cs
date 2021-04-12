using System;
using System.Collections.Generic;
using System.IO;
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

namespace Task_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\Temp\ts.txt";
        List<Tasks> list = new List<Tasks>();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            list.Add(new Tasks(list.Count + 1, list.Count, TextOfTask.Text));
            tasksGrid.ItemsSource = list;
            tasksGrid.Items.Refresh();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(TextOfTask.Text);

                }
                MessageBox.Show("Файл был успешно записан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
