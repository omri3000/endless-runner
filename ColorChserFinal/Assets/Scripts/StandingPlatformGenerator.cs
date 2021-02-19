using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlatformGenerator : MonoBehaviour
{
    public GameObject[] platformTypes;
    public Transform generatingPoint;
    public float distanceBetween;
    private float yInitPosition;

    public float platfromMinHorizontalDistance;
    public float platfromMaxHorizontalDistance;
    public float platformMaxVerticalDistance;
    public float platformMinVerticalDistance;
    public float platformMinLength;
    public float platformMaxLength;

    private float hightChange;
    private float maxHightChange;
    
    private float numOfBlocksCreated;
    
    void Start()
    {
        numOfBlocksCreated = 0;
        yInitPosition = transform.position.y;
    }

    void setHightChange(){
        hightChange = transform.position.y + Random.Range(platformMinVerticalDistance,platformMaxVerticalDistance);
        if (hightChange > platformMaxVerticalDistance || hightChange < platformMinVerticalDistance){
            hightChange = 0;
        }
    }

    float setPlatfromPositionAndLength(){
        distanceBetween = Random.Range(platfromMinHorizontalDistance,platfromMaxHorizontalDistance);
        transform.position = new Vector3(transform.position.x + distanceBetween,hightChange,transform.position.z);
        return Random.Range(platformMinLength,platformMaxLength);
    }

    void createPlatform(float length){
        GameObject typeofBlockToInstance = platformTypes[Random.Range(0,platformTypes.Length)];
        for(int i = 0; i < length; i++){
        Instantiate(typeofBlockToInstance,new Vector3(transform.position.x,transform.position.y + i,transform.position.z),transform.rotation);
        }
    }

    void Update()
    {
        if (transform.position.x < generatingPoint.position.x){
            
            setHightChange();
            //float platformLength = setPlatfromPositionAndLength()
            createPlatform(setPlatfromPositionAndLength());
            //transform.position = new Vector3(transform.position.x,yInitPosition,transform.position.z);
        }
    }

}
