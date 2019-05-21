﻿using GamothequeWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF.ViewModel
{
    class MainWindowViewModel : BaseNotifyPropertyChanged
    {

        Game updatedGame;

        public MainWindowViewModel()
        {
            getAllGames();
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

        }

        public Commandes.BaseCommand NewGame => new Commandes.BaseCommand(newGame);

        public Commandes.BaseCommand<int> DeleteGame => new Commandes.BaseCommand<int>(deleteGame);

        public string NameNewGame {
            get;
            set;
        }
        public bool FinishedNewGame
        {
            get; set;
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
