using System;
using System.Collections.ObjectModel;

namespace WpfApp3
{
    public class Student
    {
        public Student() { }
        public Student(string name, string surname, string group, int course)
        {
            this.Name = name;
            this.Surname = surname;
            this.Group = group;
            this.Course = course;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public int Course;

        public int Proverka
        {
            get => this.Course;
            set
            {
                if (value > 5) value = 5;
                else if (value < 1) value= 1;
                this.Course = value;
            }
        }
    }

    [Serializable]
    public class StringDataSource
    {
        public ObservableCollection<Student> data = new ObservableCollection<Student>();
    }
}