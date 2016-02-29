using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Location 
{
    public abstract RarityColor ColorBonus { get; }
    public abstract int[] OptimalFishingHours { get; }
    public abstract bool FirstNumPM { get; }
    public abstract bool SecondNumPM { get; }
}
