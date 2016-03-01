using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{
    int dayCount;
    int hour;
    int minute;

    public int DayCount { get { return dayCount; } }
    public int Hour { get { return hour; } }
    public int Minute { get { return minute; } }

    float timeSinceLastMinuteIncrement;
    const float secondsPerGameMinute = 0.01f;

	void Start ()
    {
        hour = 23;
        minute = 0;
        timeSinceLastMinuteIncrement = 0;
	}
	
	void Update ()
    {
        timeSinceLastMinuteIncrement += Time.deltaTime;
        int tempMinute = minute;
        int tempHour = hour;

        if (timeSinceLastMinuteIncrement >= secondsPerGameMinute)
        {
            tempMinute += 1;
            timeSinceLastMinuteIncrement = 0;
        }
        if (tempMinute > 59)
        {
            tempMinute = 0;
            tempHour += 1;
        }
        if (tempHour > 23)
        {
            tempHour = 0;
            dayCount += 1;
        }

        minute = tempMinute;
        hour = tempHour;
	}

    /// <summary>
    /// Get the time in a H:MM display
    /// </summary>
    /// <returns>The time in a H:MM display</returns>
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

        return hour + ":" + displayMinute;
    }
}
