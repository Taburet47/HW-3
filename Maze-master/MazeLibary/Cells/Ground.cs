namespace MazeLibrary.Cells
{
    public class Ground : BaseCell
    {
        public Ground(Coordinates coordinates) : base(coordinates, ' ')
        {
        }

        public Ground(int x, int y) : base(x, y, ' ')
        {
        }

        public override bool TryToStep()
        {
            return true;
        }
    }
}
