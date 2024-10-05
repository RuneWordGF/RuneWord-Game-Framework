using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class HandleNavigation
{
    public static Selectable ReturnSelectable(Selectable input, Vector2 direction)
    {
        Selectable newItem = input;

        if (direction.y != 0)
        {
            if (direction.y > 0)
            {
                newItem = newItem.FindSelectableOnUp();
                if (newItem == null)
                {
                    return SelectLastDown(input);
                }
                return newItem;
            }
            else
            {
                newItem = newItem.FindSelectableOnDown();
                if (newItem == null)
                {
                    return SelectLastUp(input);
                }
                return newItem;
            }
        }

        if (direction.x != 0)
        {
            if (direction.x > 0)
            {
                newItem = newItem.FindSelectableOnRight();
                if (newItem == null)
                {
                    return SelectLastLeft(input);
                }
                return newItem;
            }
            else
            {
                newItem = newItem.FindSelectableOnLeft();
                if (newItem == null)
                {
                    return SelectLastRight(input);
                }
                return newItem;
            }
        }

        return newItem;
    }

    public static Selectable SelectLastUp(Selectable input)
    {
        Selectable previous = input;
        Selectable attempted = input;
        while (attempted != null)
        {
            previous = attempted;
            attempted = attempted.FindSelectableOnUp();
        }
        return previous;
    }

    public static Selectable SelectLastDown(Selectable input)
    {
        Selectable previous = input;
        Selectable attempted = input;
        while (attempted != null)
        {
            previous = attempted;
            attempted = attempted.FindSelectableOnDown();
        }
        return previous;
    }

    public static Selectable SelectLastRight(Selectable input)
    {
        Selectable previous = input;
        Selectable attempted = input;
        while (attempted != null)
        {
            previous = attempted;
            attempted = attempted.FindSelectableOnRight();
        }
        return previous;
    }

    public static Selectable SelectLastLeft(Selectable input)
    {
        Selectable previous = input;
        Selectable attempted = input;
        while (attempted != null)
        {
            previous = attempted;
            attempted = attempted.FindSelectableOnUp();
        }
        return previous;
    }
}
