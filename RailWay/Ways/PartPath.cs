namespace RailWay.Ways
{
    /// <summary>
    /// Участок пути
    /// </summary>
    internal class PartPath
    {
        #region Properties
        /// <summary>
        /// Наименование
        /// </summary>
        public String Name;

        /// <summary>
        /// Расстояние
        /// </summary>
        private int Distance;

        #endregion Properties

        public PartPath(String name, int distance)
        {
            Name = name;
            Distance = distance;
        }
    }
}
