using ppedv.VollE.Logic;
using ppedv.VollE.Model;
using ppedv.VollE.Model.Faults;
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
        public ICommand LadenCommand { get; set; }

        public Spieler SelectedSpieler { get; set; }


        Core core = null;
        public SpielerViewModel()
        {
            SpielerList = new ObservableCollection<Spieler>();
            LoadSpieler();

            SaveCommand = new RelayCommand(UserWantsToSave);
            NewCommand = new RelayCommand(UserWantsToAddNewSpieler);
            DeleteCommand = new RelayCommand(o => { core.Repository.Delete(SelectedSpieler); LoadSpieler(); });
            LadenCommand = new RelayCommand(p => LoadSpieler());

        }

        private void UserWantsToSave(object obj)
        {
            try
            {

                core.Repository.SaveChanges();
            }
            catch (ConcurrencyException ex)
            {
                //todo dialog

                //UserWins
               // ex.UserWins.Invoke();

                //DbWins
                ex.DbWins.Invoke();
                LoadSpieler();
            }
            catch (Exception)
            {
                //todo
                throw;
            }
        }

        private void LoadSpieler()
        {
            core = new Core();
            SpielerList.Clear();

            foreach (var item in core.Repository.Query<Spieler>().OrderBy(x => x.Name).ToList())
            {
                SpielerList.Add(item);
            }
        }

        private void UserWantsToAddNewSpieler(object obj)
        {
            var sp = new Spieler() { Name = "NEU", Händigkeit = true, Geschlecht = Geschlecht.Divers };
            core.Repository.Add(sp);
            SpielerList.Add(sp);
        }
    }
}
