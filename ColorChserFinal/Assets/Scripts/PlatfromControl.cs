using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromControl : MonoBehaviour
{
    public bool isColided = false;


    public virtual void OnCollisionStay2D(Collision2D other) {
        Debug.Log(other.collider.name);
    }

    public virtual void OnCollisionExit2D(Collision2D other) {
        Debug.Log(other.collider.name);
    }

    public virtual void setInitColor() {
        Debug.Log("setInitColor");
    }
    
    
}
