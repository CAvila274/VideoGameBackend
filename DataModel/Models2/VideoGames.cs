using AngularCOMP584.Server.Models2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models2
{
    [Table("video_games")]

    public partial class VideoGames
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

        [Column("ConsoleId")] 
        public int ConsoleId { get; set; }

        [ForeignKey("ConsoleId")]
        [InverseProperty("VideoGames")]
        public virtual GameConsole? GameConsole { get; set; }
    }
}
