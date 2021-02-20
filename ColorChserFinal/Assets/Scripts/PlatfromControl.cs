using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromControl : MonoBehaviour
{
    public bool isTopPlatfrom = false;
    public bool isColided = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public void SetTopPlatform(){
        Debug.Log("SET TOP");
        isTopPlatfrom = true;
    }

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
