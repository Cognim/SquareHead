using System.Linq;

namespace SquareHead.SequenceGenerators
{
	public class SteppedSequenceGenerator : ISequenceGenerator
	{
		private readonly int steps;

		public SteppedSequenceGenerator(int steps)
		{
			this.steps = steps;
		}

		public Sequence Generate(int numberOfItems)
		{
			var sequence = new Sequence
			{
				FirstItem = 1,
				Items = Enumerable.Range(1, numberOfItems)
					.Select(i => new SequenceItem {Value = (i*steps).ToString(), NextItem = i == numberOfItems ? 1 : i + 1})
					.ToList()
			};
			return sequence;
		}
	}
}