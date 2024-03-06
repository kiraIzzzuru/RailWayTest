using RailWay.Datas;
using RailWay.Ways;
using System.Text;

namespace RailWay
{
    public class ComandManager
    {
        private static ComandManager instance;

        /// <summary>
        /// Сгенерированная модель всех станций и парков
        /// </summary>
        private StationModel stationModel;

        private ComandManager()
        {
            stationModel = new StationModel();
        }

        #region Singlton
        public static ComandManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ComandManager();
            }
            return instance;
        }
        #endregion Singlton

        #region Methods
        internal void Run(string? comandText)
        {
            if (string.IsNullOrEmpty(comandText))
            {
                return;
            }
            List<int> param = ParseComand(comandText);

            if (param.Count < 1)
            {
                Console.WriteLine("Некоректные параметры!");
                return;
            }

            switch (param[0])
            {
                case 1:
                    Console.WriteLine(GetAllParks());
                    break;
                case 2:
                    PrintAllPartStation();
                    break;
                case 3:
                    if (param.Count == 3)
                    {
                        FindShortestWay(param[1], param[2]);
                    }
                    else
                    {
                        Console.WriteLine("Некоректные параметры!");
                    }
                    break;
            }
        }

        /// <summary>
        /// Распарсить входную команду
        /// </summary>
        /// <param name="comandText"></param>
        /// <returns></returns>
        private List<int> ParseComand(string comandText)
        {
            List<int> param = new List<int>();

            var paramText = comandText.Split(new char[] { ' ' });

            foreach (var item in paramText)
            {
                bool isOk = int.TryParse(item, out int value);

                if (isOk)
                {
                    param.Add(value);
                }
            }
            return param;
        }

        /// <summary>
        /// Получить все парки с вершинами
        /// </summary>
        /// <returns></returns>
        public string GetAllParks()
        {
            var parks = stationModel.GetParks();

            StringBuilder parksInfo = new StringBuilder();

            if (parks.Any())
            {
                parks.ForEach(x => parksInfo.Append(x.ToString() + ", "));

                parksInfo.Remove(parksInfo.Length - 2, 2);
            }

            return parksInfo.ToString();
        }

        /// <summary>
        /// Получить все участки схемы станции
        /// </summary>
        /// <returns></returns>
        public void PrintAllPartStation()
        {
            var stations = stationModel.GetVStations();

            StringBuilder stationsInfo = new StringBuilder();

            if (stations.Any())
            {
                for (int i = 0; i < stations.Count; i++)
                {
                    stationsInfo.Append($"[{i}].[{stations[i].Name}], ");
                }

                stationsInfo.Remove(stationsInfo.Length - 2, 2);

                Console.WriteLine(stationsInfo.ToString());
            }
            else
            {
                Console.WriteLine("Нехватает данных!");
            }
        }

        /// <summary>
        /// Получить кратчайший путь между точками
        /// </summary>
        /// <returns></returns>
        private void FindShortestWay(int start, int end)
        {
            var stations = stationModel.GetVStations();

            if (stations == null || stations.Count <= start || stations.Count <= end)
            {
                Console.WriteLine("Некорректные параметры!");
            }

            VStation station = stationModel.GetVStations()[start];
            VStation stationEnd = stationModel.GetVStations()[end];

            Dictionary<VStation, int> shortestDistances = ShortestPathCalculator.GetShortestPath(station);

            if (shortestDistances.ContainsKey(stationEnd))
            {
                Console.WriteLine($"Кратчайший путь между станциями {station.Name} и {stationEnd.Name}: {shortestDistances[stationEnd]}");
            }
            else
            {
                Console.WriteLine("Нет пути между указанными станциями.");
            }

            //foreach (var kvp in shortestDistances)
            //{
            //    Console.WriteLine($"Кратчайший путь до точки {kvp.Key.Name}: {kvp.Value}");
            //}
        }
        #endregion Methods
    }
}
