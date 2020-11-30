using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocity = 10f;
    public bool canMove = true;

    Rigidbody2D rb;
    Animator anim;
    float vertical;
    float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");

            switch ((int)vertical)
            {
                case -1:
                    anim.SetBool("isWalkingFront", true);
                    anim.SetBool("isWalkingBack", false);
                    break;
                case 1:
                    anim.SetBool("isWalkingFront", false);
                    anim.SetBool("isWalkingBack", true);
                    break;
                default:
                    anim.SetBool("isWalkingFront", false);
                    anim.SetBool("isWalkingBack", false);
                    break;
            }
            switch ((int)horizontal)
            {
                case -1:
                    anim.SetBool("isWalkingLeft", true);
                    anim.SetBool("isWalkingRight", false);
                    break;
                case 1:
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", true);
                    break;
                default:
                    anim.SetBool("isWalkingLeft", false);
                    anim.SetBool("isWalkingRight", false);
                    break;
            }

            rb.velocity = new Vector2(horizontal, vertical) * velocity;
        }
    }
}
