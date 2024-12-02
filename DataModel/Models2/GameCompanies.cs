using AngularCOMP584.Server.Models2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel.Models2
{
    [Table("game_companies")]
    public partial class GameCompanies
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [Column("FoundedDate")]
        public DateTime FoundedDate { get; set; }

        
        [InverseProperty("GameCompanies")]
        public virtual ICollection<GameConsole> GameConsoles { get; set; } = new List<GameConsole>();
    }
}
