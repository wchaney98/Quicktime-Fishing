using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Location 
{
    public abstract Color ColorBonus { get; }
    public abstract int[] OptimalFishingHours { get; }

    public float BaseColorChance = 0.1f;
}
