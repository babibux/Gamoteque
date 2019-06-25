using GamothequeWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GamothequeWPF.ViewModel
{
    class MainWindowViewModel : BaseNotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            getAllGames();
            HideMenuButton = false;
            ShowMenuButton = false;
        }

        //private ObservableCollection<Game> _allgames;

        public ObservableCollection<Game> AllGames
        {
            get {
                return (ObservableCollection<Game>)GetProperty();
            }

            set {
                SetProperty(value);
            }
        }

        public bool? ShowMenuButton
        {
            get
            {
                return (bool?)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public bool? HideMenuButton
        {
            get
            {
                return (bool?)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public string PageView
        {
            get
            {
                return (string)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Type> TypeList
        {
            get
            {
                return (ObservableCollection<Model.Type>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public async void getAllGames()
        {
            //var context = await Context.GetCurrent();
            //context.Add(new Model.Game()
            //{
            //    Name = "FFX",
            //    Done = true,

            //});

            //await context.SaveChangesAsync();
            //path.Text = context.DatabasePath;
            //jeu.Text = context.Game.Where(g => g.Done == true).First().Name;
            var context = await Context.GetCurrent();
            AllGames = new ObservableCollection<Game>(context.Game.ToList());
            TypeList = new ObservableCollection<Model.Type>(context.Type.ToList());
        }

        public void changeShowMenuButton()
        {
            HideMenuButton = !HideMenuButton;
            ShowMenuButton = !ShowMenuButton;
        }

        public Commandes.BaseCommand NewGame => new Commandes.BaseCommand(newGame);

        public Commandes.BaseCommand<int> DeleteGame => new Commandes.BaseCommand<int>(deleteGame);

        public Commandes.BaseCommand<string> ChangePage => new Commandes.BaseCommand<string>(changePage);

        public Commandes.BaseCommand ChangeShowMenuButton => new Commandes.BaseCommand (changeShowMenuButton);


        
        public string NameNewGame {
            get;
            set;
        }
        public bool FinishedNewGame
        {
            get; set;
        }

        public void changePage(string page)
        {
            switch(page)
            {
                case "NewGame":
                    PageView = "GameDetailsView.xaml";
                    break;
                case "GameList":
                    PageView = "GameListView.xaml";
                    break;
                case "Statistic":
                    PageView = "StatisticView.xaml";
                    break;
                case "TypeList":
                    PageView = "StyleView.xaml";
                    break;
            }
        }

        

        public async void newGame()
        {
            var context = await Context.GetCurrent();
            context.Add(new Model.Game()
            {
                Name= NameNewGame,
                Done= FinishedNewGame,
            });
            await context.SaveChangesAsync();
            getAllGames();
        }

        public async void deleteGame(int gameID)
        {
            var context = await Context.GetCurrent();
            var game = context.Game.Where(g => g.Id == gameID).First();
            context.Remove(game);
            await context.SaveChangesAsync();
            getAllGames();
        }


    }
}
