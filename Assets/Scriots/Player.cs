using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float speed;
    private bool facingRight = true;
    public float jumpforce;
    private bool isGrounded;
    public Transform feetPos;
    public float radius = 0.2f;
    public LayerMask whatIsGround;
    public GameObject canvas;

    void Start()
    {
        //Fizik bileþenini alma
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Yatay eksen tanýmý
        horizontal = Input.GetAxisRaw("Horizontal");
        if (rb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        Jump();
    }
    private void FixedUpdate()
    {
        Walk();
    }
    private void Walk()
    {
        //Tanýmlanan yatay eksen üzerinde bir F kuvveti oluþturup hýz ile çarparak yürütme
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void FlipFace()
    {
        //Yüz çevirme
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
        canvas.transform.localScale = tempLocalScale;
    }
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, radius, whatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space) || isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * jumpforce;

        }
        
    }

}
