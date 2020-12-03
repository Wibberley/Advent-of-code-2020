using NUnit.Framework;

namespace TobogganTrajectoryTest
{
    public class MapTraverserTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(".........#.#.#.........#.#.....", 10, true)]
        [TestCase(".........#.#.#.........#.#.....", 4, false)]
        public void GivenASingleLineInput_WhenISupplyALatitude_ThenIGetIfATreeIsPresent(string input, int latitude, bool expected)
        {
            Assert.Pass();
        }

        [TestCase(".........#.#.#.........#.#.....", 41, true)]
        [TestCase(".........#.#.#.........#.#.....", 35, false)]
        public void GivenASingleLineInput_WhenISupplyALatitudeThatIsGreaterThanTheLength_ThenLoopsAroundAndGetsIfATreeIsPresent(string input, int latitude, bool expected)
        {
            Assert.Pass();
        }
    }
}