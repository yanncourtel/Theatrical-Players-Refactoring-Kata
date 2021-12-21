namespace TheatricalPlayersRefactoringKata;

public class Performance
{
    public Play Play { get; set; }

    public int Audience { get; set; }

    public Performance(int audience, Play play)
    {
        this.Audience = audience;
        this.Play = play;
    }
}