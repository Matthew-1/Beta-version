using barcosFinal;
using barcosFinal.Interfaces;
using NUnit.Framework;

namespace Tests
{
    public class BattleFieldTests
    {
        [Test]
        public void T_01_BattleFieldBoardLengthIs100()
        {
            //given
            IBattleField board = new BattleField();
            int length = 100;

            //when
            board.DrawBoard();

            //expected
            int result = board.Board.Length;

            Assert.AreEqual(length, result);
        }

        [Test]
        public void T_01_BattleFieldBoardHasOnlyEmptyFields()
        {
            //given
            IBattleField board = new BattleField(); 
            

            //when
            board.DrawBoard();

            //expected

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    char result = board.Board[i, j];

                    Assert.AreEqual('o', result);
                }
            }
            
        }
    }
}