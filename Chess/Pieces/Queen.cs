﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Game;
using Chess.Util;

namespace Chess.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Enums.Color color) : base(Enums.PieceType.Queen, color)
        {
        }
        
        public override bool CanMoveTo(Square destSquare)
        {
            int destColumn = destSquare.Column;
            int destRow = destSquare.Row;
            
            // loop horizontal or vertical
            if (destColumn == currColumn)
            {
                if (destRow > currRow) return IsMatch(destSquare, 1, 0);
                if (destRow < currRow) return IsMatch(destSquare, -1, 0);
            }
            else if (destRow == currRow)
            {
                if (destColumn > currColumn) return IsMatch(destSquare, 0, 1);
                if (destColumn < currColumn) return IsMatch(destSquare, 0, -1);
            }

            // loop diagonal
            if (destRow > currRow) return IsMatch(destSquare, 1, 1) || IsMatch(destSquare, 1, -1);
            if (destRow < currRow) return IsMatch(destSquare, -1, 1) || IsMatch(destSquare, -1, -1);

            return false;
        }
    }
}
