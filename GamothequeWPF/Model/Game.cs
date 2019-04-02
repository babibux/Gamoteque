using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamothequeWPF.Model
{
    public class Game
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
        public string Synopsis { get; set; }
        public string Review { get; set; }
        public int Mark { get; set; }
        public int MinimumAge { get; set; }
        public bool PhysicalSupport { get; set; }
        public bool DigitalSupport { get; set; }
        public string Picture { get; set; }
        //public Language VoiceLanguage { get; set; }
        //public Language TextLanguage { get; set; }
        public TimeSpan ExpectedDuration { get; set; }
        public DateTime ReleaseDate { get; set; }

        //[InverseProperty]     

    }
}
