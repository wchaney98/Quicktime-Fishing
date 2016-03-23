using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject quickTimePrefab;

    QuickTimeManager QTM;
    Clock clock;
    LocationManager LM;

	void Start ()
    {
        QTM = new QuickTimeManager();
        clock = GetComponent<Clock>();
        LM = new LocationManager();

        LM.Initialize(FishingLocation.BingoBango);

        LM.Initialize(FishingLocation.LargeBodyOfWater);
        Fish fish0 = FishLoot.GetNewFish(LM, clock);
        Debug.Log("Fish 0: " + fish0.Name + " : " + fish0.MarkupName);

	    Fish fish1 = FishLoot.GetNewFish(LM, clock);
        Debug.Log("Fish 1: " + fish1.Name + " : " + fish1.MarkupName);

	    Fish fish2 = FishLoot.CombineFish(fish0, fish1, LM, clock);
        Debug.Log("Combined: " + fish2.Name + " : " + fish2.MarkupName);
        Debug.Log("Prefix: " + fish2.Prefix + " Title: " + fish2.Title);
    }
	
	void Update ()
    {

    }
}
