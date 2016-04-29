using System;
using System.Collections.Generic;
using System.Linq;
using SquareHead.SequenceGenerators;

namespace SquareHead.Models
{
	public class Grid
	{
		public Grid(int rows, int columns)
		{
			NumberOfRows = rows;
			NumberOfColumns = columns;

			for (var i = 0; i < rows*columns; i++)
			{
				Cells.Add(new Cell {Id = i + 1});
			}
		}

		public int NumberOfRows { get; }
		public int NumberOfColumns { get; }
		public int NumberOfCells => NumberOfRows*NumberOfColumns;
		public int? FirstCellId { get; private set; }

		public List<Cell> Cells { get; set; } = new List<Cell>();

		public void PopulateCells(ISequenceGenerator sequenceGenerator)
		{
			var sequence = sequenceGenerator.Generate(Cells.Count);
			FirstCellId = sequence.FirstItem;
			Enumerable.Range(0, Cells.Count).ToList()
				.ForEach(i => PopulateCellFromSequence(Cells[i], sequence.Items[i]));
		}

		private void PopulateCellFromSequence(Cell cell, SequenceItem sequenceItem)
		{
			cell.Value = sequenceItem.Value;
			cell.NextCellId = sequenceItem.NextItem;
		}

		public void RandomiseCells()
		{
			Cells = Cells.OrderBy(guid => Guid.NewGuid()).ToList();
		}
	}
}