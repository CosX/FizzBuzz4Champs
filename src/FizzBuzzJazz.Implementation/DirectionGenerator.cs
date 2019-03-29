using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzJazz.Implementation
{
    public class DirectionGenerator
    {
        public IEnumerable<int> GetRange(int from, int to)
        {
            return from < to ? 
                Enumerable.Range(from, to - ( from -1 )) :
                Enumerable.Range(to, from - (to -1)).Reverse();
        }
    }
}