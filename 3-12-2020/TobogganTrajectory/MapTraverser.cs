using System;
using System.Collections.Generic;

namespace TobogganTrajectory
{
    public class MapTraverser
    {
        public int TraverseSlope(List<string> slope, int latRate, int longRate)
        {
            var countOfTrees = 0;
            var currentLong = 0;

            for (int i = 0; i < slope.Count; i += latRate)
            {
                if (IsTreeAtLatitude(slope[i], currentLong))
                    countOfTrees++;

                currentLong += longRate;
            }
            return countOfTrees;
        }

        public bool IsTreeAtLatitude(string line, int latitude)
        {
            var singleInputLat = latitude % line.Length;
            return line[singleInputLat].Equals('#');
        }
    }
}
