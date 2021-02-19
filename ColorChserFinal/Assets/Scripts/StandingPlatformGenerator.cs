using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlatformGenerator : MonoBehaviour
{
    ///public GameObject greenPlatform;
    //public GameObject redPlatform;
    //public GameObject blackPlatform;
    public Transform generatingPoint;
    public float distanceBetween;

    public float distanceBetweenMax;
    public float distanceBetweenMin;

    public float minHeight;
    public float maxHeight;
    public float maxHeightChange;
    public float minHeightChange;
    private float hightChange;
    public float platformMinLength;
    public float platformMaxLength;
    private float numOfBlocksCreated;
    public GameObject[] platformTypes;

    void Start()
    {
        minHeight = transform.position.y;
        hightChange = minHeight + Random.Range(0,maxHeightChange);
        numOfBlocksCreated = 0;
    }

    void Update()
    {
        if (transform.position.x < generatingPoint.position.x){
            distanceBetween = Random.Range(distanceBetweenMin,distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + distanceBetween,hightChange,transform.position.z);
            float platformLength = Random.Range(platformMinLength,platformMaxLength);
            GameObject typeofBlockToInstance = platformTypes[Random.Range(0,platformTypes.Length)];
            for(int i = 0; i < platformLength; i++)
        {
            Instantiate(typeofBlockToInstance,new Vector3(transform.position.x,transform.position.y + i,transform.position.z),transform.rotation);
        }
        }
    }

}
