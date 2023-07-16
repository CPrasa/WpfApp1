using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;


        [ObservableProperty]
        public Student selectedStudent = null;

        [RelayCommand]
        public void EditStudent()
        {
            if (SelectedStudent != null)
            {

                var edit = new EditStudentWindowVM( SelectedStudent);
                var editWindow = new EditStudentWIndow(edit) { DataContext= edit };
                edit.WindowTitle = "Modify Student ";
                editWindow.ShowDialog();

                int update = Students.IndexOf(SelectedStudent);
                Students.Remove(SelectedStudent);
                edit.Student1.SetBdayString();
                Students.Insert(update, edit.Student1);



            }
            else
            {
                MessageBox.Show("You need to select a Student First","  Error  ");
            }
            
        }

        [RelayCommand]
        public void Exit()
        {
            Application.Current.Shutdown();
        }

        [RelayCommand]
        public void DeleteStudent(Student student)
        {
            if (student != null)
            {
                Students.Remove(student);
                return;
            }
           MessageBox.Show("You need to Select a Stduent First", "Error ");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var add = new EditStudentWindowVM();
            var addWindow = new EditStudentWIndow(add) { DataContext = add };
            add.WindowTitle= "Add Student";
            addWindow.ShowDialog();
            Students.Insert(Students.Count, add.Student1);


                }
        

        public MainWindowVM()
        {
            
            students = new ObservableCollection<Student>();
            students.Add(new Student("Tom1", "Brown1", new DateTime(2000, 7, 31), 3.55, new BitmapImage(new Uri($"/Icons/1.png",UriKind.Relative))));
            students.Add(new Student("Tom2", "Brown2", new DateTime(2002, 3, 12), 3.41, new BitmapImage(new Uri($"/Icons/2.png",UriKind.Relative))));
            students.Add(new Student("Tom3", "Brown3", new DateTime(2003, 5, 19), 3.09, new BitmapImage(new Uri($"/Icons/3.png", UriKind.Relative))));
            students.Add(new Student("Tom4", "Brown4", new DateTime(2004, 1, 13), 3.41, new BitmapImage(new Uri($"/Icons/4.png", UriKind.Relative))));
            students.Add(new Student("Tom5", "Brown5", new DateTime(2001, 6, 24), 3.87, new BitmapImage(new Uri($"/Icons/5.png", UriKind.Relative))));
            students.Add(new Student("Tom6", "Brown6", new DateTime(2004, 1, 30), 2.78, new BitmapImage(new Uri($"/Icons/6.png", UriKind.Relative))));
            students.Add(new Student("Tom7", "Brown7", new DateTime(2004, 1, 27), 2.78, new BitmapImage(new Uri($"/Icons/7.png", UriKind.Relative))));
        }


    }
}
