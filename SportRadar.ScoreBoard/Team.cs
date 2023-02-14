namespace SportRadar.ScoreBoard
{
    public class Team
    {
        public string Name { get; set; }
        public int Score;

        public Team(string name, int? score)
        {
            Name = name ?? throw new ArgumentNullException();
            Score = score ?? 0;
        }
    }
}
