using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF.Model
{
    public class GameTextLanguage
    {
        [Key]
        public int IdGame { get; set; }
        [Key]
        public string NameLanguage { get; set; }

        [ForeignKey(nameof(IdGame))]
        public Game Game { get; set; }

        [ForeignKey(nameof(NameLanguage))]
        public Language Language { get; set; }

    }
}
