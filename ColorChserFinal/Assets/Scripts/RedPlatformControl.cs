using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlatformControl : PlatfromControl
{

    public float jumpForceReduceValue; 

    public override void OnCollisionStay2D(Collision2D other) { 
        if (other.collider.name == "Player" && other.collider.transform.position.y >= transform.position.y && !isColided){
            isColided = true;
            FindObjectOfType<PlayerControl>().setJumpForce(-jumpForceReduceValue);
        }
    }

    public override void OnCollisionExit2D(Collision2D other) {
        if (other.collider.name == "Player" && isColided){
            isColided = false;
            FindObjectOfType<PlayerControl>().setJumpForce(jumpForceReduceValue);
        }
    }
    public override void setInitColor(){
        Debug.Log("back to red");
        GetComponent<SpriteRenderer>().color = new Color(0.6886792f,0.08121216f,0.08709927f,1f);
    }
}
