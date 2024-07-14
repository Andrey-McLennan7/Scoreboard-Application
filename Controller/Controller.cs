public class Controller : IController // Implement Controller Interface
{
    private ScoreBoard scoreBoard; // declair scoreboard object
    private string errorMessage;
    public Controller() {} // create constructor

    public bool CheckScoreEntryIsValid(string value)
    {
        int score;

        if (!int.TryParse(value, out score))
        {
            if (value == "")
                errorMessage = "Empty Field Please Enter Integrer Data";
            else
                errorMessage = "Not Valid Data, Please Enter Interger Data";
                
            return false;
        }

        return true;

    } // end method

    public bool CheckTeamNamesValid(string homeTeamName, string awayTeamName)
    {
        bool haveValidScore = false;

        if (!string.IsNullOrEmpty(homeTeamName) && !string.IsNullOrEmpty(awayTeamName))
        {
            haveValidScore = true;

            scoreBoard = new ScoreBoard(new Team(homeTeamName), new Team(awayTeamName));
        }
        else
        {
            errorMessage = "Please Enter names for both Teams";
        }

        return haveValidScore;

    } // end method

    public string GetScoreBoardTitle()
    {
        return scoreBoard.Title;
    
    } // end method GetScoreBoardTitle()
    
    public void EditHomeTeamScore(int goalCount)
    {
        if (goalCount != 0)
        {
            scoreBoard.HomeTeamScore += goalCount;
        }
        else
        {
            scoreBoard.HomeTeamScore = goalCount;
        }

    } // end method EditTeamScore()

    public void EditAwayTeamScore(int goalCount)
    {
        if (goalCount != 0)
        {
            scoreBoard.AwayTeamScore += goalCount;
        }
        else
        {
            scoreBoard.AwayTeamScore = goalCount;
        }

    } // end method EditAwayTeamScore()

    public int HomeTeamScore { get => scoreBoard.HomeTeamScore; }
    public int AwayTeamScore { get => scoreBoard.AwayTeamScore; }
    public string ErrorMessage { get => errorMessage; }

} // end class Controller