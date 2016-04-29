using System.Collections.Generic;

namespace SquareHead.SequenceGenerators
{
	public class Sequence
	{
		public Sequence()
		{
			Items = new List<SequenceItem>();
		}

		public int? FirstItem { get; set; }

		public List<SequenceItem> Items { get; set; }
	}
}