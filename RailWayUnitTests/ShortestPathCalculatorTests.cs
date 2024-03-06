using RailWay.Ways;

namespace UnitTests
{
    [TestFixture]
    internal class ShortestPathCalculatorTests
    {
        [Test]
        public void TestShortestPathBetweenStation()
        {
            VStation stationA = new VStation("A");
            VStation stationB = new VStation("B");
            VStation stationC = new VStation("C");

            stationA.Neighbors.Add(stationB, 5);
            stationA.Neighbors.Add(stationC, 10);
            stationB.Neighbors.Add(stationC, 3);

            Dictionary<VStation, int> shortestDistances = ShortestPathCalculator.GetShortestPath(stationA);

            Assert.AreEqual(0, shortestDistances[stationA]);
            Assert.AreEqual(5, shortestDistances[stationB]);
            Assert.AreEqual(8, shortestDistances[stationC]);
        }

        [Test]
        public void TestInvalidStations()
        {
            VStation stationA = new VStation("A");
            VStation stationB = new VStation("B");
            VStation stationC = new VStation("C");
            stationA.Neighbors.Add(stationB, 5);

            Dictionary<VStation, int> shortestDistances = ShortestPathCalculator.GetShortestPath(stationA);

            Assert.IsFalse(shortestDistances.ContainsKey(stationC));
        }
    }
}
