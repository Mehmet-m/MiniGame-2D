using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRb;
    Animator playerAnimator;
    public float moveSpeed = 1f;

    bool faceRight = true;

    public float jumpSpeed = 1f,jumpFrequency=1f,nextJumpTime;

    public bool isGround = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    private void Awake()
    {

    }

    public void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();
        Ongroundcheck();
        if (playerRb.velocity.x<0&&faceRight)
        {
            Flipface();
        }
        else if (playerRb.velocity.x>0&&!faceRight)
        {
            Flipface();
        }
        if (Input.GetAxis("Vertical")>0&&isGround&&(nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    private void FixedUpdate()
    {

    }
    void HorizontalMove()
    {
        playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRb.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs( playerRb.velocity.x));
    }
    void Flipface()
    {
        faceRight = !faceRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
    void Jump()
    {
        playerRb.AddForce(new Vector2(0f, jumpSpeed));
    }
    void Ongroundcheck()
    {
        isGround= Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim",isGround);
    }
}
