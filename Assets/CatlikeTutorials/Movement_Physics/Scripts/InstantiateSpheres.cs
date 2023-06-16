using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpheres : MonoBehaviour
{
    [SerializeField]
    GameObject spherePrefab;

    [SerializeField]
    int sphereCount = 20;

    void Awake()
    {
        for(int i = 1; i <= sphereCount; i++) {
            GameObject sphere = Instantiate(spherePrefab, transform);
            sphere.transform.localPosition = new Vector3(30f, 0f, -28.5f + i * 3f);
        }
    }

    void Update()
    {
        
    }
}
