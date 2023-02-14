using System.Text.RegularExpressions;

namespace SportRadar.ScoreBoard
{
    public class ScoreBoard
    {
        private Dictionary<string, Match> _matches;

        public ScoreBoard()
        {
            _matches = new Dictionary<string, Match>();
        }

        public void Start(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public void Finish(string homeTeam, string awayTeam)
        {
            throw new NotImplementedException();
        }

        public void Update(string homeTeam, string awayTeam, int scoreHome, int scoreAway)
        {
            throw new NotImplementedException();
        }

        public IOrderedEnumerable<Match> GetOrderedSummary()
        {
            throw new NotImplementedException();
        }
    }
}