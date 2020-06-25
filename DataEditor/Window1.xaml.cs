using System.Diagnostics;
using System.Windows;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.Xml;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        StringDataSource _dataSource;
        public StringDataSource dataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                listBox.ItemsSource = value.data;
            }
        }

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public Window1()
        {
            InitializeComponent();

            saveFileDialog.DefaultExt = ".xml";
            openFileDialog.DefaultExt = ".xml";
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            openFileDialog.Filter = "XML Files|*.xml|All Files|*.*";

            dataSource = new StringDataSource();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewStudent newStudentDialog = new NewStudent();
            //newStudentDialog.ShowDialog();
            if (newStudentDialog.ShowDialog() == true)
            {
                dataSource.data.Add(newStudentDialog.Student);
            }

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            dataSource.data.Remove(listBox.SelectedItem as Student);
        }

        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

            if (saveFileDialog.ShowDialog() == true)
            {
                var serializer = new XmlSerializer(typeof(StringDataSource));

                using (XmlWriter fs = XmlWriter.Create(saveFileDialog.FileName))
                {
                    serializer.Serialize(fs, dataSource);

                    Debug.WriteLine("Объект сериализован");
                }
            }
        }

        private void OpenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                var serializer = new XmlSerializer(typeof(StringDataSource));
                using (XmlReader fs = XmlReader.Create(openFileDialog.FileName))
                {
                    
                    dataSource = serializer.Deserialize(fs) as StringDataSource;
                }
            }
        }
    }
}