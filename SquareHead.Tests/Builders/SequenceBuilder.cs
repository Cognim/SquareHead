using System.Collections.Generic;
using SquareHead.SequenceGenerators;

namespace SquareHead.Tests.Builders
{
	public class SequenceBuilder
	{
		private readonly List<SequenceItem> sequence;

		public SequenceBuilder()
		{
			sequence = new List<SequenceItem>();
		}

		public static implicit operator List<SequenceItem>(SequenceBuilder builder)
		{
			return builder.sequence;
		}

		public SequenceBuilder WithSequenceItem(string value, int nextItem)
		{
			var sequenceItem = new SequenceItem {Value = value, NextItem = nextItem};
			sequence.Add(sequenceItem);
			return this;
		}
	}
}