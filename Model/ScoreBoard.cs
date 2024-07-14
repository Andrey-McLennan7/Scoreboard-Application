public class ScoreBoard
{
    private Team home;
    private Team away;
    private string title;
    
    public ScoreBoard(Team home, Team away)
    {
        this.home = home;
        this.away = away;
        title = $"{home.Name} vs {away.Name}";

    } // end constructor

    public string Title { get => title; } // create get prperty Title
    public int HomeTeamScore { get => home.Score; set => home.Score = value; }
    public int AwayTeamScore { get => away.Score; set => away.Score = value; }

} // end class