using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF.Model
{
    public class GameType
    {
        [Key]
        public int IdType { get; set; }
        [Key]
        public int IdGame { get; set; }

        [ForeignKey(nameof(IdType))]
        public Type Type { get; set; }

        [ForeignKey(nameof(IdGame))]
        public Game Game { get; set; }
    }
}
