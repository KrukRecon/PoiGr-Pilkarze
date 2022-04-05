using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Lab_02_4
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FileRepository _fileRepository;
        private readonly List<Piłkarz> pilkarze;

        public MainWindow()
        {
            InitializeComponent();
            _fileRepository = new FileRepository();
            pilkarze = _fileRepository.GetAll();

            if (pilkarze.Count > 0)
            {
                foreach (var pilkarz in pilkarze)
                {
                    listBox_pilkarze.Items.Add(pilkarz);
                }
            }
        }

        private void Button_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Piłkarz piłkarz = new Piłkarz
            {
                Nazwisko = textBox_nazwisko.Text,
                Imię = textBox_imie.Text,
                Waga = textBox_waga.Text.ToInt(),
                Wzrost = textBox_wzrost.Text.ToInt(),
                Pozycja = (Pozycja)comboBox_pozycje.SelectedIndex
            };
            listBox_pilkarze.Items.Add(piłkarz);
            pilkarze.Add(piłkarz);
            _fileRepository.Save(pilkarze);
        }

        private void Button_edytuj_Click(object sender, RoutedEventArgs e)
        {
            var index = listBox_pilkarze.SelectedIndex;
            if (index > -1)
            {
                var p1 = new Piłkarz(listBox_pilkarze.SelectedItem as Piłkarz)
                {
                    Nazwisko = textBox_nazwisko.Text,
                    Imię = textBox_imie.Text,
                    Waga = textBox_waga.Text.ToInt(),
                    Wzrost = textBox_wzrost.Text.ToInt(),
                    Pozycja = (Pozycja)comboBox_pozycje.SelectedIndex
                };
                listBox_pilkarze.Items[index] = p1;
                pilkarze[index] = p1;
                _fileRepository.Save(pilkarze);
            }
        }

        private void ListBox_pilkarze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox_pilkarze.SelectedIndex > -1)
            {
                var currentPlayer = listBox_pilkarze.SelectedItem as Piłkarz;
                textBox_imie.Text = currentPlayer.Imię;
                textBox_nazwisko.Text = currentPlayer.Nazwisko;
                textBox_waga.Text = currentPlayer.Waga.ToString();
                textBox_wzrost.Text = currentPlayer.Wzrost.ToString();
                comboBox_pozycje.SelectedIndex = (int)currentPlayer.Pozycja;
            }
        }

        private void Button_usun_Click(object sender, RoutedEventArgs e)
        {
            var index = listBox_pilkarze.SelectedIndex;
            if (index > -1)
            {
                listBox_pilkarze.Items.RemoveAt(index);
                pilkarze.RemoveAt(index);
                _fileRepository.Save(pilkarze);
                textBox_imie.Text = "Imię";
                textBox_nazwisko.Text = "Nazwisko";
                textBox_waga.Text = "Waga";
                textBox_wzrost.Text = "Wzrost";
                comboBox_pozycje.SelectedIndex = -1;
            }
        }
    }
}
