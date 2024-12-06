using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdatrogzitoDoga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    /*Beviteli mezők és ellenőrzések az első oldalon:

A felhasználónak meg kell adnia:
Név: Kötelező, legalább 3 karakter hosszú.
Kor: Kötelező, csak számokat fogadjon el (pozitív egész szám).
E-mail cím: Kötelező, és legyen érvényes formátum.
Telefonszám: Csak számokat fogadjon el, és legalább 8 karakter hosszúnak kell lennie.
Cím: Nem lehet üres.
Nem: ComboBox-ot használunk a választáshoz.
Megjegyzés: Opcionális szöveg.
Egy „Hozzáadás” gomb csak engedjen tovább, ha az összes mező helyes adatot tartalmaz.
Adatok megjelenítése a második oldalon:

Az előző oldalon bevitt adatok jelenjenek meg egy listában.
A lista elemeit fájlba is mentjük.
A fájl formátuma legyen például txt (pl. nev,kor,email,telefon,cim,nem,megjegyzes(opcionalis)).
Követelmények
Validációk az első oldalon:

A gomb inaktív legyen, amíg bármelyik mező érvénytelen.
Hibás adat esetén jelenjen meg hibaüzenet.
Lista oldal:

Listázza ki az összes bevitt adatot.
Mentse a fájlba a megadott adatokat.
Listaelem törlése: Ha a felhasználó rákattint egy listaelemre, az törlődik mind a ListBox-ból, mind a fájlból.
Frissítés: A lista tartalma automatikusan frissül törlés után.
Navigáció:

Az első oldalról lehessen navigálni a lista oldalra.
A lista oldalról lehessen visszatérni az első oldalra (új adatok felviteléhez). 
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenderComboBox.SelectedIndex = 0;
        }

        private void reg(object sender, RoutedEventArgs e)
        {   
            string name = NameTextBox.Text;
            int age = 0;
            if (Int32.TryParse(AgeTextBox.Text, out int a))
            {
                age = a;
            } else {
                MessageBox.Show("A kor csak szám lehet!"); 
                return;
            }
            string email = EmailTextBox.Text;
            string phoneNumber = PhoneNumberTextBox.Text;
            string address = AddressTextBox.Text;
            bool gender = GenderComboBox.SelectedIndex == 0 ? true : false;
            string comment = CommentTextBox.Text;
            if (name.Length < 3)
            {
                MessageBox.Show("A név nem lehet 3 karakternél rövidebb.");
                return;
            }
            if (age < 0)
            {
                MessageBox.Show("A kor nem lehet negatív szám.");
                return;
            }
            if (!email.Contains("@") || !email.Split("@")[1].Contains(".")) {
                MessageBox.Show("Az email cím nem megfelelő formátumú.");
                return;
            }
            if(!long.TryParse(phoneNumber, out long ph))
            {
                MessageBox.Show("A telefonszám csak számokat tartalmazhat.");
                return;
            }
            if (phoneNumber.Length < 8)
            {
                MessageBox.Show("A telefonszám nem lehet 8 karakternél rövidebb.");
                return;
            }
            if (address.Length == 0)
            {
                MessageBox.Show("A cím nem lehet üres.");
                return;
            }
            User buff = new User(name, age, email, phoneNumber, address, gender, comment);
            System.IO.File.AppendAllText("users.txt", buff.ToFile() + "\n");
            UserLista userLista = new UserLista();
            userLista.Show();
            this.Close();
        }

        private void toTheList(object sender, RoutedEventArgs e)
        {
            UserLista userLista = new UserLista();
            userLista.Show();
            this.Close();
        }
    }
}