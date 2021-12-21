using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour {

    [Range(1,10)]
    [SerializeField] float speed;

    [Range(1,10)]
    [SerializeField] float distance;

    private GameObject Player;

    private float lastPosition;
    private bool facingRight = false;

    private void FixedUpdate()
    {
        if(Player != null)
        {
            Move();
        }
    }

    private void Start()
    {
        //Player = transform.Find("Player");
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Move()
    {
        // If the Player is to far from player
        if (Vector2.Distance(transform.position, Player.transform.position) > distance)
        {
            // It Moves to the Player
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.fixedDeltaTime);

            // If the Player moves left with a look to the right, it will flip
            if (lastPosition > transform.position.x && facingRight)
            {
                Flip();
            }

            // If the Player moves right with a look to the left, it will flip
            if (lastPosition < transform.position.x && !facingRight)
            {
                Flip();
            }

            // Saves the last position, to recognize the moveDirection
            lastPosition = transform.position.x;
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
