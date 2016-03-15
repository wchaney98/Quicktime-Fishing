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

public enum FishingLocation : byte { FishVille, LargeBodyOfWater, BingoBango, HolyShrimp }

/// <summary>
/// Location, 30% increase of blue
/// </summary>
class FishVille : Location
{
    public FishVille(): base(Color.blue, new int[2] { 4, 12 }, new string[] { "Blue", "Bristlenose" }) { }
}

/// <summary>
/// Location, 30% increase of red
/// </summary>
class LargeBodyOfWater : Location
{
    public LargeBodyOfWater() : base(Color.red, new int[2] { 10, 18 }, new string[] { "Red", "Freshwater" }) { }
}

/// <summary>
/// Location, 30% increase of green
/// </summary>
class BingoBango : Location
{
    public BingoBango() : base(Color.green, new int[2] { 16, 0 }, new string[] { "Green", "Flabby" }) { }
}

/// <summary>
/// Location, 30% increase of gold
/// </summary>
class HolyShrimp : Location
{
    public HolyShrimp() : base(Color.yellow, new int[2] { 22, 4 }, new string[] { "Golden", "Bigeye" }) { }
}
