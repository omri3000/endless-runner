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

    [Range(0.0f, 1.0f)]
    public float chanceForGreen;
    [Range(0.0f, 1.0f)]
    public float chanceForRed;
    [Range(0.0f, 1.0f)]
    public float chanceForBlack;

    private int[] chancesArr;
    private bool creatingBlacks;

    //private PlatfromControl createdPlatform;
    
    void Start()
    {
        creatingBlacks = false;
        yInitPosition = transform.position.y;
        chancesArr = new int[] {(int)(chanceForGreen*10.0f),(int)(chanceForRed*10.0f),(int)(chanceForBlack*10.0f)};
    }

    float setHightChange(){
        float hightChange = transform.position.y + Random.Range(platformMinVerticalDistance,platformMaxVerticalDistance);
        if (hightChange > platformMaxVerticalDistance || hightChange < platformMinVerticalDistance){
            hightChange = 0;
        }
        return hightChange;
    }

    float setPlatfromPositionAndLength(float hightChange){
        distanceBetween = Random.Range(platfromMinHorizontalDistance,platfromMaxHorizontalDistance);
        transform.position = new Vector3(transform.position.x + distanceBetween,hightChange,transform.position.z);
        return Random.Range(platformMinLength,platformMaxLength);
    }

    void createPlatform(float length){
        length = (int)length;
        int typeofBlockToInstance = GetRandomWeightedIndex(chancesArr);
        for(int i = 0; i < length; i++){
            GameObject createdPlatform = Instantiate(platformTypes[typeofBlockToInstance],new Vector3(transform.position.x + i,transform.position.y,transform.position.z),transform.rotation);
        }
    }

    public void onBlackPlatfromTouched(int secondsToApply){
        if (!creatingBlacks){
            creatingBlacks = true;
            StartCoroutine(createBlackPlatformForSeconds(secondsToApply));
        }
    }

    private IEnumerator createBlackPlatformForSeconds(int secondsToAplly){
        GameObject[] createdPlatform = GameObject.FindGameObjectsWithTag("ColordPlatfrom");
        for (int i = 0; i < createdPlatform.Length; ++i){
            if (createdPlatform[i] != null ){
                createdPlatform[i].GetComponent<SpriteRenderer>().color =  Color.black;
            }
        }
        yield return new WaitForSeconds(secondsToAplly);
        for (int i = 0; i < createdPlatform.Length; ++i){
            if (createdPlatform[i] != null){
                createdPlatform[i].GetComponent<PlatfromControl>().setInitColor();
            }
        }
        creatingBlacks = false;
    }

    private int GetRandomWeightedIndex(int[] weights)
{
    int weightSum = 0;
    for (int i = 0; i < weights.Length; ++i)
    {
        weightSum += weights[i];
    }
    int index = 0;
    int lastIndex = weights.Length - 1;
    while (index < lastIndex)
    {
        if (Random.Range(0, weightSum) < weights[index])
        {
            return index;
        }
         weightSum -= weights[index++];
    }
    return index;
}

    void Update()
    {
        if (transform.position.x < generatingPoint.position.x){
            createPlatform(setPlatfromPositionAndLength(setHightChange()));
        }
    }

}
