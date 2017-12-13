using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    //Collider2D[] result = new Collider2D[2];
    

    public LayerMask layerMask;
    public float hitDistance = 0.1f;
    public float movespeed;
    public float jumpForece;
    public Transform groundCheck;
    public float radius = 0.2f;

   
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D> ();
        spriteRenderer = GetComponent<SpriteRenderer> ();
        animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
        float hor = Input.GetAxisRaw ("Horizontal");

        Vector2 input = new Vector2 (hor * movespeed, 0);

        transform.Translate (input * Time.deltaTime);
        if (input.x < 0) {
            spriteRenderer.flipX = true;
            animator.SetInteger ("speed", -1);
        } else if(input.x>0) {
            spriteRenderer.flipX = false;
            animator.SetInteger ("speed", 1);
        } else {
            animator.SetInteger ("speed", 0);
        }

        if (Input.GetKeyDown (KeyCode.Z) && GroundCheck()) {
            // check if it is grounded then make jump 
                animator.SetBool ("canJump", true);
                Debug.Log ("grounded");
     
                rigidbody.AddForce (Vector2.up * jumpForece * Time.deltaTime, ForceMode2D.Impulse);
        } else {
            animator.SetBool ("canJump", false);
        }

        if (!GroundCheck ()) {
            animator.SetBool ("canJump", true);
        }

        
        //if(Physics2D.CircleCast (groundCheck.position, radius, -Vector2.up, hitDistance, layerMask)) {
         //   Debug.Log ("circle cast");
       // }

    }

    bool GroundCheck ( ) {
        return Physics2D.Raycast (groundCheck.position, -Vector2.up, hitDistance, layerMask);
    }

    void OnDrawGizmos ( ) {
        Gizmos.DrawWireSphere (groundCheck.position, radius);
        //Gizmos.DrawRay (transform.position, -Vector2.up * 1f);

    }

}
