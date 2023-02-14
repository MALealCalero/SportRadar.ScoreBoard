using System.ComponentModel.DataAnnotations;

namespace SportRadar.ScoreBoard.Test
{
    [TestClass]
    public class ScoreBoardTest
    {
        #region Start

        [TestMethod]
        public void StartAddMatch()
        {
            ScoreBoard board = new ScoreBoard();

            board.Start("Mexico", "Canada");

            Assert.AreEqual(1, board.GetOrderedSummary().Count());
        }

        [TestMethod]
        public void StartRightResult()
        {
            ScoreBoard board = new ScoreBoard();

            board.Start("Mexico", "Canada");
            var matches = board.GetOrderedSummary();

            Assert.IsTrue(matches.First().HomeTeam.Score == 0 && matches.First().AwayTeam.Score == 0);
        }

        [TestMethod]
        public void StartMetadataFilled()
        {
            ScoreBoard board = new ScoreBoard();

            board.Start("Mexico", "Canada");

            Assert.IsNotNull(board.GetOrderedSummary().First().StartDate);
        }

        [TestMethod]
        public void StartCheckAlreadyExists()
        {
            ScoreBoard board = new ScoreBoard();
            var team1 = "Mexico";
            var team2 = "Canada";

            board.Start(team1, team2);

            Assert.ThrowsException<ArgumentException>(() => board.Start(team1, team2));

            Assert.IsNotNull(board.GetOrderedSummary().First().StartDate);
        }

        #endregion

        #region Finish

        [TestMethod]
        public void FinishRemoveMatch()
        {
            ScoreBoard board = new ScoreBoard();
            var homeTeam = "Mexico";
            var awayTeam = "Canada";

            board.Start(homeTeam, awayTeam);
            board.Finish(homeTeam, awayTeam);

            Assert.AreEqual(0, board.GetOrderedSummary().Count());
        }

        [TestMethod]
        public void FinishCheckMatchExists()
        {
            ScoreBoard board = new ScoreBoard();
            var homeTeam1 = "Mexico";
            var awayTeam1 = "Canada";
            var homeTeam2 = "Spain";
            var awayTeam2 = "Brazil";

            board.Start(homeTeam1, awayTeam1);

            Assert.ThrowsException<KeyNotFoundException>(() => board.Finish(homeTeam2, awayTeam2));
        }

        #endregion

        #region Update

        [TestMethod]
        public void UpdateScoreChange()
        {
            ScoreBoard board = new ScoreBoard();
            var homeTeam = "Mexico";
            var awayTeam = "Canada";

            board.Start(homeTeam, awayTeam);
            board.Update(homeTeam, awayTeam, 1,0);
            var matches = board.GetOrderedSummary();

            Assert.AreEqual(1, matches.First().HomeTeam.Score);
            Assert.AreEqual(0, matches.First().AwayTeam.Score);
        }

        [TestMethod]
        public void UpdateLessThanZeroScoreCheck()
        {
            ScoreBoard board = new ScoreBoard();
            var homeTeam = "Mexico";
            var awayTeam = "Canada";

            board.Start(homeTeam, awayTeam);
            Assert.ThrowsException<ArgumentException>(() => board.Update(homeTeam, awayTeam, -1, 0));
            Assert.ThrowsException<ArgumentException>(() => board.Update(homeTeam, awayTeam, 0, -1));
        }

        [TestMethod]
        public void UpdateCheckMatchExists()
        {
            ScoreBoard board = new ScoreBoard();

            board.Start("Mexico", "Canada");
            Assert.ThrowsException<KeyNotFoundException>(() => board.Update("Spain", "Brazil", 1, 0));
        }

        #endregion

        #region GetSummary

        [TestMethod]
        public void GetSummaryCheckOrder()
        {
            ScoreBoard board = new ScoreBoard();
            var team1 = "Mexico";
            var team2 = "Canada";
            var team3 = "Spain";
            var team4 = "Brazil";
            var team5 = "Germany";
            var team6 = "France";
            var team7 = "Uruguay";
            var team8 = "Italy";
            var team9 = "Argentina";
            var team10 = "Australia";

            board.Start(team1, team2);
            board.Update(team1, team2, 0, 5);

            board.Start(team3, team4);
            board.Update(team3, team4, 10, 2);

            board.Start(team5, team6);
            board.Update(team5, team6, 2, 2);

            board.Start(team7, team8);
            board.Update(team7, team8, 6, 6);

            board.Start(team9, team10);
            board.Update(team9, team10, 3, 1);

            var summary = board.GetOrderedSummary();

            Assert.IsTrue(summary.ElementAt(0).HomeTeam.Name.Equals(team7) && summary.ElementAt(0).AwayTeam.Name.Equals(team8));
            Assert.IsTrue(summary.ElementAt(1).HomeTeam.Name.Equals(team3) && summary.ElementAt(1).AwayTeam.Name.Equals(team4));
            Assert.IsTrue(summary.ElementAt(2).HomeTeam.Name.Equals(team1) && summary.ElementAt(2).AwayTeam.Name.Equals(team2));
            Assert.IsTrue(summary.ElementAt(3).HomeTeam.Name.Equals(team9) && summary.ElementAt(3).AwayTeam.Name.Equals(team10));
            Assert.IsTrue(summary.ElementAt(4).HomeTeam.Name.Equals(team5) && summary.ElementAt(4).AwayTeam.Name.Equals(team6));
        }

        #endregion
    }
}