using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public enum FieldState
    {
        Unchecked = 0,
        Hint0,
        Hint1,
        Hint2,
        Hint3,
        Hint4,
        Hint5,
        Hint6,
        Hint7,
        Hint8,
        Flag,
        QuestionMark,
        Mine
    }
    class GameFieldMatrix
    {
        private Minesweeper[,] m_Matrix;
        private int m_nNoMineFieldsCount;
        private int m_nOpenFieldsCount = 0;
        private int m_nMineCount;

        public GameFieldMatrix(int nWidth, int nHeight, int nMineCount)
        {
            m_nMineCount = nMineCount;
            m_nNoMineFieldsCount = (nHeight * nWidth) - nMineCount;
            if (m_nNoMineFieldsCount <= 0)
                throw new ArgumentException("Es sind mehr Minen eingestellt, als bei dieser Spielfeld Größe möglich ist");
        }

        private void InitGameFieldMatrix(int nWidth, int nHeight)
        {
            m_Matrix = new Minesweeper[nWidth, nHeight];
            for(int i = 0; i < nWidth; i++)
            {
                for(int j = 0; j < nHeight; j++)
                {
                    m_Matrix[i, j] = new Minesweeper();
                }
            }
        }

        public void NoteFieldClick(int nXCoordinate, int nYCoordinate)
        {
            if (m_nOpenFieldsCount == 0)
                SetMines(nXCoordinate, nYCoordinate);

        }

        private void SetMines(int nXCoordinate, int nYCoordinate)
        {

        }
    }
}
