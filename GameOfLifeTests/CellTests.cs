using Xunit;
using GameOfLife;

namespace GameOfLifeTests
{
    public class CellTests
    {
        [Fact]
        public void Cell_Initializes_AsDead()
        {
            var cell = new Cell(false);
            Assert.False(cell.IsAlive);
        }

        [Fact]
        public void Cell_Initializes_AsAlive()
        {
            var cell = new Cell(true);
            Assert.True(cell.IsAlive);
        }

        [Fact]
        public void Cell_Can_Be_Toggled()
        {
            var cell = new Cell(false);
            cell.IsAlive = true;
            Assert.True(cell.IsAlive);
        }
    }
}
