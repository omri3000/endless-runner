using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generatingPoint;
    public float distanceBetween;
    public float platformWidth;

    public float distanceBetweenMax;
    public float distanceBetweenMin;

    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < generatingPoint.position.x){
            distanceBetween = Random.Range(distanceBetweenMin,distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween,transform.position.y,transform.position.z);
            Instantiate(platform,transform.position,Quaternion.Euler(0, 0, 90));
        }
    }

}
