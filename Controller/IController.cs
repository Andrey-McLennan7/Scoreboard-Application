public interface IController
{
    /*
        In this interface the methods are simply decalired (creating prototypes).
        The methods are initialised in file Controller.cs.
    */
    bool CheckTeamNamesValid(string homeTeamName, string awayTeamName); // create CheckTeamNamesValid method prototype
    
    string GetScoreBoardTitle(); // create GetScoreBoardTitle method prototype
    
    bool CheckScoreEntryIsValid(string value); // create CheckScoreEntryIsValid method prototype
    
    void EditHomeTeamScore(int goalCount); // create EditHomeTeamScore method prototype
    void EditAwayTeamScore(int goalCount); // create EditAwayTeamScore method prototype

    int HomeTeamScore { get; }
    int AwayTeamScore { get; }
    string ErrorMessage { get; }

} // end interface IController