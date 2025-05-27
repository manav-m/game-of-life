using Xunit;
using GameOfLifeApp;

namespace GameOfLifeTests
{
    public class GridTests
    {
        [Fact]
        public void Grid_Correctly_Initializes_Size()
        {
            var grid = new Grid(5, 5);
            Assert.True(grid.IsInBounds(0, 0));
            Assert.True(grid.IsInBounds(4, 4));
            Assert.False(grid.IsInBounds(5, 5));
            Assert.False(grid.IsInBounds(-1, 0));
        }

        [Fact]
        public void Grid_Sets_Cell_Alive()
        {
            var grid = new Grid(3, 3);
            grid.SetCellAlive(1, 1, true);
            Assert.True(grid.IsCellAlive(1, 1));
        }

        [Fact]
        public void Grid_Updates_Correctly_With_Single_Cell()
        {
            var grid = new Grid(3, 3);
            grid.SetCellAlive(1, 1, true); // single live cell

            grid.Update();

            // Single cell with no neighbors should die
            Assert.False(grid.IsCellAlive(1, 1));
        }

        [Fact]
        public void Grid_Updates_Correctly_With_Block_Pattern()
        {
            var grid = new Grid(4, 4);

            // Create stable 2x2 block
            grid.SetCellAlive(1, 1, true);
            grid.SetCellAlive(1, 2, true);
            grid.SetCellAlive(2, 1, true);
            grid.SetCellAlive(2, 2, true);

            grid.Update();

            // Block should stay the same
            Assert.True(grid.IsCellAlive(1, 1));
            Assert.True(grid.IsCellAlive(1, 2));
            Assert.True(grid.IsCellAlive(2, 1));
            Assert.True(grid.IsCellAlive(2, 2));
        }
    }
}
