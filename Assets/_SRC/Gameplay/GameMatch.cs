using System.Collections.Generic;
using Utilities;

namespace Gameplay
{
  public class GameMatch
  {
    public ReactiveQueue<Question> Questions { get; set; }

    public GameMatch(IEnumerable<Question> questions)
    {
      Questions = new ReactiveQueue<Question>(questions);
    }
  }
}