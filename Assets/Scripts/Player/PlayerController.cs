using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour {

    /* PUBLIC VARIABLES */
    public float playerSpeed;

    /* PRIVATE VARIABLES */
    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    private Vector2 playerMoveVelocity;
    private bool playerFacingRight = false;

    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  UNITY FUNCTIONS
     */
    
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerMoveVelocity = HandleMoveInput();
        FacingPlayerToMouseDirection();
    }
    
    private void FixedUpdate()
    {
        playerRigidbody2D.MovePosition(playerRigidbody2D.position + playerMoveVelocity * Time.fixedDeltaTime);
    }
    
    /*  - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
     *  PRIVATE FUNCTIONS
     */
    
    // Handles user input for player movement (Axis-Input : WASD)
    private Vector2 HandleMoveInput()
    {
        // Creates new Vector2 with player input
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        // Activates player-animation if player is moving
        playerAnimator.speed = moveInput.magnitude;
        
        // Returns normalized input (1 or -1) multiplied with playerSpeed
        return moveInput.normalized * playerSpeed;
    }

    // Facing player to the mouse direction
    private void FacingPlayerToMouseDirection()
    {
        float mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        if (mousePosition < transform.position.x && playerFacingRight)
        {
            Flip();
        }
        if (mousePosition > transform.position.x && !playerFacingRight)
        {
            Flip();
        }
    }

    // Flips the facing direction of the player
    private void Flip()
    {
        playerFacingRight = !playerFacingRight;

        var playerTransform = transform;
        
        Vector3 theScale = playerTransform.localScale;
        theScale.x *= -1;
        playerTransform.localScale = theScale;
    }
    
}
