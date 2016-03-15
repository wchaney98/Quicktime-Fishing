using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

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

    static string[] FishNames = new string[] { "Shiner", "Trout", "Shad", "Guppy" };
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
        name.Append(FishNames[Random.Range(0, FishNames.Length)]);

        List<KeyValuePair<char, Color>> nameData = new List<KeyValuePair<char, Color>>();
        foreach (char letter in name.ToString())
        {
            nameData.Add(new KeyValuePair<char, Color>(letter, rollColor(letter, LM, clock)));
        }

        return nameData;
    }

    /// <summary>
    /// Takes two fish and breeds them
    /// </summary>
    /// <param name="fish1">First fish</param>
    /// <param name="fish2">Fish to combine with first fish</param>
    /// <returns></returns>
    public static Fish CombineFish(Fish fish1, Fish fish2)
    {
        List<KeyValuePair<char, Color>> newData = new List<KeyValuePair<char, Color>>();

        foreach (KeyValuePair<char, Color> pairOf1 in fish1.FishData)
        {
            foreach(KeyValuePair<char, Color> pairOf2 in fish2.FishData)
            {
                if (pairOf1.Value == pairOf2.Value)
                {
                    newData.Add()
                }
            }
        }
    }

    /// <summary>
    /// Rolls the color of a letter of a fish's name. Takes into account time of day and the location
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="LM"></param>
    /// <param name="clock"></param>
    /// <returns>The color that letter should be</returns>
    static Color rollColor(char letter, LocationManager LM, Clock clock)
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

    public static Fish GetNewFish(LocationManager LM, Clock clock)
    {
        return new Fish(GenerateNameData(LM, clock));
    }
}
