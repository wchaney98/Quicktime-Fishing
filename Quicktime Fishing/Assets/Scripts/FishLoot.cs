using UnityEngine;
using System.Collections;
using System.Text;

public class FishLoot
{
    static string[] FishNames = new string[] { "Shiner", "Trout", "Shad", "Guppy" };

    Color[] colors = new Color[] { Color.blue, Color.red, Color.green, Color.yellow };

    float baseColorChance = 0.1f;
    float bonusLocationColorAmount = 0.2f;
    float bonusOptimalFishingHourAmount = 0.2f;

    // catch fish, generates name, roll color on each letter

    public static string GenerateName(LocationManager LM)
    {
        StringBuilder name = new StringBuilder();
        int roll = Random.Range(0, LM.CurrentLoc.Prefixes.Length);

        string prefix = LM.CurrentLoc.Prefixes[roll];
        name.Append(prefix);
        name.Append(" ");
        name.Append(FishNames[Random.Range(0, FishNames.Length)]);

        return name.ToString();
    }

    // include clock and location specific bonuses
    Color rollColor(char letter, LocationManager LM, Clock clock)
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
