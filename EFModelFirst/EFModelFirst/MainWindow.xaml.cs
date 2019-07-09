using System;
using System.Linq;
using System.Windows;
using System.Data.Entity;

namespace EFModelFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Model1Container context = new Model1Container();

        private void Laden(object sender, RoutedEventArgs e)
        {
            context = new Model1Container();

            var query = context.PersonSet
            .OfType<Mitarbeiter>()
            .Include(x => x.Abteilung) //earger loading
            .Include(x => x.Kunde)
            //.Include($"{nameof(Mitarbeiter.Abteilung)}.{nameof(Abteilung.Mitarbeiter)}")
            .Where(x => x.GebDatum.Value.Year > 1000)
            .OrderBy(x => x.GebDatum.Value.Month)
            .ThenByDescending(x => x.Name);

            var sql = query.ToString();
            //MessageBox.Show(sql);
            grid.ItemsSource = query.ToList();
        }

        private void DemoDaten(object sender, RoutedEventArgs e)
        {
            var abt1 = new Abteilung() { Bezeichnung = "Holz" };
            var abt2 = new Abteilung() { Bezeichnung = "Steine" };

            for (int i = 0; i < 100; i++)
            {
                var m = new Mitarbeiter()
                {
                    Beruf = "Macht dinge",
                    GebDatum = DateTime.Now.AddYears(-30).AddDays(i * 83),
                    Name = $"Fred {i:000}"
                };

                if (i % 2 == 0)
                    m.Abteilung.Add(abt1);

                if (i % 3 == 0)
                    m.Abteilung.Add(abt2);

                context.PersonSet.Add(m);
            }
            context.SaveChanges();
            Laden(this, null);
        }

        private void Speichern(object sender, RoutedEventArgs e)
        {
            var rowCount = context.SaveChanges();
            MessageBox.Show($"{rowCount} dinge wurde geändert");
        }

        private void Grid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (grid.CurrentItem is Mitarbeiter m)
            {
                MessageBox.Show(context.Entry(m).State.ToString());
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (grid.SelectedItem is Mitarbeiter m)
            {
                if (MessageBox.Show($"Soll der Mitarbeiter {m.Name} wirklich gelöscht werden?", "",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No)
                    == MessageBoxResult.Yes)
                {
                    //context.PersonSet.Remove(m);
                    context.Entry(m).State = EntityState.Detached;
                }
            }
        }

        private void Attach(object sender, RoutedEventArgs e)
        {
            var imported = new Mitarbeiter() { Name = "LOADED", Id = 26, Beruf = "Opfer" };


           var loaded = context.PersonSet.Find(imported.Id); //erst cache dann DB
      //      var loaded2 = context.PersonSet.FirstOrDefault(x => x.Id == imported.Id); //immer zu DB

            context.Entry(loaded).CurrentValues.SetValues(imported);

            //context.PersonSet.Attach(imported);
            //var state = context.Entry(imported).State;
        }
    }
}
