namespace MauiSelector.Model;

public class Year
{
    public Year()
    {
        this.First = 2000;
        this.Last = DateTime.Now.Date.Year;
    }

    public int First { get; set; }
    public int Last { get; set; }
}
