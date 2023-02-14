using SportRadar.ScoreBoard.Entities;

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
            _matches.Add(GetKey(homeTeam, awayTeam), GetMatch(homeTeam, awayTeam));
        }

        public void Finish(string homeTeam, string awayTeam)
        {
            if (!_matches.Remove(GetKey(homeTeam, awayTeam)))
            {
                throw new KeyNotFoundException();
            }
        }

        public void Update(string homeTeam, string awayTeam, int scoreHome, int scoreAway)
        {
            if (scoreHome < 0 || scoreAway < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                _matches[GetKey(homeTeam, awayTeam)].UpdateScore(scoreHome, scoreAway);
            }
        }

        public IOrderedEnumerable<Match> GetOrderedSummary()
        {
            return _matches.Values.OrderByDescending(x => x.HomeTeam.Score + x.AwayTeam.Score).ThenByDescending(x => x.StartDate);
        }

        private string GetKey(string homeTeam, string awayTeam)
        {
            return homeTeam + "-" + awayTeam;
        }

        private Match GetMatch(string homeTeam, string awayTeam)
        {
            return new Match(
                new Team(homeTeam, 0),
                new Team(awayTeam, 0),
                DateTime.UtcNow
                );
        }
    }
}