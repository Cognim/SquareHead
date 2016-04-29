namespace SquareHead.Models
{
	public class Cell
	{
		public int Id { get; set; }
		public string Value { get; set; }
		public int? NextCellId { get; set; }
	}
}