﻿using System;
using Chess.Pieces;
using Chess.Util;
using System.Data;

namespace Chess.Gui
{
    public class Game
    {
        public static readonly int MaxRow = 8, MaxColumn = 8;
        private static Game instance;     

        private Player white, black;
        public Player White => white;
        public Player Black => black;        

        public Square[,] squares { get; set; }

        /// <summary>
        ///     Singleton that creates new game instance if current is null
        /// </summary>
        /// <returns>Get singleton</returns>
        public static Game GetInstance()
        {
            if (instance == null)
                instance = new Game();

            return instance;
        }

        private Game()
        {
        }

        public Game NewGame(Player white, Player black)
        {
            instance = new Game();           

            this.white = white;
            this.black = black;

            //InitSquares();

            return instance;
        }

        public void AddPieceToSquare(Piece piece, int row, int column)
        {
            Square square = GetSquare(row, column);
            if (square != null)
            {
                square.SetPiece(piece);
            }
        }

        public Square GetSquare(int row, int column)
        {
            if (squares == null) return null;
            return squares[row, column];
        }

        internal bool ClickSquare(int row, int column)
        {
            Square square = GetSquare(row, column);
            if (square == null || square.CurrPiece == null || square.CurrPiece.PieceType == Enums.PieceType.None)
                return false;

            return square.CurrPiece.Click();
        }

        public void Score(Piece destPiece)
        {
            Player scorer, loser;
            if (white.Color == destPiece.Color)
            {
                scorer = black;
                loser = white;
            }
            else
            {
                scorer = white;
                loser = black;
            }

            scorer.Score += (int) destPiece.PieceType;
            loser.RemovePiece(destPiece);
        }

        public bool InCheck(Enums.Color color, Square destSquare)
        {
            Player checkPlayer = (white.Color == color) ? white : black;

            return !checkPlayer.inCheck && !checkPlayer.CanCheck(destSquare);
        }
    }
}