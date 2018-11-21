using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q41_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            var Area = new Area(8, 8);
            var Tiles = new List<Tile> { new Tile(1, 1), new Tile(2, 2), new Tile(4, 2), new Tile(4, 4) };

            var randam = new Random(1000);

            for (int i = 0; i < 100; i++)
            {
                Area.AddTile(Tiles[randam.Next(4)]);
                Console.WriteLine(Area.Show());
            }
            Console.ReadLine();
        }
    }

    public class Area
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<int> Grid { get; private set; }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = Enumerable.Repeat(0, width).ToList();
        }

        public string Show()
        {
            string result = "";
            for (int i = 1; i <= Height; i++)
            {
                foreach (var item in Grid)
                {
                    result += item < i ? "□" : "■";
                }
                result += "\n";
            }
            return result;
        }

        private (int pos, int widthCapacity, int heightCapacity) Guide()
        {
            // タイルを配置する場所と容量を案内する
            var pos = Grid.FindIndex(p => p == Grid.Min());
            var widthCapacity = Grid.Skip(pos).TakeWhile(w => w == Grid.Min()).Count();
            var heightCapacity = Height - Grid[pos];
            return (pos, widthCapacity, heightCapacity);
        }

        public bool AddTile(Tile tile)
        {
            var (pos, widthCapacity, heightCapacity) = Guide();

            if ((tile.Width > widthCapacity) || (tile.Height > heightCapacity)) { return false; }

            for (int i = 0; i < tile.Width; i++)
            {
                Grid[pos + i] += tile.Height;
            }
            return true;
        }
    }

    public class Tile
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Tile(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
