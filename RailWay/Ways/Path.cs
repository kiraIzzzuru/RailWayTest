namespace RailWay.Ways
{
    /// <summary>
    /// Путь (состоит из набора участков путей)
    /// </summary>
    internal class Path
    {
        /// <summary>
        /// Наименование пути
        /// </summary>
        public string Name;

        /// <summary>
        /// Отрезки, из которых состоит путь
        /// </summary>
        public List<PartPath> Segments = new List<PartPath>();

        public Path(string name)
        {
            Name = name;
        }

        public void AddPartPath(PartPath partPath)
        {
            Segments.Add(partPath);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
