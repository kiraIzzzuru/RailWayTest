using RailWay.Ways;

namespace RailWay.Datas
{
    public class StationModel
    {
        /// <summary>
        /// Список парков
        /// </summary>
        private List<Park> parks;

        /// <summary>
        /// Список станций
        /// </summary>
        private List<VStation> vStations;

        public StationModel()
        {
            CreateStationModel();
        }

        /// <summary>
        /// Создание модели всей схемы со всеми парками
        /// </summary>
        internal void CreateStationModel()
        {
            VStation stationA = new VStation("A");
            VStation stationB = new VStation("B");
            VStation stationC = new VStation("C");
            VStation stationD = new VStation("D");
            VStation stationE = new VStation("E");
            VStation stationF = new VStation("F");
            VStation stationG = new VStation("G");
            VStation stationH = new VStation("H");
            VStation stationK = new VStation("K");

            stationA.Neighbors.Add(stationB, 6);
            stationA.Neighbors.Add(stationF, 4);
            stationB.Neighbors.Add(stationC, 10);
            stationD.Neighbors.Add(stationA, 16);
            stationF.Neighbors.Add(stationE, 8);
            stationE.Neighbors.Add(stationC, 2);

            stationG.Neighbors.Add(stationH, 15);
            stationG.Neighbors.Add(stationK, 22);

            vStations = new List<VStation>();
            vStations.Add(stationA);
            vStations.Add(stationB);
            vStations.Add(stationC);
            vStations.Add(stationD);
            vStations.Add(stationE);
            vStations.Add(stationF);
            vStations.Add(stationG);
            vStations.Add(stationH);
            vStations.Add(stationK);

            parks = new List<Park>();
            AddPark1("1");
            AddPark2("2");
        }

        private void AddPark1(string name)
        {
            Park park = new Park(name);
            Ways.Path pathA = new Ways.Path("а");
            Ways.Path pathB = new Ways.Path("b");

            PartPath segmentAB = new PartPath("AB", 6);
            PartPath segmentDA = new PartPath("DA", 16);
            PartPath segmentBC = new PartPath("BC", 10);
            PartPath segmentAF = new PartPath("AF", 4);
            PartPath segmentFE = new PartPath("FE", 8);
            PartPath segmentEC = new PartPath("EC", 2);

            pathA.AddPartPath(segmentAB);
            pathA.AddPartPath(segmentDA);
            pathA.AddPartPath(segmentBC);

            pathB.AddPartPath(segmentAF);
            pathB.AddPartPath(segmentFE);
            pathB.AddPartPath(segmentEC);

            park.AddPath(pathA);
            park.AddPath(pathB);

            parks.Add(park);
        }

        private void AddPark2(string name)
        {
            Park park = new Park(name);
            Ways.Path pathC = new Ways.Path("c");

            PartPath segmentGH = new PartPath("GH", 15);
            PartPath segmentGK = new PartPath("GK", 22);

            pathC.AddPartPath(segmentGH);
            pathC.AddPartPath(segmentGK);

            park.AddPath(pathC);

            parks.Add(park);
        }

        /// <summary>
        /// Получить список парков
        /// </summary>
        /// <returns></returns>
        internal List<Park> GetParks()
        {
            return parks;
        }

        internal List<VStation> GetVStations()
        {
            return vStations;
        }
    }
}
