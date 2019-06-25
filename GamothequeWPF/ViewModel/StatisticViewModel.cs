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
            GameByMarkStats = new ObservableCollection<KeyValuePair<string, int>>();
            GameByTypeStats = new ObservableCollection<KeyValuePair<string, int>>();
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

        public ObservableCollection<KeyValuePair<string, int>> GameByMarkStats
        {
            get
            {
                return (ObservableCollection<KeyValuePair<string, int>>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<KeyValuePair<string, int>> GameByTypeStats
        {
            get
            {
                return (ObservableCollection<KeyValuePair<string, int>>)GetProperty();
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
                GameByMarkStats.Add(new KeyValuePair<string, int>(i.ToString(), games.Where(g => g.Mark == i).Count()));

                //AllStats.Add("Nombre de jeu " + i + " étoile" + ((i > 1) ? "s" : "")  + " : " + games.Where(g => g.Mark == i).Count());
            }

            // Nombre de jeux de chaques types
            foreach (Model.Type typ in context.Type.Include(t => t.gameTypes))
            {
                int nbGame = typ.gameTypes.Count();
                if (nbGame > 0 )
                {
                    GameByTypeStats.Add(new KeyValuePair<string, int>(typ.Name, typ.gameTypes.Count()));
                }
                
                        
                        
                 //AllStats.Add("Nombre de " + typ.Name + " : " + typ.gameTypes.Count());
            }
        }


    }
}
