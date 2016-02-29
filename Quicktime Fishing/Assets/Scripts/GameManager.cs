using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject quickTimePrefab;

    QuickTimeManager QTM;
    Clock clock;
    LocationManager location;


	void Start ()
    {
        QTM = new QuickTimeManager();
        clock = GetComponent<Clock>();
        location = new LocationManager();

        location.Initialize(FishingLocation.FishVille);
        Debug.Log(location.CurrentLocColorBonus + ", " + location.CurrentLocOptimalFishingHours[0] + " " + location.CurrentLocOptimalFishingHours[1]);
	}
	
	void Update ()
    {

	}
}
