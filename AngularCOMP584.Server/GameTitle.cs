namespace AngularCOMP584.Server
{
    public class GameTitle
    {
        public string? Game { get; set; }

        //public int TemperatureC { get; set; }

        public DateOnly ReleasedDate { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int CurrentPlayers { get; set; }
        public string? Summary { get; set; }
    }
}
