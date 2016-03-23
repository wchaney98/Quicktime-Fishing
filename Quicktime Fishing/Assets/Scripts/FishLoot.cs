using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Static class that generates properties of caught fish
/// </summary>
public static class FishLoot
{
    public static Dictionary<Color, string> ColorToMarkup = new Dictionary<Color, string>
    {
        { Color.blue, "blue" },
        { Color.red, "red" },
        { Color.green, "lime" },
        { Color.yellow, "yellow" },
        { Color.grey, "silver" }
    };


    static string[] combinationFishPrefixes = new string[] { "Cool", "Epic", "Legendary", "Dud", "Special" };
    static string[] fishNames = new string[] { "Shiner", "Trout", "Shad", "Guppy" };
    static Color[] colors = new Color[] { Color.blue, Color.red, Color.green, Color.yellow };

    static float baseColorChance = 0.1f;
    static float bonusLocationColorAmount = 0.2f;
    static float bonusOptimalFishingHourAmount = 0.2f;

    /// <summary>
    /// Creates a fish data Dictionary that is used to create an actual Fish object
    /// </summary>
    /// <param name="LM"></param>
    /// <param name="clock"></param>
    /// <returns>Data to create fish object</returns>
    public static List<KeyValuePair<char, Color>> GenerateNameData(LocationManager LM, Clock clock)
    {
        StringBuilder name = new StringBuilder();
        int roll = Random.Range(0, LM.CurrentLoc.Prefixes.Length);

        string prefix = LM.CurrentLoc.Prefixes[roll];
        name.Append(prefix);
        name.Append(" ");
        name.Append(fishNames[Random.Range(0, fishNames.Length)]);

        List<KeyValuePair<char, Color>> nameData = new List<KeyValuePair<char, Color>>();
        foreach (char letter in name.ToString())
        {
            nameData.Add(letter == ' '
                ? new KeyValuePair<char, Color>(letter, Color.gray)
                : new KeyValuePair<char, Color>(letter, rollColor(letter, LM, clock)));
        }

        return nameData;
    }

    public static List<KeyValuePair<char, Color>> GeneratePrefixData()
    {
        return null;
    }

    /// <summary>
    /// Takes two fish and breeds them
    /// </summary>
    /// <param name="fish1">First fish</param>
    /// <param name="fish2">Fish to combine with first fish</param>
    /// <param name="lm">Location Manager</param>
    /// <param name="clock">Game clock</param>
    /// <returns></returns>
    public static Fish CombineFish(Fish fish1, Fish fish2, LocationManager lm, Clock clock)
    {
        fish1.Combined = true;
        fish2.Combined = true;
        var newFishData = new List<KeyValuePair<char, Color>>();    

        // Get a new prefix for the combined fish.. takes first fish's prefix and the second fish's title
        var roll = Random.Range(0, combinationFishPrefixes.Length);
        var prefix = combinationFishPrefixes[roll];    

        // Roll and add new prefix
        foreach (var letter in prefix)
        {
            newFishData.Add(letter == ' '
                ? new KeyValuePair<char, Color>(letter, Color.gray)
                : new KeyValuePair<char, Color>(letter, rollColor(letter, lm, clock)));
        }

        // Add space
        newFishData.Add(new KeyValuePair<char, Color>(' ', Color.gray));

        // Add first fish's prefix data
        foreach (KeyValuePair<char, Color> pair in fish1.FishData)
        {
            if (pair.Key != ' ')
            {
                newFishData.Add(pair);
            }
            else
            {
                newFishData.Add(new KeyValuePair<char, Color>(pair.Key, Color.gray));
                break;
            }
        }

        // Add second fish's title
        for (var i = fish2.Prefix.Length + 1; i < fish2.FishData.Count; i++)
        {
            newFishData.Add(fish2.FishData[i]);      
        }

        // Return new fish
        return new Fish(newFishData, lm, true);

    }

    /// <summary>
    /// Rolls the color of a letter of a fish's name. Takes into account time of day and the location
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="LM"></param>
    /// <param name="clock"></param>
    /// <returns>The color that letter should be</returns>
    private static Color rollColor(char letter, LocationManager LM, Clock clock)
    {
        float roll = Random.Range(0f, 1f);
        float chance = baseColorChance;

        // Check if bonus time and apply bonus to base chance
        if (clock.Hour >= LM.CurrentLoc.OptimalFishingHours[0] && clock.Hour <= LM.CurrentLoc.OptimalFishingHours[1])
        {
            chance += bonusOptimalFishingHourAmount;
        }

        // Add bonus chance to location's bonus color
        Color bonusColor = LM.CurrentLoc.ColorBonus;
        float bonusColorChance = chance + bonusLocationColorAmount;

        // Roll and return a color
        if (roll <= chance)
        {
            int colorRoll = Random.Range(0, 4);
            return colors[colorRoll];
        } else if (roll <= bonusColorChance)
        {
            return bonusColor;
        } else
        {
            return Color.grey;
        }       
    }

    public static Fish GetNewFish(LocationManager lm, Clock clock)
    {
        return new Fish(GenerateNameData(lm, clock), lm, false);
    }
}
