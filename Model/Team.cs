public class Team
{
    private string name;
    private int score;

    public Team(string name)
    {
        this.name = name;
        score = 0;
        
    } // end constructor

    public string Name { get => name; } // property get name
    public int Score { get => score; set => score = value; } // property get and set score

} // end class