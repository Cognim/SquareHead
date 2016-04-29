using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SquareHead.Models;
using SquareHead.SequenceGenerators;

namespace SquareHead.Tests
{
	[TestFixture]
	internal class GridTests
	{
		[TestCase(3, 4, 12)]
		[TestCase(5, 5, 25)]
		public void New_Grid_Has_The_Correct_Number_Of_Cells(int rows, int columns, int expected)
		{
			var grid = new Grid(rows, columns);
			var actual = grid.Cells.Count;
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void All_Cells_Are_Assigned_Sequential_Unique_Ids()
		{
			var rows = 8;
			var columns = 12;
			var grid = new Grid(rows, columns);

			grid.Cells.Select(cell => cell.Id).Should().BeInAscendingOrder().And.OnlyHaveUniqueItems();
		}

		[Test]
		public void Grid_Cell_Positions_Can_Be_Randomised()
		{
			var rows = 2;
			var columns = 2;
			var grid = new Grid(rows, columns);

			var sequenceGenerator = new Mock<ISequenceGenerator>();
			var sequence = new Sequence
			{
				FirstItem = 1,
				Items = new List<SequenceItem>
				{
					new SequenceItem {Value = "1", NextItem = 2},
					new SequenceItem {Value = "2", NextItem = 3},
					new SequenceItem {Value = "3", NextItem = 4},
					new SequenceItem {Value = "4", NextItem = 1}
				}
			};
			sequenceGenerator.Setup(generator => generator.Generate(It.IsAny<int>())).Returns(sequence);

			grid.PopulateCells(sequenceGenerator.Object);
			grid.RandomiseCells();

			grid.Cells.Select(cell => cell.Id).Should().NotBeAscendingInOrder();
		}

		[Test]
		public void Grid_Cells_Are_Correctly_Populated_By_Passed_In_SequenceGenerator()
		{
			var rows = 2;
			var columns = 2;
			var grid = new Grid(rows, columns);

			var sequenceGenerator = new Mock<ISequenceGenerator>();
			var sequence = new Sequence
			{
				FirstItem = 1,
				Items = new List<SequenceItem>
				{
					new SequenceItem {Value = "1", NextItem = 2},
					new SequenceItem {Value = "2", NextItem = 3},
					new SequenceItem {Value = "3", NextItem = 4},
					new SequenceItem {Value = "4", NextItem = 1}
				}
			};
			sequenceGenerator.Setup(generator => generator.Generate(It.IsAny<int>())).Returns(sequence);

			var expectedCells = new List<Cell>
			{
				new Cell {Id = 1, Value = "1", NextCellId = 2},
				new Cell {Id = 2, Value = "2", NextCellId = 3},
				new Cell {Id = 3, Value = "3", NextCellId = 4},
				new Cell {Id = 4, Value = "4", NextCellId = 1}
			};

			grid.PopulateCells(sequenceGenerator.Object);

			grid.Cells.ShouldBeEquivalentTo(expectedCells);
		}
	}
}