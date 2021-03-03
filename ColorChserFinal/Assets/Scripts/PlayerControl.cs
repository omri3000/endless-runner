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
    private SoundManager soundManager;

    public float moveSpeed;
    public float speedIncreamentFactor;
    public float jumpForce;
    public float maxJumpForce;
    public LayerMask whatIsGround; 

    private bool _isGrounded;
    private bool _isJumping;
    private float _defMaxJump;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        scoreManager = FindObjectOfType<ScoreManager>();
        soundManager = FindObjectOfType<SoundManager>();

        speedIncreaseCoroutine = StartCoroutine(IncreaseSpeed());
        _defMaxJump = maxJumpForce;
        soundManager.playBGSound();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        myRigidBody.velocity = new Vector2((moveSpeed + speedIncreamentFactor*Time.deltaTime),myRigidBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && _isGrounded){
            soundManager.playJumpSound();
            _isJumping = true;
            myRigidBody.velocity = new Vector2(moveSpeed, jumpForce);
        }

        if(Input.GetKey(KeyCode.Space) && _isJumping){
            if(jumpForce < maxJumpForce){
                jumpForce += 0.2f;
                myRigidBody.velocity = new Vector2(moveSpeed, jumpForce);
            }else{
                _isJumping = false;
                jumpForce = 12.0f;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) && _isJumping){
           jumpForce = 12.0f; 
           _isJumping = false;
        }

        myAnimator.SetFloat("Speed",myRigidBody.velocity.x);
        myAnimator.SetBool("Grounded",_isGrounded);
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.name == "BottomBoundary"){
            scoreManager.scoreIncreasing = false;
            StopCoroutine(speedIncreaseCoroutine);
            Destroy(gameObject);
        }
    }

    public void setJumpForce(float force){
        maxJumpForce = force;
    }

    public void setDefJumpForce(){
        maxJumpForce = _defMaxJump;
    }

    private IEnumerator IncreaseSpeed(){
        while(true){
            moveSpeed += speedIncreamentFactor;
            yield return new WaitForSeconds(1);
        }
    }
}
