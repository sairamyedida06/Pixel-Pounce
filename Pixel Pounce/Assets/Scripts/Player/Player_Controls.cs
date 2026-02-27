using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    private GatherInput gI;
    private Rigidbody2D rb;
    private Animator animator;

    //private bool doubleJump = true;
    public int additionalJumps = 2;
    [SerializeField]private int  resetJumpNumber;

    private float rayLength = 0.05f;
    public LayerMask groundLayer;
    public Transform leftPoint;
    private bool grounded = true;


    private void Start()
    {
        gI = GetComponent<GatherInput>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        resetJumpNumber = additionalJumps;
    }

    private void Update()
    {
        Flip();
        Jump();
        UpdateAnimation();

    }

    private void FixedUpdate()
    {
        IsGrounded();
        Move();
        
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(gI.valueX * moveSpeed , rb.linearVelocity.y);

    }

    private void Jump()
    {
        if (gI.jumpInput)
        {
            if(grounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                //doubleJump = true;
            }
            else if (additionalJumps > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                //doubleJump = false;
                additionalJumps -= 1;
            }


                gI.jumpInput = false;
           

                
                
        }
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

    private void IsGrounded()
    {
        RaycastHit2D groundhit = Physics2D.Raycast(leftPoint.position,Vector2.down, rayLength, groundLayer);

        if (groundhit)
        {
            grounded = true;
            //doubleJump = false;

            additionalJumps = resetJumpNumber;
        }
        else
        {
            grounded = false;
        }
    }
   

    private void UpdateAnimation()
    {
        animator.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("VHeight",rb.linearVelocityY);
        animator.SetBool("Grounded",grounded);

    }
}