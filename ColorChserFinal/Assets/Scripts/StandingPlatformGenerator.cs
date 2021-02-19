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

    [Range(0.0f, 1.0f)]
    public float chanceForGreen;
    [Range(0.0f, 1.0f)]
    public float chanceForRed;
    [Range(0.0f, 1.0f)]
    public float chanceForBlack;

    private int[] chancesArr;
    
    void Start()
    {
        numOfBlocksCreated = 0;
        yInitPosition = transform.position.y;
        chancesArr = new int[] {(int)(chanceForGreen*10.0f),(int)(chanceForRed*10.0f),(int)(chanceForBlack*10.0f)};
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
        int typeofBlockToInstance = GetRandomWeightedIndex(chancesArr);
        //platformTypes[Random.Range(0,platformTypes.Length)];
        for(int i = 0; i < length; i++){
        Instantiate(platformTypes[typeofBlockToInstance],new Vector3(transform.position.x,transform.position.y + i,transform.position.z),transform.rotation);
        }
    }

    public int GetRandomWeightedIndex(int[] weights)
{
    // Get the total sum of all the weights.
    int weightSum = 0;
    for (int i = 0; i < weights.Length; ++i)
    {
        weightSum += weights[i];
    }
 
    // Step through all the possibilities, one by one, checking to see if each one is selected.
    int index = 0;
    int lastIndex = weights.Length - 1;
    while (index < lastIndex)
    {
        // Do a probability check with a likelihood of weights[index] / weightSum.
        if (Random.Range(0, weightSum) < weights[index])
        {
            return index;
        }
 
        // Remove the last item from the sum of total untested weights and try again.
        weightSum -= weights[index++];
    }
 
    // No other item was selected, so return very last index.
    return index;
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
