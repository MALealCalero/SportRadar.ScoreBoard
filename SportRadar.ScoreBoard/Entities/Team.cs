namespace SportRadar.ScoreBoard.Entities
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

        public void UpdateScore(int score)
        {
            Score = score;
        }
    }
}
