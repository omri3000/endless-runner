using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPlatformControl : PlatfromControl
{

    public int timeForBlackEffect;
    public StandingPlatformGenerator standingPlatformGenerator;

    // Start is called before the first frame update
    void Start()
    {
        standingPlatformGenerator = FindObjectOfType<StandingPlatformGenerator>();
    }

    public override void OnCollisionStay2D(Collision2D other) {
        if (other.collider.name == "Player"){
            standingPlatformGenerator.onBlackPlatfromTouched(timeForBlackEffect);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
