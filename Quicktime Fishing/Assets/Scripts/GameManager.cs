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
        Fish fish = FishLoot.GetNewFish(LM, clock);

        Debug.Log(fish.Name + " " + fish.MarkupName);
    }
	
	void Update ()
    {

    }
}
