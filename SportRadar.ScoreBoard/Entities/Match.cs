namespace SportRadar.ScoreBoard.Entities
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

        public void UpdateScore(int homeTeamScore, int awayTeamScore)
        {
            HomeTeam.UpdateScore(homeTeamScore);
            AwayTeam.UpdateScore(awayTeamScore);
        }
    }
}
