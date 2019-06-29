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
    class GameDetailsViewModel:BaseNotifyPropertyChanged
    {
        public GameDetailsViewModel()
        {
            MainWindowViewModel mwvm = (MainWindowViewModel)App.Current.MainWindow.DataContext;
            SelectedGame = mwvm.SelectedGame;

            AddedTypes = new ObservableCollection<Model.Type>();
            RemovedTypes = new ObservableCollection<Model.Type>();
            getAllGames();

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

        public ObservableCollection<Model.Type> SelectedTypes
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

        public ObservableCollection<Model.Type> AddedTypes
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

        public Model.Type SelectedAddedType
        {
            get
            {
                return (Model.Type)GetProperty();
            }
            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Type> RemovedTypes
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

        public Model.Type SelectedRemovedType
        {
            get
            {
                return (Model.Type)GetProperty();
            }
            set
            {
                SetProperty(value);
            }
        }

        public Model.Game SelectedGame
        {
            get
            {
                return (Model.Game)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        //public ObservableCollection<Model.Type> SelectedGameType
        //{
        //    get
        //    {
        //        return (ObservableCollection<Model.Type>)GetProperty();
        //    }

        //    set
        //    {
        //        SetProperty(value);
        //    }
        //}



        /*public ObservableCollection<Model.Game> Name
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> Done
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> Synopsis
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> Review
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> Mark
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> MinimumAge
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> PhysicalSupport
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> DigitalSupport
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> Picture
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> ExpectedDuration
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }

        public ObservableCollection<Model.Game> ReleaseDate
        {
            get
            {
                return (ObservableCollection<Model.Game>)GetProperty();
            }

            set
            {
                SetProperty(value);
            }
        }*/


        public async void getAllGames()
        {
            var context = await Context.GetCurrent();
            RemovedTypes = new ObservableCollection<Model.Type>();
            AddedTypes = new ObservableCollection<Model.Type>();
            TypeList = new ObservableCollection<Model.Type>(context.Type.Include(t => t.gameTypes).ThenInclude(g => g.Game).ToList());
            if (SelectedGame.gameTypes != null && SelectedGame.gameTypes.Count() > 0)
            {
                foreach (Model.Type typ in TypeList)
                {
                    if (SelectedGame.gameTypes.Intersect(typ.gameTypes).Count() == 0)
                    {
                        RemovedTypes.Add(typ);
                    }
                    else
                    {
                        AddedTypes.Add(typ);
                    }
                }
            } else
            {
                RemovedTypes = TypeList;
            }

        }

        public async void saveGame()
        {
            var context = await Context.GetCurrent();
            if (SelectedGame.Id == 0)
            {
                context.Add(SelectedGame);
            }
            
            await context.SaveChangesAsync();
            getAllGames();
        }

        public async void removeType()
        {
            if (SelectedAddedType != null)
            {
                var context = await Context.GetCurrent();
                GameType gt = SelectedGame.gameTypes.Where(t => t.Type == SelectedAddedType).First();
                context.Remove(gt);
                await context.SaveChangesAsync();
                getAllGames();
            }
        }

        public async void addType()
        {
            if (SelectedRemovedType != null)
            {
                var context = await Context.GetCurrent();
                GameType gt = new GameType()
                {
                    Game = SelectedGame,
                    Type = SelectedRemovedType,
                    IdGame = SelectedGame.Id,
                    IdType = SelectedRemovedType.Id
                };
                context.Add(gt);
                await context.SaveChangesAsync();
                getAllGames();
            }
            
        }

        public async void cancel()
        {

        }

        public Commandes.BaseCommand SaveGame => new Commandes.BaseCommand(saveGame);
        public Commandes.BaseCommand Cancel => new Commandes.BaseCommand(cancel);
        public Commandes.BaseCommand AddType => new Commandes.BaseCommand(addType);
        public Commandes.BaseCommand RemoveType => new Commandes.BaseCommand(removeType);
    }
}
