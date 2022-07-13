using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xand0
{
    public class GameGrid
    {
        private int[,] _grid;

        public int Rows;
        public int Cols;

        public int this[int r ,int c ]
        {
            get=>_grid[r,c];
            set=>_grid[r,c]=value;
        }
        public GameGrid(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;

            _grid = new int[Rows,Cols];
            ClearGrid();
        }

        public int[,] GetGrid()
        {
            return _grid;
        }

      

        public bool VerifyWin(int currentPlayer)
        {

           if (VerifyRows(currentPlayer) == true || VerifyCols(currentPlayer) == true || VerifyD1(currentPlayer) == true || VerifyD2(currentPlayer) == true)
                        return true;
            return false;
            
        }

        public bool VerifyRows(int currentPlayer)
        {
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Cols - 2; j++)
                    if (_grid[i, j] == currentPlayer && _grid[i, j + 1] == currentPlayer && _grid[i, j + 2] == currentPlayer)
                        return true;
            return false;

        }
        public bool VerifyCols(int currentPlayer)
        {
          
                for (int i = 0; i < Rows - 2; i++)
                    for (int j = 0; j < Cols; j++)
                    if (_grid[i, j] == currentPlayer && _grid[i+1, j ] == currentPlayer && _grid[i+2, j] == currentPlayer)
                        return true;
            return false;
        }
     
        public bool VerifyD1(int currentPlayer)
        {

            if (_grid[0, 0] == currentPlayer && _grid[1, 1] == currentPlayer && _grid[2, 2] == currentPlayer)
                return true;
            return false;
        }


        public bool VerifyD2(int currentPlayer)
        {
            if (_grid[0, 2] == currentPlayer && _grid[1, 1] == currentPlayer && _grid[2, 0] == currentPlayer)
                return true;
            return false;
        }

        public void Update(Position currentPosition, int currentPlayer)
        {
            if (currentPlayer == 0)
                _grid[currentPosition.Row, currentPosition.Column] = 0;
            else
                _grid[currentPosition.Row, currentPosition.Column] = 1;
         

        }

        public bool Tie()
        {
            bool ok = true;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    if (_grid[i, j] == -1)
                    {
                        ok = false;
                    }
                }
            }
            return ok;
        }

        public void ClearGrid()
        {
            for(int i=0;i<Rows;i++)
                for(int j=0;j<Cols;j++)
                    _grid[i,j] = -1;
        }

      
    }
}
