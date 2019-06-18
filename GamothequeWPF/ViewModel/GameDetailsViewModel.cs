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

        public async void getAllGames()
        {
            var context = await Context.GetCurrent();
            TypeList = new ObservableCollection<Model.Type>(context.Type.ToList());
        }
    }
}
