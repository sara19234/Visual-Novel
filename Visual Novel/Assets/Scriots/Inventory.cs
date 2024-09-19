using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    Iso,
    Guardian,
    OtherIso,
    Armour,
    Ghost
}
public class Inventory
{
   private List<Item> currentItems = new List<Item>();

    public void Collect(Item item)
    {
        currentItems.Add(item);
    }

    public bool Has(Item item)
    {
        return currentItems.Contains(item);
    }
}
