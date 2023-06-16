using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // camera would update the y position when the character goes out of the bound
    [SerializeField]
    GameObject character;

    [SerializeField, Range(0.1f, 15f)]
    float yBound;

    float currY = 10f;
    float lerpDuration = 0.2f;

    void Start()
    {
        transform.localPosition = new Vector3(0f, currY, -25f);
    }

    void Update()
    {
        if( (character.transform.localPosition.y + yBound) > currY)
        {
            currY = character.transform.localPosition.y + 5f;
            transform.localPosition = new Vector3(0f, currY, -25f);
        }

        // TODO need to refine
        // if( (character.transform.localPosition.y + yBound) > currY && !character.GetComponent<CharacterJump>().inAir)
        // {
        //     StartCoroutine(TransformCamera());
        // }
    }

    IEnumerator TransformCamera()
    {
        float timeElapsed = 0;
        float startY = character.transform.localPosition.y;
        float endY = startY + 5f;
        float lerpedY = 0;
        while(timeElapsed < lerpDuration)
        {
            lerpedY = Mathf.Lerp(startY, endY, timeElapsed);
            timeElapsed += Time.deltaTime;
            transform.localPosition = new Vector3(0f, lerpedY, -25f);
            yield return null;
        }
    }
}
