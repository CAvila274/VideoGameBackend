namespace AngularCOMP584.Server.DTO
{
    public class GameCompaniesDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime FoundedDate { get; set; }
        public List<GameConsoleDTO> GameConsoles { get; set; }
    }
}
