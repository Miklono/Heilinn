using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float velocity = 500f;
    public GameObject dialog;
    public GameObject txtMPObject;

    Animator animator;
    float vertical;
    float horizontal;
    Rigidbody2D rb;
    bool canMove = true;
    bool interaciotn = false;
    bool onDialog = false;
    





    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");

            switch ((int)vertical)
            {
                case (-1):
                    animator.SetBool("Walk", true);
                    animator.SetBool("WalkBack", false);
                    break;
                case (1):
                    animator.SetBool("Walk", false);
                    animator.SetBool("WalkBack", true);
                    break;
                default:
                    animator.SetBool("Walk", false);
                    animator.SetBool("WalkBack", false);
                    break;
            }

            switch ((int)horizontal)
            {
                case (-1):
                    animator.SetBool("WalkLeft", true);
                    animator.SetBool("WalkRight", false);
                    break;
                case (1):
                    animator.SetBool("WalkLeft", false);
                    animator.SetBool("WalkRight", true);
                    break;
                default:
                    animator.SetBool("WalkLeft", false);
                    animator.SetBool("WalkRight", false);
                    break;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                interaciotn = true;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                interaciotn = false;
            }

        }

        rb.velocity = new Vector2(horizontal, vertical) * velocity * Time.deltaTime;
        

        if (onDialog)
        {
            canMove = false;
            dialog.SetActive(true);
            rb.velocity = new Vector2(0f, 0f);
            animator.SetBool("Walk", false);
            animator.SetBool("WalkBack", false);
            animator.SetBool("WalkLeft", false);
            animator.SetBool("WalkRight", false);
            txtMPObject.GetComponent<CreateText>().OnEnable();
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("CombatScene");
            }
        }
        if (!onDialog)
        {
            canMove = true;
            dialog.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (interaciotn && c.tag == "Enemy")
        {
            onDialog = true;
        }
        if(interaciotn && c.tag == "Cave")
        {
            SceneManager.LoadScene("Map Scene");
        }
    }
}
