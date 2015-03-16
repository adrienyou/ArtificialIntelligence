﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VampiresVSWerewolves;

namespace UnitTesting
{
    /// <summary>
    /// Summary description for StateTest
    /// </summary>
    [TestClass]
    public class StateTest
    {

         /// <summary>
        /// Test to check that the list of cells is sorted the right way.
        /// </summary>
        [TestMethod]
        public void sortCellsByDistanceToCenterCell_Test()
        {
            Cell centerCell = new Cell(0, 0, CellType.Humans, 10);
            Cell vampCell1 = new Cell(1, 1, CellType.Vampires, 3);
            Cell vampCell2 = new Cell(2, 2, CellType.Vampires, 2);
            List<Cell> cells = new List<Cell> {vampCell2, vampCell1};

            State.sortCellsByDistance(centerCell, cells);
            Assert.AreEqual(cells[0], vampCell1);

        }

        /// <summary>
        /// Test to check that the properties are correctly set when the State object is instantiated.
        /// </summary>
        [TestMethod]
        public void UpdateCell_Test()
        {
            Map map = new Map(10, 10, CellType.Vampires);
            State state = new State(map);

            List<State> empty_list = new List<State>();
            Assert.AreEqual(empty_list, state.GetCells(CellType.Humans));
            Assert.AreEqual(empty_list, state.GetCells(CellType.Vampires));
            Assert.AreEqual(empty_list, state.GetCells(CellType.Werewolves));

            Position pos = new Position(2, 3);
            state.UpdateCell(2, 3, CellType.Humans, 6);

            Cell cell = (Cell)state.Cells[pos.Stringify()];
            Assert.AreEqual(6, cell.Pop);
            Assert.AreEqual(2, cell.Position.X);
            Assert.AreEqual(3, cell.Position.Y);
        }
    }
}
