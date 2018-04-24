using Mordor.Models;

namespace Mordor
{
    class MoodFactory
    {
        public static string GetMood(int points)
        {
            if (points < -5)
            {
                return new Angry().Type;
            }
            if (points >= -5 && points <= 0)
            {
                return new Sad().Type;
            }
            if (points > 0 && points <= 15)
            {
                return new Happy().Type;
            }
            else
            {
                return new JavaScript().Type;
            }
        }
    }
}
