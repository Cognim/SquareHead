namespace SquareHead.SequenceGenerators
{
	public interface ISequenceGenerator
	{
		Sequence Generate(int numberOfItems);
	}
}