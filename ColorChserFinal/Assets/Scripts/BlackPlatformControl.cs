using UnityEngine;

public class BlackPlatformControl : PlatfromControl
{

    public int timeForBlackEffect;
    public PlatformGenerator platformGenerator;
    

    // Start is called before the first frame update
    void Start()
    {
        platformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    public override void OnCollisionStay2D(Collision2D other) {
        if (other.collider.name == "Player"){
            platformGenerator.onBlackPlatfromTouched(timeForBlackEffect);
            FindObjectOfType<PlayerControl>().setDefJumpForce();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
