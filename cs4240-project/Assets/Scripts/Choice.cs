using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoodChoice
{
    Chicken,
    DineIn,
}

public enum BadChoice {
    Pork,
    Takeaway
}

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
            default:
                return "Unknown BadChoice value";
        }
    }
}
