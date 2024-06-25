namespace Gameplay
{
  public class Question
  {
    public string Text { get; set; }

    public string[] Answers { get; set; }
    
    public Question(string text, string[] answers)
    {
      Text = text;
      Answers = answers;
    }
  }
}