using SportRadar.ScoreBoard;
using SportRadar.ScoreBoard.ConsoleApp;
using SportRadar.ScoreBoard.Entities;

var _scoreBoard = new ScoreBoard();

_scoreBoard.Start(Constants.Teams.Mexico, Constants.Teams.Canada);
_scoreBoard.Start(Constants.Teams.Spain, Constants.Teams.Brazil);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 1, 0);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Mexico, Constants.Teams.Canada, 0, 1);
_scoreBoard.Update(Constants.Teams.Mexico, Constants.Teams.Canada, 0, 2);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 2, 0);
_scoreBoard.Start(Constants.Teams.Germany, Constants.Teams.France);
_scoreBoard.Update(Constants.Teams.Germany, Constants.Teams.France, 1, 0);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 3, 0);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 3, 1);
_scoreBoard.Start(Constants.Teams.Uruguay, Constants.Teams.Italy);
_scoreBoard.Update(Constants.Teams.Mexico, Constants.Teams.Canada, 0, 3);
_scoreBoard.Start(Constants.Teams.Argentina, Constants.Teams.Australia);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 4, 1);
_scoreBoard.Update(Constants.Teams.Germany, Constants.Teams.France, 1, 1);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 4, 1);
_scoreBoard.Update(Constants.Teams.Mexico, Constants.Teams.Canada, 0, 4);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 5, 1);
_scoreBoard.Update(Constants.Teams.Germany, Constants.Teams.France, 1, 2);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 0, 1);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 1, 1);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 2, 1);
_scoreBoard.Update(Constants.Teams.Germany, Constants.Teams.France, 2, 2);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 5, 2);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 3, 1);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Mexico, Constants.Teams.Canada, 0, 5);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 6, 2);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 4, 1);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 4, 2);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 7, 2);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 4, 3);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Argentina, Constants.Teams.Australia, 0, 1);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 4, 4);
_scoreBoard.Update(Constants.Teams.Argentina, Constants.Teams.Australia, 1, 1);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 8, 2);
_scoreBoard.Finish(Constants.Teams.Mexico, Constants.Teams.Canada);
_scoreBoard.Update(Constants.Teams.Argentina, Constants.Teams.Australia, 2, 1);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Finish(Constants.Teams.Germany, Constants.Teams.France);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 9, 2);
_scoreBoard.Update(Constants.Teams.Spain, Constants.Teams.Brazil, 10, 2);
_scoreBoard.Finish(Constants.Teams.Spain, Constants.Teams.Brazil);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 4, 5);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 4, 6);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 5, 6);
_scoreBoard.Update(Constants.Teams.Argentina, Constants.Teams.Australia, 3, 1);
_scoreBoard.Update(Constants.Teams.Uruguay, Constants.Teams.Italy, 6, 6);

PrintScoreBoard(_scoreBoard);

_scoreBoard.Finish(Constants.Teams.Uruguay, Constants.Teams.Italy);
_scoreBoard.Finish(Constants.Teams.Argentina, Constants.Teams.Australia);

PrintScoreBoard(_scoreBoard);


static void PrintScoreBoard(ScoreBoard scoreBoard)
{
    var matches = scoreBoard.GetOrderedSummary();

    Console.WriteLine(Constants.Texts.LiveMatches);
    Console.WriteLine("----------");
    foreach (var match in matches)
    {
        Console.WriteLine(FormatMatchOutput(match));
    }
    Console.WriteLine("----------");
    Wait();
}

static string FormatMatchOutput(Match match)
{
    return $"{match.HomeTeam.Name} {match.HomeTeam.Score} - {match.AwayTeam.Name} {match.AwayTeam.Score}.";
}

static void Wait()
{
    for (var i = 0; i < 3; i++)
    {
        Thread.Sleep(Constants.Settings.WaitTime);
        Console.WriteLine(".");
    }
}