using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CountdownAnim : MonoBehaviour
{

    Animator animPlayer;

    float threeTime;
    float twoTime;
    float oneTime;

    float timeElapsedSinceSpriteChanged;

    byte currentNum;

    Dictionary<byte, float> timeLinkDict = new Dictionary<byte, float>();

    void Start()
    {
        animPlayer = GetComponent<Animator>();

        threeTime = 0f;
        twoTime = 0.5f;
        oneTime = 0.9f;

        currentNum = 3;

        timeLinkDict.Add(3, threeTime);
        timeLinkDict.Add(2, twoTime);
        timeLinkDict.Add(1, oneTime);
    }

    void Update()
    {
        timeElapsedSinceSpriteChanged += Time.deltaTime;

        if (timeElapsedSinceSpriteChanged >= 1f)
        {
            countDown();
            timeElapsedSinceSpriteChanged = 0;
        }
    }

    void countDown()
    {
        currentNum -= 1;
        if (currentNum <= 0)
        {
            Destroy(transform.parent.gameObject);
            return;
        }
        animPlayer.Play("321CountDown", 0, timeLinkDict[currentNum]);
    }
}
