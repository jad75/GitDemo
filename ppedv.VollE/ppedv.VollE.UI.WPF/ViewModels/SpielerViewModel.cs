using ppedv.VollE.Logic;
using ppedv.VollE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.VollE.UI.WPF.ViewModels
{
    public class SpielerViewModel
    {
        public ObservableCollection<Spieler> SpielerList { get; set; }

        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DemoCommand { get; set; }

        public Spieler SelectedSpieler { get; set; }


        Core core = new Core();
        public SpielerViewModel()
        {
            SpielerList = new ObservableCollection<Spieler>(core.Repository.Query<Spieler>().OrderBy(x => x.Name).ToList());

            SaveCommand = new RelayCommand(o => core.Repository.SaveChanges());
            NewCommand = new RelayCommand(UserWantsToAddNewSpieler);
            DeleteCommand = new RelayCommand(o => core.Repository.Delete(SelectedSpieler));
        }

        private void UserWantsToAddNewSpieler(object obj)
        {
            var sp = new Spieler() { Name = "NEU", Händigkeit = true, Geschlecht = Geschlecht.Divers };
            core.Repository.Add(sp);
            SpielerList.Add(sp);
        }
    }
}
