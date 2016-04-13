﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Game;
using Chess.Util;

namespace Chess.Pieces
{
    internal class King : Piece
    {
        public King(Enums.Color color) : base(Enums.PieceType.King, color)
        {
        }

        public override bool CanMoveTo(Square destSquare)
        {
            return (Math.Abs(currRow - destSquare.Row) < 2) && (Math.Abs(currColumn - destSquare.Column) < 2);
        }
    }
}
