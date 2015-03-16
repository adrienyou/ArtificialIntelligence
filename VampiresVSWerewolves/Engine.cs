﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VampiresVSWerewolves
{
    public class Engine
    {
        // Class contenant les méthodes du moteur de décision du jeu

        public Engine()
        {

        }

        public List<State> Successor(State state, CellType type) 
        {
            // Copy the parent in order to use it to generate all successors
            

            CellType ennemyType = CellType.Vampires;
            if (type == CellType.Vampires)
            {
                ennemyType = CellType.Werewolves;
            }

            List<Cell> friendCells = state.GetCells(type);
            List<Cell> ennemyCells = state.GetCells(ennemyType);

            return null;
        }

        public HashSet<Move> getMoves(Cell cell, List<Cell> ennemyCells) {
            HashSet<Move> moves = new HashSet<Move>();
            foreach (Cell ennemyCell in ennemyCells)
            {
                int x = Math.Max(cell.Position.X + Math.Max(Math.Min(cell.Position.X, 1), -1), 0);
                int y = Math.Max(cell.Position.Y + Math.Max(Math.Min(cell.Position.Y, 1), -1), 0);
                Position pos = new Position(x, y);
                Move move = new Move(cell.Position.X, cell.Position.Y, cell.Pop, x, y);
                moves.Add(move);
            }

            return moves;
        }

        public List<Move> RandomSuccessor(State state)
        {
            // We get the list of our cells
            List<Cell> cells = state.GetFriendlyCells();

            // The moves list returned
            List<Move> moves = new List<Move>();

            foreach(Cell cell in cells)
            {

                // We loop while the random position is not a valid position
                bool isNewPositionOK = false;
                while(!isNewPositionOK)
                {
                    Random rand = new Random();
                    int ToX = rand.Next(3);
                    int ToY = rand.Next(3);

                    if (ToX == 2) { ToX = -1; };
                    if (ToY == 2) { ToY = -1; };

                    Position randomPosition = new Position(ToX + cell.Position.X, ToY + cell.Position.Y);

                    isNewPositionOK = randomPosition.isValid(state.Map);

                    // The move is all the pop, from old cell to new cell
                    Move randomMove = new Move(cell.Position.X, cell.Position.Y, randomPosition.X, randomPosition.Y, cell.Pop);

                    moves.Add(randomMove);
                }
            }

            return moves;
        }
    }
}
