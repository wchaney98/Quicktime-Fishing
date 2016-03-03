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
        //Debug.Log(location.CurrentLocColorBonus + ", " + location.CurrentLocOptimalFishingHours[0] + " " + location.CurrentLocOptimalFishingHours[1]);
        //Debug.Log(FishLoot.GenerateName(LM));

        LM.Initialize(FishingLocation.HolyShrimp);
        //Debug.Log(FishLoot.GenerateName(LM));
        Debug.Log(FishLoot.GenerateNameData(LM, clock));
    }
	
	void Update ()
    {

    }
}
