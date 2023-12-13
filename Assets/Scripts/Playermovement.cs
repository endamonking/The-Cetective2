using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public Animator animator;
    private float horizontal;
    [SerializeField] private float speed = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        if(CanMove()==false)
            return;
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal> 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
    bool CanMove()
    {
        bool can = true;
        if (FindObjectOfType<inventory>().isOpen)
            can = false;
        return can; 
            
    }

}
