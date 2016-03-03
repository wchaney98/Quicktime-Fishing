using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Fish
{
    // dictionaries dont work with duplicate keys
    
    Dictionary<char, Color> fishData = new Dictionary<char, Color>();

    StringBuilder prefix;
    StringBuilder title;

    string name;
    public string Name { get { return name; } }

    public Fish(Dictionary<char, Color> fishData)
    {
        this.fishData = fishData;

        bool spaceAppeared = false;
        foreach(char letter in fishData.Keys)
        {
            if (letter == ' ')
            {
                spaceAppeared = true;
            }
            if (spaceAppeared)
            {
                title.Append(letter);
            } else
            {
                prefix.Append(letter);
            }
        }
        name = prefix + " " + title;
    }
	
    public int GenerateWorth()
    {
        return 0;
    }

    public string GenerateString(bool markup)
    {
        return "";
    }
}
