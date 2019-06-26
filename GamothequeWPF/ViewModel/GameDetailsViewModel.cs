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

        public ObservableCollection<Model.Game> Name
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
        }


        public async void getAllGames()
        {
            var context = await Context.GetCurrent();
            TypeList = new ObservableCollection<Model.Type>(context.Type.ToList());
        }
    }
}
