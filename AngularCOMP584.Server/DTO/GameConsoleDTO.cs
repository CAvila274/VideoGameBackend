namespace AngularCOMP584.Server.DTO
{
    public class GameConsoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int CompanyId { get; set; }

        public bool IsCrossPlatform { get; set; }

        public string ConsoleType { get; set; } = null!;


    }
}
