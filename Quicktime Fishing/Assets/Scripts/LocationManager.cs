using UnityEngine;
using System.Collections;

/// <summary>
/// Class for fishing locations
/// </summary>
public class LocationManager
{
   
    public Color CurrentLocColorBonus { get { return currentLoc.ColorBonus; ; } }
    public int[] CurrentLocOptimalFishingHours { get { return currentLoc.OptimalFishingHours; } }

    public Location CurrentLoc { get { return currentLoc; } }
    public FishingLocation CurrentFishingLoc { get { return currentFishingLoc; } }

    Location currentLoc;
    FishingLocation currentFishingLoc;

    public void Initialize(FishingLocation loc)
    {
        currentFishingLoc = loc;
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

//public enum RarityColor : byte { Blue, Red, Green, Gold }

public enum FishingLocation : byte { FishVille, LargeBodyOfWater, BingoBango, HolyShrimp }

/// <summary>
/// Location, 30% increase of blue
/// </summary>
class FishVille : Location
{
    Color colorBonus = Color.blue;
    int[] optimalFishingHours = new int[2] { 4, 12 };

    public override Color ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
}

/// <summary>
/// Location, 30% increase of red
/// </summary>
class LargeBodyOfWater : Location
{
    Color colorBonus = Color.red;
    int[] optimalFishingHours = new int[2] { 10, 18 }; 

    public override Color ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
}

/// <summary>
/// Location, 30% increase of green
/// </summary>
class BingoBango : Location
{
    Color colorBonus = Color.green;
    int[] optimalFishingHours = new int[2] { 16, 0 };

    public override Color ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
}

/// <summary>
/// Location, 30% increase of gold
/// </summary>
class HolyShrimp : Location
{
    Color colorBonus = Color.yellow;
    int[] optimalFishingHours = new int[2] { 22, 4 };

    public override Color ColorBonus { get { return colorBonus; } }
    public override int[] OptimalFishingHours { get { return optimalFishingHours; } }
}
