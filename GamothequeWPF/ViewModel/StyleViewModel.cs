using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF.ViewModel
{
    class StyleViewModel : BaseNotifyPropertyChanged
    {
        public StyleViewModel() {
            getAllType();
        }

        public ObservableCollection<Model.Type> AllTypes
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

        public Model.Type SelectedType
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

        public async void getAllType()
        {
            var context = await Context.GetCurrent();
            AllTypes = new ObservableCollection<Model.Type>(context.Type.Include(t => t.gameTypes).ThenInclude(g => g.Game).ToList());
        }

        public Commandes.BaseCommand GetAllType => new Commandes.BaseCommand(getAllType);

        public void selectType(Model.Type type)
        {
            SelectedType = type;
        }

        public async void saveType()
        {
            var types = AllTypes;
            var context = await Context.GetCurrent();
            await context.SaveChangesAsync();
            getAllType();
        }

        public Commandes.BaseCommand SaveType => new Commandes.BaseCommand(saveType);

        public async void cancelChange()
        {
            getAllType();
        }

        public Commandes.BaseCommand CancelChange => new Commandes.BaseCommand(cancelChange);
    }
}
