using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Fish
{
    private List<KeyValuePair<char, Color>> fishData;
    public List<KeyValuePair<char, Color>> FishData { get { return fishData; } }

    private bool combined;
    public bool Combined { get; set; }

    private StringBuilder prefix;
    public string Prefix { get { return prefix.ToString(); } }

    private StringBuilder title;
    public string Title { get { return title.ToString(); } }

    private string name;
    public string Name { get { return name; } }

    private string markupName;
    public string MarkupName { get { return markupName; } }

    private FishingLocation fishType;
    public FishingLocation FishType { get { return fishType; } }

    public Fish(List<KeyValuePair<char, Color>> fishData, LocationManager lm, bool combo)
    {
        this.fishData = fishData;

        prefix = new StringBuilder();
        title = new StringBuilder();

        bool spaceAppeared = false;
        bool comboSpaceAppeared = !combo;
        for(int i = 0; i < fishData.Count; i++)
        {
            if (fishData[i].Key == ' ')
            {
                if (!comboSpaceAppeared)
                {
                    prefix.Append(" ");
                    comboSpaceAppeared = true;
                    continue;
                }
                spaceAppeared = true;
            }
            if (fishData[i].Key == ' ' && spaceAppeared == true && comboSpaceAppeared)
            {
                comboSpaceAppeared = false;
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
        name = prefix + " " + title;
        markupName = GenerateString();
        fishType = lm.CurrentFishingLoc;
        combined = false;
    }

    private int GenerateWorth()
    {
        return 0;
    }

    private string GenerateString()
    {
        StringBuilder markupName = new StringBuilder();

        for (int i = 0; i < fishData.Count; i++)
        {
            markupName.Append("<color=" + FishLoot.ColorToMarkup[fishData[i].Value] + ">" + fishData[i].Key + "</color>");
        }

        return markupName.ToString();
    }
}