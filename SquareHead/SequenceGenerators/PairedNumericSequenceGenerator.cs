using System;
using System.Linq;

namespace SquareHead.SequenceGenerators
{
	public class PairedNumericSequenceGenerator : ISequenceGenerator
	{
		public Sequence Generate(int numberOfItems)
		{
			var sequence = new Sequence {FirstItem = null};
			var rand = new Random();
			var lowerBand = 100;
			var upperBand = 999;

			for (var i = 1; i < numberOfItems + 1; i += 2)
			{
				string value;
				do
				{
					value = rand.Next(lowerBand, upperBand).ToString();
				} while (sequence.Items.Exists(item => item.Value == value));

				sequence.Items.Add(new SequenceItem {Value = value.ToString(), NextItem = i + 1});
				sequence.Items.Add(new SequenceItem {Value = value.ToString(), NextItem = i});
			}

			return sequence;
		}
	}
}