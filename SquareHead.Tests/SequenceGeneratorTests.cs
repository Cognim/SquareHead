using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using SquareHead.SequenceGenerators;

namespace SquareHead.Tests
{
	[TestFixture]
	internal class SequenceGeneratorTests
	{
		[TestCase(1)]
		[TestCase(13)]
		public void Stepped_Sequence_Generates_Correct_Values(int step)
		{
			var sequenceGenerator = new SteppedSequenceGenerator(step);
			var actual = sequenceGenerator.Generate(4);
			var expected = new Sequence
			{
				FirstItem = 1,
				Items = new List<SequenceItem>
				{
					new SequenceItem {Value = (1*step).ToString(), NextItem = 2},
					new SequenceItem {Value = (2*step).ToString(), NextItem = 3},
					new SequenceItem {Value = (3*step).ToString(), NextItem = 4},
					new SequenceItem {Value = (4*step).ToString(), NextItem = 1}
				}
			};

			actual.ShouldBeEquivalentTo(expected);
		}

		[Test]
		public void Random_Sequence_Generates_Correct_Values()
		{
			var sequenceGenerator = new RandomSequenceGenerator();
			var actual1 = sequenceGenerator.Generate(4);
			var actual2 = sequenceGenerator.Generate(4);
			actual1.Items.Should().NotBeEquivalentTo(actual2.Items);
			actual1.Items.Select(s => s.Value).Should().OnlyHaveUniqueItems();
			actual1.Items.Select(s => int.Parse(s.Value)).Should().BeInAscendingOrder();
		}

		[Test]
		public void Paired_Numeric_Sequence_Only_Returns_Pairs()
		{
			var sequenceGenerator = new PairedNumericSequenceGenerator();
			var actual = sequenceGenerator.Generate(10);
			var groupedNumbers = actual.Items.GroupBy(g => g.Value).ToDictionary(d=>d.Key, d=>d.Count());
			groupedNumbers.Max(d => d.Value).Should().Be(2);
			groupedNumbers.Min(d => d.Value).Should().Be(2);
			actual.FirstItem.Should().Be(null);
		}

		[Test]
		public void Paired_Numeric_Sequence_Has_No_Start_Item()
		{
			var sequenceGenerator = new PairedNumericSequenceGenerator();
			var actual = sequenceGenerator.Generate(10);
			actual.FirstItem.Should().Be(null);
		}

		[Test]
		public void Paired_Numeric_Sequence_Pairs_Point_To_Each_Other()
		{
			var sequenceGenerator = new PairedNumericSequenceGenerator();
			var actual = sequenceGenerator.Generate(10);

			for (int i = 0; i < actual.Items.Count; i++)
			{
				var itemBeingChecked = actual.Items[i];
				var itemPair = actual.Items.Single(item => item.Value == itemBeingChecked.Value && item != itemBeingChecked);
				itemPair.NextItem.Should().Be(i+1); // Not 0 based
			}

			actual.FirstItem.Should().Be(null);
		}
	}
}