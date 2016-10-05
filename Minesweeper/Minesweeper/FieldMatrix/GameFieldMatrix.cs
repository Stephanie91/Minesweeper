using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.FieldMatrix
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
        #region Member
        private Minesweeper[,] m_Matrix;
        private int m_nNoMineFieldsCount;
        private int m_nOpenFieldsCount = 0;
        private int m_nMineCount;
        #endregion

        #region ctor
        public GameFieldMatrix(int nWidth, int nHeight, int nMineCount)
        {
            m_nMineCount = nMineCount;
            m_nNoMineFieldsCount = (nHeight * nWidth) - nMineCount;
            if (m_nNoMineFieldsCount <= 0)
                throw new ArgumentException("Es sind mehr Minen eingestellt, als bei dieser Spielfeld Größe möglich ist");

            InitGameFieldMatrix(nWidth, nHeight);
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Init die FieldMatrix
        /// </summary>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
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

        /// <summary>
        /// registriert das Clicken auf dem Spielfeld
        /// </summary>
        /// <param name="nXCoordinate"></param>
        /// <param name="nYCoordinate"></param>
        public void NoteFieldClick(int nXCoordinate, int nYCoordinate)
        {
            if (m_nOpenFieldsCount == 0)
            {
                SetMines(nXCoordinate, nYCoordinate);
            }

        }

        /// <summary>
        /// Setzt die Mienen auf dem Spielfeld
        /// </summary>
        /// <param name="nXCoordinate">X Koordinate des Felds, wo keine Miene sein darf</param>
        /// <param name="nYCoordinate">Y Koordinate des Felds, wo keine Miene sein darf</param>
        private void SetMines(int nXCoordinate, int nYCoordinate)
        {
            Random rnd = new Random();
            int nWidth = m_Matrix.GetLength(0) - 1;
            int nHeight = m_Matrix.GetLength(1) - 1;
            for (int i = 0; i < m_nMineCount; i++)
            {
                int nX = rnd.Next(nWidth);
                int nY = rnd.Next(nHeight);

                //solange suchen, bis ein freies feld gefunden wurde
                while (m_Matrix[nX,nY].IsMine || (nX == nXCoordinate && nY == nYCoordinate) )
                {
                    nX++;
                    if(nX > nWidth)
                    {
                        nX = 0;
                        nY++;
                        if (nY > nHeight)
                            nY = 0;
                    }
                    else
                    {
                        //kein überlauf
                    }
                }

                m_Matrix[nX, nY].IsMine = true;
            }
            #endregion
        }
    }
}
