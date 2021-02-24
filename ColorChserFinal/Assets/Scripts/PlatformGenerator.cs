using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    // public GameObject platform;
    public GameObject[] platforms;
    public Transform generatingPoint;
    public float distanceBetween;
    public float platformWidth;

    public float distanceBetweenMax;
    public float distanceBetweenMin;
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platforms[0].GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generatingPoint.position.x){
            distanceBetween = Random.Range(distanceBetweenMin,distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, distanceBetween,transform.position.z);

            var RandomPlatform = Random.Range(0, platforms.Length);

           Instantiate(platforms[RandomPlatform],transform.position,transform.rotation);
        }
    }
}
