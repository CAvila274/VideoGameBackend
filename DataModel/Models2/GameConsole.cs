using DataModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DataModel.Models2;

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

        
        [Column("CompanyId")]
        public int CompanyId { get; set; }

        [Column("IsCrossPlatform")]
        public bool IsCrossPlatform { get; set; }

        [Column("ConsoleType")]
        [StringLength(10)] 
        [Unicode(false)]
        public string ConsoleType { get; set; } = null!;

        [ForeignKey("CompanyId")]
        [InverseProperty("GameConsoles")]  
        public virtual GameCompanies? GameCompanies { get; set; }

        [InverseProperty("GameConsole")]
        public virtual ICollection<VideoGames> VideoGames { get; set; } = new List<VideoGames>();
    }
}

