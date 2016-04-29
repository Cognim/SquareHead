using System.Web.Http;
using SquareHead.Models;
using SquareHead.SequenceGenerators;

namespace SquareHead.Controllers
{
	[RoutePrefix("api/grid")]
	public class GridsController : ApiController
	{
		[Route("step")]
		[HttpGet]
		public Grid GetSteppedGrid(int rows = 5, int columns = 2, int steps = 1)
		{
			var grid = new Grid(rows,columns);
			var sequenceGenerator = new SteppedSequenceGenerator(steps);
			grid.PopulateCells(sequenceGenerator);
			grid.RandomiseCells();
			return grid;
		}

		[Route("random")]
		[HttpGet]
		public Grid GetRandomGrid(int rows = 5, int columns = 2)
		{
			var grid = new Grid(rows, columns);
			var sequenceGenerator = new RandomSequenceGenerator();
			grid.PopulateCells(sequenceGenerator);
			grid.RandomiseCells();
			return grid;
		}

		[Route("numberpairs")]
		[HttpGet]
		public Grid GetPairedNumericGrid(int rows = 5, int columns = 2)
		{
			var grid = new Grid(rows, columns);
			var sequenceGenerator = new PairedNumericSequenceGenerator();
			grid.PopulateCells(sequenceGenerator);
			grid.RandomiseCells();
			return grid;
		}

		[Route("wordpairs")]
		[HttpGet]
		public Grid GetPairedWordGrid(int rows = 5, int columns = 2)
		{
			var grid = new Grid(rows, columns);
			var sequenceGenerator = new PairedWordsSequenceGenerator();
			grid.PopulateCells(sequenceGenerator);
			grid.RandomiseCells();
			return grid;
		}
	}
}