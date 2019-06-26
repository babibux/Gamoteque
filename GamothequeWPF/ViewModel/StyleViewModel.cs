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
            var context = await Context.GetCurrent();
            var changedEntries = context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
            getAllType();
        }

        public Commandes.BaseCommand CancelChange => new Commandes.BaseCommand(cancelChange);


        public async void addNewType()
        {
            var context = await Context.GetCurrent();

            Model.Type newType = new Model.Type()
            {
                Name = "Nouveau Type"
            };

            context.Add(newType);
            await context.SaveChangesAsync();
            getAllType();
        }

        public Commandes.BaseCommand AddNewType => new Commandes.BaseCommand(addNewType);

        public async void deleteType(Model.Type type)
        {
            var context = await Context.GetCurrent();
            var typ = context.Type.Where(g => g.Id == type.Id).First();
            context.Remove(typ);
            await context.SaveChangesAsync();
            getAllType();
        }

        public Commandes.BaseCommand<Model.Type> DeleteType => new Commandes.BaseCommand<Model.Type>(deleteType);

    }
}
