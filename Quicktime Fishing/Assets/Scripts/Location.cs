using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Location 
{
    Color colorBonus;
    int[] optimalFishingHours;
    string[] prefixes;

    public Location(Color colorBonus, int[] optimalFishingHours, string[] prefixes)
    {
        this.colorBonus = colorBonus;
        this.optimalFishingHours = optimalFishingHours;
        this.prefixes = prefixes;
    }

    public virtual Color ColorBonus { get { return colorBonus; } }
    public virtual int[] OptimalFishingHours { get { return optimalFishingHours; } }
    public virtual string[] Prefixes { get { return prefixes; } }
}
