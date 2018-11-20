using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q40_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            var Area = new Area(10, 10);
            var Tiles = new List<Tile> { new Tile(1, 1), new Tile(2, 2), new Tile(4, 2), new Tile(4, 4) };
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

        public bool AddTile(Tile tile)
        {
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
