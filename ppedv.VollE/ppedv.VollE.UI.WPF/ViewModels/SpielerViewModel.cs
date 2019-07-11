using ppedv.VollE.Logic;
using ppedv.VollE.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.VollE.UI.WPF.ViewModels
{
    public class SpielerViewModel
    {
        public ObservableCollection<Spieler> SpielerList { get; set; }

        public Spieler SelectedSpieler { get; set; }

        Core core = new Core();
        public SpielerViewModel()
        {
            SpielerList = new ObservableCollection<Spieler>(core.Repository.GetAll<Spieler>());
        }

    }
}
