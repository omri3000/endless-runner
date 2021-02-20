using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Collider2D myCollider;
    private Animator myAnimator;
    private ScoreManager scoreManager;
    private Coroutine speedIncreaseCoroutine;

    public float moveSpeed;
    public float speedIncreamentFactor;
    public float jumpForce;
    public float jumpTime;
    public LayerMask whatIsGround; 

    private bool _isGrounded;
    private bool _isJumping;
    private float _jumpTimeCounter;
    


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();

        speedIncreaseCoroutine = StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidBody.velocity = new Vector2((moveSpeed + speedIncreamentFactor*Time.deltaTime),myRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded){

            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            myRigidBody.velocity = new Vector2(moveSpeed, jumpForce);
        }

        if(Input.GetKey(KeyCode.Space) && _isJumping){
            if(_jumpTimeCounter>0){
                myRigidBody.velocity = new Vector2(moveSpeed, jumpForce);
                _jumpTimeCounter -= Time.deltaTime; 
            }else{
                _isJumping = false;
            }
        }

        myAnimator.SetFloat("Speed",myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded",_isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name == "BottomBoundary"){
            scoreManager.scoreIncreasing = false;
            StopCoroutine(speedIncreaseCoroutine);
            Destroy(gameObject);
        }
    }

    public void setJumpForce(float force){
        jumpForce += force;
    }

    private IEnumerator IncreaseSpeed(){
        while(true){
            moveSpeed += speedIncreamentFactor;
            yield return new WaitForSeconds(1);
        }
    }
}
