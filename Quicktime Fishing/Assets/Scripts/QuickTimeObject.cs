using UnityEngine;
using System.Collections;

public class QuickTimeObject : MonoBehaviour
{
    float timeElapsedSinceSpriteInstanced;
    float duration;

    void Start()
    {
        timeElapsedSinceSpriteInstanced = 0f;
        duration = 3f;

        StartCoroutine(shrinkSprite());
    }

    IEnumerator shrinkSprite()
    {
        float t = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 finalScale = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2, transform.localScale.z);
        while (t <= 1f)
        {
            timeElapsedSinceSpriteInstanced += Time.deltaTime;
            t = timeElapsedSinceSpriteInstanced / duration;
            transform.localScale = Vector3.Lerp(startScale, finalScale, t);
            yield return null;
        }
    }

    void OnMouseDown()
    {
        // Todo: generate next quicktime event? make sequence for catching a fish?
        Debug.Log("was pressed");
        Destroy(transform.parent.gameObject);
    }
}
