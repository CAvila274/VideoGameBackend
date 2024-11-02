using DataModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AngularCOMP584.Server.Models2
{
    [Table("game_consoles")]
    public partial class GameConsole
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;


        [Column("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }
    }
}
