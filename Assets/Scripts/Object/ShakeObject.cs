using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos;
        if (transform.name == "Sprite")
        {
            originalPos = transform.localPosition;
            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
                elapsed += Time.deltaTime;
                if (Time.deltaTime == 0) elapsed = duration;
                yield return null;
            }
            transform.localPosition = originalPos;

        }
        else
        { 
        originalPos = transform.position;

        float elapsed = 0.0f;
            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;
                transform.position = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
                elapsed += Time.deltaTime;
                if (Time.deltaTime == 0) elapsed = duration;
                yield return null;
            }
          
        transform.position = originalPos;
        }
    }
}
