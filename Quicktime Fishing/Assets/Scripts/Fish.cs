using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Fish
{
    List<KeyValuePair<char, Color>> fishData;

    StringBuilder prefix;
    StringBuilder title;

    string name;
    public string Name { get { return name; } }

    string markupName;
    public string MarkupName { get { return markupName; } }

    public Fish(List<KeyValuePair<char, Color>> fishData)
    {
        this.fishData = fishData;

        prefix = new StringBuilder();
        title = new StringBuilder();

        bool spaceAppeared = false;
        for(int i = 0; i < fishData.Count; i++)
        {
            if (fishData[i].Key == ' ')
            {
                spaceAppeared = true;
                continue;
            }
            if (spaceAppeared)
            {
                title.Append(fishData[i].Key);
            } else
            {
                prefix.Append(fishData[i].Key);
            }
        }
        name = prefix.ToString() + " " + title.ToString();
        markupName = GenerateString();
    }
	
    int GenerateWorth()
    {
        return 0;
    }

    string GenerateString()
    {
        StringBuilder markupName = new StringBuilder();

        for (int i = 0; i < fishData.Count; i++)
        {
            markupName.Append("<color=" + FishLoot.ColorToMarkup[fishData[i].Value] + ">" + fishData[i].Key + "</color>");
            //Debug.Log(i + ": " + fishData[i].Value);
        }

        return markupName.ToString();
    }
}
