using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    int dayCount;
    int hour;
    int minute;
    bool _PM;

    public int DayCount { get { return dayCount; } }
    public int Hour { get { return hour; } }
    public int Minute { get { return minute; } }
    public bool PM { get { return _PM; } }

    float timeSinceLastMinuteIncrement;
    const float secondsPerMinute = 1f;

	void Start ()
    {
        hour = 0;
        minute = 0;
        timeSinceLastMinuteIncrement = 0;
        _PM = false;
	}
	
	void Update ()
    {
        Debug.Log("update");
        timeSinceLastMinuteIncrement += Time.deltaTime;
        int tempMinute = minute;
        int tempHour = hour;

        if (timeSinceLastMinuteIncrement >= secondsPerMinute)
        {
            tempMinute += 1;
            timeSinceLastMinuteIncrement = 0;
        }
        if (tempMinute > 59)
        {
            tempMinute = 0;
            tempHour += 1;
        }
        if (tempHour > 11)
        {
            _PM = !_PM;
            tempHour = 0;
        }
        //fix am pm and day count

        minute = tempMinute;
        hour = tempHour;
	}

    public string GetFullTime()
    {
        string displayMinute;

        if (minute < 10)
        {
            displayMinute = "0" + minute;
        } else
        {
            displayMinute = minute.ToString();
        }

        if (_PM)
        {
            return hour + ":" + displayMinute + " PM";
        }
        return hour + ":" + displayMinute + " AM";
    }
}
