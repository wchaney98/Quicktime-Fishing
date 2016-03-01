using UnityEngine;
using System.Collections;
using System.Text;

public class FishLoot
{
    // do prefixes work?
    static string[] FishVillePrefixes = new string[] { "Blue", "Bristlenose" };
    static string[] LargeBodyOfWaterPrefixes = new string[] { "Red", "Freshwater" };
    static string[] BingoBangoPrefixes = new string[] { "Green", "Flabby" };
    static string[] HolyShrimpPrefixes = new string[] { "Golden", "Bigeye" };

    static string[] FishNames = new string[] { "Shiner", "Trout", "Shad", "Guppy" };

    float bonusAmount = 0.3f;

    // catch fish, generates name, roll color on each letter

	public static string GenerateName(LocationManager LM)
    {
        StringBuilder name = new StringBuilder();
        
        //change to polymorphism
        switch (LM.CurrentFishingLoc)
        {
            case FishingLocation.FishVille:
                name.Append(FishVillePrefixes[Random.Range(0, FishVillePrefixes.Length)]);
                break;

            case FishingLocation.LargeBodyOfWater:
                name.Append(LargeBodyOfWaterPrefixes[Random.Range(0, LargeBodyOfWaterPrefixes.Length)]);
                break;

            case FishingLocation.BingoBango:
                name.Append(BingoBangoPrefixes[Random.Range(0, BingoBangoPrefixes.Length)]);
                break;

            case FishingLocation.HolyShrimp:
                name.Append(HolyShrimpPrefixes[Random.Range(0, HolyShrimpPrefixes.Length)]);
                break;
        }

        name.Append(" ");
        name.Append(FishNames[Random.Range(0, FishNames.Length)]);

        return name.ToString();
    }

    // include clock and location specific bonuses
    Color rollColor(char letter, LocationManager LM)
    {
        float roll = Random.Range(0f, 1f);

        if (roll <= LM.CurrentLoc.BaseColorChance)
        {
            return Color.black;
        }
        return Color.black;
    }
}
