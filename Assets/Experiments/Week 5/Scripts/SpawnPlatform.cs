using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab;

    [SerializeField, Range(2, 100)]
    int platformCount;

    [SerializeField, Range(0.1f, 10f)]
    float rangeX;

    [SerializeField, Range(0.1f, 15f)]
    float stepSize;

    float currY = 0f;

    void Awake()
    {
        for(int i = 0; i < platformCount; i++) {
            float posX = Random.Range(-rangeX, rangeX);
            float posY = currY + stepSize;
            Instantiate(platformPrefab, new Vector3(posX, posY, 0f), Quaternion.identity);
            currY = posY;
        }
    }

    void Update()
    {
        
    }
}
