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
using Newtonsoft.Json;

namespace Task_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        string path = @"C:\Tasks\ts.txt";
        string path1 = @"C:\Tasks";
        List<Tasks> list = new List<Tasks>();
        string s = "";
        public MainWindow()
        {
            InitializeComponent();
            if (Directory.Exists(path1))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                    {
                        s = sr.ReadToEnd();
                        if (s != "[]")
                        {
                            list = JsonConvert.DeserializeObject<List<Tasks>>(s);
                            GetRefresh();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            DirectoryInfo di = Directory.CreateDirectory(path1);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int lc = list.Count;
            list.Add(new Tasks(lc + 1, DateTime.Now, TextOfTask.Text));
            GetRefresh();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                try
                {
                    System.IO.File.SetAttributes(path, System.IO.FileAttributes.Normal);
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {

                        sw.Write(JsonConvert.SerializeObject(list));

                    }
                    System.IO.File.SetAttributes(path, System.IO.FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.Write(JsonConvert.SerializeObject(list));
                    }
                    System.IO.File.SetAttributes(path, System.IO.FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        private void GetRefresh()
        {
            tasksGrid.ItemsSource = list;
            tasksGrid.Items.Refresh();
        }
    }
}
