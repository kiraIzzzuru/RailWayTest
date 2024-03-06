using System.Drawing;

namespace RailWay.Ways
{
    /// <summary>
    /// Вершина отрезка
    /// </summary>
    public class VStation
    {
        /// <summary>
        /// Наименование вершины
        /// </summary>
        public string Name;

        public Dictionary<VStation, int> Neighbors { get; set; } = new Dictionary<VStation, int>();

        public VStation(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
