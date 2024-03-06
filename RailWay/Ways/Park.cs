using System.Text;

namespace RailWay.Ways
{
    internal class Park
    {
        /// <summary>
        /// Наименование парка
        /// </summary>
        public string Name;

        /// <summary>
        /// Набор путей в парке
        /// </summary>
        public List<Path> Paths = new List<Path>();

        public Park(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Добавить путь в парк
        /// </summary>
        public void AddPath(Path path)
        {
            Paths.Add(path);
        }

        public override string ToString()
        {
            StringBuilder pathsName = new StringBuilder();

            if (Paths.Any())
            {
                Paths.ForEach(x => pathsName.Append("Путь " + x.ToString() + ", "));

                pathsName.Remove(pathsName.Length - 2, 2);
            }

            return $"Парк {Name}: [{pathsName}]" ;
        }
    }
}
