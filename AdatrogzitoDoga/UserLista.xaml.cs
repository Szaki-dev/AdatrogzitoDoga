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
using System.Windows.Shapes;

namespace AdatrogzitoDoga
{
    /// <summary>
    /// Interaction logic for UserLista.xaml
    /// </summary>
    public partial class UserLista : Window
    {
        List<User> users = new List<User>();
        public UserLista()
        {
            InitializeComponent();
            if (!System.IO.File.Exists("users.txt"))
            {
                return;
            }
            string[] lines = System.IO.File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                int age = int.Parse(parts[1]);
                string email = parts[2];
                string phoneNumber = parts[3];
                string address = parts[4];
                bool gender = parts[5] == "True" ? true : false;
                string comment = parts.Length == 7 ? parts[6] : "";
                users.Add(new User(name, age, email, phoneNumber, address, gender, comment));
            }
            UserListBox.ItemsSource = users;
        }

        private void toTheMain(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            if(UserListBox.Items.Count == 0)
            {
                return;
            }
            if (MessageBox.Show($"Biztosan törölni szeretné a kijelölt felhasználót?\n{users[UserListBox.SelectedIndex].ToString()}", "Törlés", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                return;
            }
            users.RemoveAt(UserListBox.SelectedIndex);
            UserListBox.ItemsSource = null;
            UserListBox.ItemsSource = users;
            System.IO.File.WriteAllText("users.txt", "");
            foreach (User user in users)
            {
                System.IO.File.AppendAllText("users.txt", user.ToFile() + "\n");
            }
        }
    }
}
