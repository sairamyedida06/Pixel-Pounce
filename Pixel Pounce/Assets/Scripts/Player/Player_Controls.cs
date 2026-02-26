using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float moveSpeed = 5f;

    private GatherInput gI;
    private Rigidbody2D rb;

    private void Start()
    {
        gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // We check for flipping every frame for instant response
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(gI.valueX * moveSpeed *Time.deltaTime, rb.linearVelocity.y);
    }

    private void Flip()
    {
        // If moving right and facing left, OR moving left and facing right...
        if (gI.valueX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }     
        else if (gI.valueX < 0) 
        { 
            transform.localScale = new Vector3(-1, 1, 1); 
        }
            
    }
}