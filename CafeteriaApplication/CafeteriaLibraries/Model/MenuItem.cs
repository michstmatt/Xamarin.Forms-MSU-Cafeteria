
namespace CafeteriaLibraries
{
	public enum MealType
	{
		Breakfast,
		Lunch,
		Dinner,
		Late
	}
    public class MenuItem
    {
		public string Name { get; set; }
		public MealType Meal { get; set; }
    }

}
