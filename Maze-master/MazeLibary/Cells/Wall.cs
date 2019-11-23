namespace MazeLibrary.Cells
{
    public class Wall : BaseCell
    {
        public Wall(Coordinates coordinates) : base(coordinates, '#')
        {
        }

        public Wall(int x, int y) : base(x, y, '#')
        {
        }

        public override bool TryToStep()
        {
            return false;
        }
    }
}
