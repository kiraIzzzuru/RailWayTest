using RailWay;
using RailWay.Datas;

namespace UnitTests
{
    [TestFixture]
    internal class StationModelTests
    {
        private StationModel stationModel;

        [SetUp]
        public void Setup()
        {
            stationModel = new StationModel();
        }

        [Test]
        public void TestPrintAllPartStation()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                ComandManager comandManager = ComandManager.GetInstance();
                comandManager.PrintAllPartStation();

                string expectedOutput = "[0].[A], [1].[B], [2].[C], [3].[D], [4].[E], [5].[F], [6].[G], [7].[H], [8].[K]";
                StringAssert.AreEqualIgnoringCase(expectedOutput, sw.ToString().Trim());
            }
        }

        [Test]
        public void TestPrintAllParks()
        {
            using (StringWriter sw = new StringWriter())
            {
                ComandManager comandManager = ComandManager.GetInstance();
                string parks = comandManager.GetAllParks();

                string expectedOutput = "Парк 1: [Путь а, Путь b], Парк 2: [Путь c]";
                StringAssert.AreEqualIgnoringCase(expectedOutput, parks.Trim());
            }
        }
    }
}
