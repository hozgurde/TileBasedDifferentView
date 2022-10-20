using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 10;
    public SpriteMask dayMask;


    private BoxCollider2D playerCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

    // Start is called before the first frame update
    
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Move();
        
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        //Add inputs to move delta
        moveDelta = Vector3.zero;

        if (horizontalInput != 0)
        {
            moveDelta.x = horizontalInput / Mathf.Abs(horizontalInput);
        }
        if (verticalInput != 0)
        {
            moveDelta.y = verticalInput / Mathf.Abs(verticalInput);
        }

        //Manual Collider check
        //Check y axis
        hit = Physics2D.BoxCast(transform.position, playerCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * moveSpeed * Time.deltaTime), LayerMask.GetMask("NotPassable"));

        if (hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * moveSpeed * Time.deltaTime, 0);
        }

        //Check x axis
        hit = Physics2D.BoxCast(transform.position, playerCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * moveSpeed *  Time.deltaTime), LayerMask.GetMask("NotPassable"));

        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * moveSpeed * Time.deltaTime, 0 , 0);
        }


    }
}
