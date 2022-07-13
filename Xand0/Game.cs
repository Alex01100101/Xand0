using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xand0
{
   public class Game
    {
        
        public GameGrid GameGrid { get; set; }
        private int _player;
        private bool _gameOver;
        public int Player
        {
            get => _player;
            set => _player = value;
        }

      
        public bool GameOver
        {
            get => _gameOver;
            set => _gameOver = value;
        }
        public Game()
        {
            GameGrid = new GameGrid(3, 3);
            Reset();
        }

        public void Reset()
        {
            _player = 0;
            _gameOver = false;
            GameGrid.ClearGrid();
        }
        public bool IsGameOver()
        {
            if (GameGrid.VerifyWin(0) == true)
                return true;
            
            if (GameGrid.VerifyWin(1) == true)
                return true;
           
            if (GameGrid.Tie() == true)
                   return true;
            
            return false;

        }
        public void Move(Position currentPos, int currentPlayer)
        {
           
           
            
                if (currentPlayer == 0)
                {
                    _player = 1;

                }
                else
                {
                    _player = 0;

                }
                GameGrid.Update(currentPos, currentPlayer);
            
        }
    }
}
