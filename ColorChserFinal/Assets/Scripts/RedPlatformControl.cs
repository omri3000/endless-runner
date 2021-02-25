using UnityEngine;

public class RedPlatformControl : PlatfromControl
{

    public float jumpForceDecreaseValue; 

    public override void OnCollisionStay2D(Collision2D other) { 
        if (other.collider.name == "Player" && other.collider.transform.position.y >= transform.position.y){
            isColided = true;
            FindObjectOfType<PlayerControl>().setJumpForce(jumpForceDecreaseValue);
        }
    }

    public override void setInitColor(){
        GetComponent<SpriteRenderer>().color = new Color(0.6886792f,0.08121216f,0.08709927f,1f);
    }
}
