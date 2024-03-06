namespace RailWay.Ways
{
    public class ShortestPathCalculator
    {
        public static Dictionary<VStation, int> GetShortestPath(VStation start)
        {
            var distances = new Dictionary<VStation, int>();
            var queue = new SortedSet<(int, VStation)>();

            distances[start] = 0;
            queue.Add((0, start));

            while (queue.Count > 0)
            {
                var (distance, current) = queue.Min;
                queue.Remove(queue.Min);

                foreach (var neighbor in current.Neighbors)
                {
                    var newDistance = distance + neighbor.Value;
                    if (!distances.ContainsKey(neighbor.Key) || newDistance < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = newDistance;
                        queue.Add((newDistance, neighbor.Key));
                    }
                }
            }

            return distances;
        }
    }
}
