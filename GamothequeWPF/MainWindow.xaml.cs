using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamothequeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            newGame();
        }

        public async void newGame()
        {
            var context = await Context.GetCurrent();
            context.Add(new Model.Game()
            {
                Name = "FFX",
                Done = true,

            });

            await context.SaveChangesAsync();
            path.Text = context.DatabasePath;
            jeu.Text = context.Game.Where(g => g.Done == true).First().Name;
        }
    }
}
