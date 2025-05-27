using Xunit;
using GameOfLife;

namespace GameOfLifeTests
{
    public class GameTests
    {
        [Fact]
        public void Game_Creates_Grid_Properly()
        {
            var game = new Game(5, 5);
            Assert.NotNull(game);
        }

        public bool IsCellAlive(int x, int y)
        {
            return IsInBounds(x, y) && Cells[y, x].IsAlive;
        }
    }
}
