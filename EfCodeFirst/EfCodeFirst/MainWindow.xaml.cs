using Bogus;
using EfCodeFirst.Model;
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

namespace EfCodeFirst
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

        EfContext context = new EfContext();

        private void Laden(object sender, RoutedEventArgs e)
        {
            context = new EfContext();
            grid.ItemsSource = context.Mitarbeiter.ToList();
        }

        private void Demo(object sender, RoutedEventArgs e)
        {
            var faker = new Faker<Mitarbeiter>()
                .RuleFor(x => x.Name, (f, u) => f.Name.FullName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(x => x.GebDatum, (f, u) => f.Date.Past(40))
                .RuleFor(x => x.Beruf, (f, u) => f.Name.JobTitle());

            for (int i = 0; i < 100; i++)
            {
                var m = faker.Generate();
                context.Mitarbeiter.Add(m);
            }
            context.SaveChanges();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            context?.SaveChanges();
        }
    }
}
