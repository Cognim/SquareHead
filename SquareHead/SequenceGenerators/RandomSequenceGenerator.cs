using System;

namespace SquareHead.SequenceGenerators
{
	public class RandomSequenceGenerator : ISequenceGenerator
	{
		public Sequence Generate(int numberOfItems)
		{
			var sequence = new Sequence {FirstItem = 1};
			var rand = new Random();
			var lowerBand = 1;

			for (var i = 1; i < numberOfItems + 1; i++)
			{
				var value = rand.Next(lowerBand, Convert.ToInt32(lowerBand*1.5));
				lowerBand = value + 1;
				sequence.Items.Add(new SequenceItem {Value = value.ToString(), NextItem = i == numberOfItems ? 1 : i + 1});
			}

			return sequence;
		}
	}
}