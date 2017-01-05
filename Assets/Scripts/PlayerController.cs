using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;
    private float moveVelocity;
	public AudioClip steps;
	public AudioClip jump;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private Rigidbody2D myRigidBody;

    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;

	public bool canInteract;
	public bool hasInteracted;
	public bool canMove;

    private Animator anim;

	private string currentLevel;

	// Use this for initialization
	void Start () {
		currentLevel = SceneManager.GetActiveScene ().name;
		if(currentLevel != "Level1")
			canMove = true;
		hasInteracted = false;
		anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

	// Update is called once per frame
	void Update () {
		//repeatedly checks "PlaySound" for player sounds
		InvokeRepeating ("PlaySound", 0.0f, 0.5f);

		/* Movements */
        
		if (!canMove) {
			return;
		}

        // Up/jump commands - currently set to space, w or up
		if ((Input.GetKeyDown(KeyCode.Space) && grounded) | (Input.GetKeyDown(KeyCode.UpArrow) && grounded) | (Input.GetKeyDown(KeyCode.W) && grounded)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

        moveVelocity = 0f;
        
        // Move right - either with D or right arrow
        // GetKeyDown deals with it as one press while GetKey picks up continuous pressing of keys
		if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) {
            moveVelocity = moveSpeed;
        }

        // Move left - either with A or left arrow
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) {
            moveVelocity = -moveSpeed;
        }

		if (canInteract == true) {
			if(Input.GetKeyDown(KeyCode.E))
				hasInteracted = true;
		}

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if (onLadder) {
            myRigidBody.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, climbVelocity);
        }

        if (!onLadder) {
            myRigidBody.gravityScale = 5f;
        }

        /* Animations */

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("grounded", grounded);
        anim.SetBool("isClimbing", onLadder);

        // If not moving, you are stopped.
        if (((GetComponent<Rigidbody2D>().velocity.x) == 0) & ((GetComponent<Rigidbody2D>().velocity.y) == 0) & !onLadder) {
            anim.SetBool("stopped", true);
            anim.Play("Idle");
        }

        if((GetComponent<Rigidbody2D>().velocity.x) > 0) {
            transform.localScale = new Vector3(5f, 5f, 1f);
        }

        else if((GetComponent<Rigidbody2D>().velocity.x) < 0) {
            transform.localScale = new Vector3(-5f, 5f, 1f);
        }
    }

	/* Handles sounds during movements */
	void PlaySound (){
		AudioSource audio = GetComponent<AudioSource> ();

		if (((Input.GetKey (KeyCode.D)) | (Input.GetKey(KeyCode.RightArrow)) | (Input.GetKey (KeyCode.A)) | (Input.GetKey(KeyCode.LeftArrow))) & (!audio.isPlaying) & (GetComponent<Rigidbody2D>().velocity.x != 0)) {
			audio.clip = steps;
			audio.Play ();
		}

		if((Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow)) & grounded){
			audio.clip = jump;
			audio.Play ();
		}

		if (!Input.anyKey & grounded) {
			audio.Stop ();
		}
	}
}