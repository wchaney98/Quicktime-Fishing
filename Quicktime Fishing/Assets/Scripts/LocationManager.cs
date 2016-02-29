using UnityEngine;
using System.Collections;

/// <summary>
/// Class for fishing locations
/// </summary>
public class LocationManager
{
   
    public RarityColor CurrentLocColorBonus { get { return currentLoc.ColorBonus; ; } }
    public int[] CurrentLocOptimalFishingHours { get { return currentLoc.OptimalFishingHours; } }
    public bool CurrentLocFirstNumPM { get { return currentLoc.FirstNumPM; } }
    public bool CurrentLocSecondNumPM { get { return currentLoc.SecondNumPM; } }

    public Location CurrentLoc { get { return currentLoc; } }

    Location currentLoc;

    public void Initialize(FishingLocation loc)
    {
        switch (loc)
        {
            case FishingLocation.FishVille:
                currentLoc = new FishVille();
                break;

            case FishingLocation.LargeBodyOfWater:
                currentLoc = new LargeBodyOfWater();
                break;

            case FishingLocation.BingoBango:
                currentLoc = new BingoBango();
                break;

            case FishingLocation.HolyShrimp:
                currentLoc = new HolyShrimp();
                break;
        }
    }
}

public enum RarityColor : byte { Blue, Red, Green, Gold }

public enum FishingLocation : byte { FishVille, LargeBodyOfWater, BingoBango, HolyShrimp }

/// <summary>
/// Location, 40% increase of blue
/// </summary>
class FishVille : Location
{
    RarityColor colorBonus = RarityColor.Blue;
    int[] optimalFishingHours = new int[2] { 4, 12 };
    bool firstNumPM = false;
    bool secondNumPM = false;

    public override RarityColor ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
    public override bool FirstNumPM { get { return firstNumPM; } }
    public override bool SecondNumPM { get { return secondNumPM; } }
}

/// <summary>
/// Location, 40% increase of red
/// </summary>
class LargeBodyOfWater : Location
{
    RarityColor colorBonus = RarityColor.Red;
    int[] optimalFishingHours = new int[2] { 10, 6 }; 
    bool firstNumPM = false;
    bool secondNumPM = true;

    public override RarityColor ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
    public override bool FirstNumPM { get { return firstNumPM; } }
    public override bool SecondNumPM { get { return secondNumPM; } }
}

/// <summary>
/// Location, 40% increase of green
/// </summary>
class BingoBango : Location
{
    RarityColor colorBonus = RarityColor.Green;
    int[] optimalFishingHours = new int[2] { 5, 12 };
    bool firstNumPM = true;
    bool secondNumPM = true;

    public override RarityColor ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
    public override bool FirstNumPM { get { return firstNumPM; } }
    public override bool SecondNumPM { get { return secondNumPM; } }
}

/// <summary>
/// Location, 40% increase of gold
/// </summary>
class HolyShrimp : Location
{
    RarityColor colorBonus = RarityColor.Gold;
    int[] optimalFishingHours = new int[2] { 10, 4 };
    bool firstNumPM = true;
    bool secondNumPM = false;

    public override RarityColor ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
    public override bool FirstNumPM { get { return firstNumPM; } }
    public override bool SecondNumPM { get { return secondNumPM; } }
}
