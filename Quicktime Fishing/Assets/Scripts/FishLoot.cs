using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Static class that generates properties of caught fish
/// </summary>
public class FishLoot
{
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
    public static Dictionary<char, Color> GenerateNameData(LocationManager LM, Clock clock)
    {
        StringBuilder name = new StringBuilder();
        int roll = Random.Range(0, LM.CurrentLoc.Prefixes.Length);

        string prefix = LM.CurrentLoc.Prefixes[roll];
        name.Append(prefix);
        name.Append(" ");
        name.Append(FishNames[Random.Range(0, FishNames.Length)]);

        Dictionary<char, Color> nameData = new Dictionary<char, Color>();
        foreach (char letter in name.ToString())
        {
            nameData.Add(letter, rollColor(letter, LM, clock));
        }

        return nameData;
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
        float bonusColorChance = chance += bonusLocationColorAmount;
           
        // Roll and return a color
        if (roll <= bonusColorChance)
        {
            return bonusColor;
        } else if (roll <= chance)
        {
            int colorRoll = Random.Range(0, 4);
            return colors[colorRoll];
        } else
        {
            return Color.grey;
        }       
    }

    // function to generate worth of fish based on number of different colors and how many colored characters


    // function to convert the fish to markup text


    // fish class to store markup info and backend info
}
