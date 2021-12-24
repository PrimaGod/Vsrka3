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
using System.Data;
using System.Data.Entity;

namespace Vsrka3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class CourseRegistration
        {
            public int Id { get; set; }
            public int TrainerId { get; set; }
            public int CourseId { get; set; }
            public string CreateDate { get; set; }
            public string IsDone { get; set; }
            public string TotalPoint { get; set; }
            public string CertificateImage { get; set; }
            public string Comment { get; set; }
        }
        public class Courses
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
       
        public class fitnesscontext: DbContext
        {
            public fitnesscontext():base("DefaultConnection")
            {
                
            }
            public DbSet<CourseRegistration> courseRegistrations { get; set; }
        }
        fitnesscontext context;
        public class WindowCourseRegistration: DbContext
        {
            public WindowCourseRegistration():base("DefaultConnection")
            {

            }
            public DbSet<Courses> courses { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            context = new fitnesscontext();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridRegistrations.ItemsSource = context.courseRegistrations.ToList();

        }
        
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridRegistrations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newRegistration = new CourseRegistration();
            context.courseRegistrations.Add(newRegistration);
            var win = new WindowCourseRegistration (context, newRegistration);
            win.ShowDialog();
        }
        public WindowCourseRegistration(fitnesscontext context, CourseRegistration currentRegistration)
        {
            InitializeComponent();
            this.context = context;
            CmbCourse.ItemsSource = context.courses.ToList();
            this.DataContext = currentRegistration;
        }
        private void CmbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtTotalPoint_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
