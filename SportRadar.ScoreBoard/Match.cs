namespace SportRadar.ScoreBoard
{
    public class Match
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime StartDate { get; set; }

        public Match(Team homeTeam, Team awayTeam, DateTime? startDate)
        {
            HomeTeam = homeTeam ?? throw new ArgumentNullException();
            AwayTeam = awayTeam ?? throw new ArgumentNullException();
            StartDate = startDate ?? DateTime.UtcNow;
        }
    }
}
