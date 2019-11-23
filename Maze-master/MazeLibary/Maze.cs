using System;
using System.Collections.Generic;
using System.Linq;
using MazeLibrary.Cells;
using MazeLibrary.Interfaces;
using MazeLibrary.WallGeneration;

namespace MazeLibrary
{
    public class Maze
    {
        public int Height { get; }
        public int Width { get; }

        public Maze(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            for (int y = 0; y < this.Width; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    if (x == 0) this.Cells.Add(new Wall(x, y));
                    else if (x == this.Width - 1) this.Cells.Add(new Wall(x, y));
                    else if (y == 0) this.Cells.Add(new Wall(x, y));
                    else if (y == this.Height - 1) this.Cells.Add(new Wall(x, y));
                    else this.Cells.Add(new Ground(x, y));
                    this[x, y].Checked = false;
                }
            }
        }
        public Maze(int height, int width,WallGenerationInterface GenAlg=null)
        {
            this.Height = height;
            this.Width = width;
            Cells = GenAlg.GenerateMaze(height, width);
        }

        public List<BaseCell> Cells { get; set; } = new List<BaseCell>(); //delete set


        public void TryToStep(Direction direction)
        {
            BaseCell cellToMove = null;

            var hero = Player.GetPlayer;

            switch (direction)
            {
                case Direction.Up:
                    cellToMove = this[hero.Coordinates.X, hero.Coordinates.Y - 1];
                    break;
                case Direction.Right:
                    cellToMove = this[hero.Coordinates.X + 1, hero.Coordinates.Y ];
                    break;
                case Direction.Down:
                    cellToMove = this[hero.Coordinates.X, hero.Coordinates.Y + 1];
                    break;
                case Direction.Left:
                    cellToMove = this[hero.Coordinates.X - 1, hero.Coordinates.Y];
                    break;
            }
            for (int i = hero.Coordinates.X - 1; i <= hero.Coordinates.X + 1; i++)
            {
                for (int j= hero.Coordinates.Y-1; j<=hero.Coordinates.Y+1;j++) this[i,j].Checked = true;
            }
            if (cellToMove?.TryToStep() ?? false)
            {
                hero.Coordinates = cellToMove.Coordinates;
            }
        }

        public BaseCell this[int x, int y]
        {

            //var cell = Maze[1,2];
            get
            {
                return Cells.SingleOrDefault(cell => cell.Coordinates.X == x && cell.Coordinates.Y == y);
            }

            //Maze[1,2] = new Wall(1,2);
            set
            {
                var oldCell = this[value.Coordinates.X, value.Coordinates.Y];
                if (oldCell != null)
                {
                    Cells.Remove(oldCell);
                }
                Cells.Add(value);
            }
        }
    }
}
