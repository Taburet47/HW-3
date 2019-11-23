using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary.Cells
{
    public abstract class BaseCell
    {
        protected BaseCell(Coordinates coordinates, char skin)
        {
            Coordinates = coordinates;
            Skin = skin;
        }

        protected BaseCell(int x, int y, char skin)
        {
            Coordinates = new Coordinates(x, y);
            Skin = skin;
        }
        public Coordinates Coordinates { get; set; }

        public bool Checked { get; set; }
        public char Skin { get; private set; }

        public abstract bool TryToStep();
    }
}
