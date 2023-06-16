using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DropSphere());
    }

    void Update()
    {
        
    }

    IEnumerator DropSphere () {
        while(ObjectPool.SharedInstance.GetPoolInitialized()) {
            GameObject sphere = ObjectPool.SharedInstance.GetPooledObject();
            if(sphere != null) {
                sphere.transform.position = new Vector3 (
                    Random.Range(-12f, 12f),
                    Random.Range(6f, 30f),
                    Random.Range(-12f, 12f)
                );
                sphere.SetActive(true);
            }
            yield return new WaitForSeconds(.2f);
        }
    }
}
