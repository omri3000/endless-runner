using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPlatformControl : PlatfromControl
{

    public float jumpForceReduceValue; 

    public override void OnCollisionStay2D(Collision2D other) { 
        if (other.collider.name == "Player" && other.collider.transform.position.y > transform.position.y && !isColided){
            isColided = true;
            FindObjectOfType<PlayerControl>().setJumpForce(jumpForceReduceValue);
        }
    }

    public override void OnCollisionExit2D(Collision2D other) {
        if (other.collider.name == "Player" && isColided){
            isColided = false;
            FindObjectOfType<PlayerControl>().setJumpForce(-jumpForceReduceValue);
        }
    }
    public override void setInitColor(){
        GetComponent<SpriteRenderer>().color = new Color(0.006739968f,0.5754717f,0f,1f);
    }
}
