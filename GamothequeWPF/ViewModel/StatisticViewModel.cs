using GamothequeWPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF.ViewModel
{
    class StatisticViewModel : BaseNotifyPropertyChanged
    {

        public StatisticViewModel()
        {
            AllStats = new ObservableCollection<string>();
            getAllStats();
        }

        public ObservableCollection<string> AllStats
        {
            get
            {
                return (ObservableCollection<string>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public async void getAllStats()
        {
            var context = await Context.GetCurrent();
            var games = context.Game.ToList();

            // % de jeu fait
            AllStats.Add("Pourcentage de jeux réalisés : " + (games.Where(g => g.Done == true).Count() * 100/games.Count()) + " %");


            // Répartition des jeux par note
            for (var i = 0; i < 6; i++)
            {
                AllStats.Add("Nombre de jeu " + i + " étoile" + ((i > 1) ? "s" : "")  + " : " + games.Where(g => g.Mark == i).Count());
            }

            // Nombre de jeux de chaques types
            foreach (Model.Type typ in context.Type.Include(t => t.gameTypes))
            {
                AllStats.Add("Nombre de " + typ.Name + " : " + typ.gameTypes.Count());
            }
        }


    }
}
