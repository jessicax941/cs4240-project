/// <summary>
/// Representation of good (more environmentally-friendly) and Bad (less environmentally-friendly) choices.
/// </summary>
public enum GoodChoice
{
    Chicken,
    DineIn,
    Bag,
    NoUtensils
}

public enum BadChoice {
    Pork,
    Takeaway,
    PlasticBag,
    Utensils
}

/// <summary>
/// Converts Choice to string format to be used in the UI buttons.
/// </summary>
public static class ChoiceRepresentation
{
    public static string ToString(this GoodChoice choice)
    {
        switch (choice)
        {
            case GoodChoice.Chicken:
                return "Chicken";
            case GoodChoice.DineIn:
                return "Dine In";
            case GoodChoice.Bag:
                return "No";
            case GoodChoice.NoUtensils:
                return "No";
            default:
                return "Unknown GoodChoice value";
        }
    }

    public static string ToString(this BadChoice choice)
    {
        switch (choice)
        {
            case BadChoice.Pork:
                return "Pork";
            case BadChoice.Takeaway:
                return "Takeaway";
            case BadChoice.PlasticBag:
                return "Yes";
            case BadChoice.Utensils:
                return "Yes";
            default:
                return "Unknown BadChoice value";
        }
    }
}
