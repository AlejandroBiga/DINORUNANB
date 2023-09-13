using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dino : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask ground1;
    [SerializeField] private float radius; 


    private Rigidbody2D DinoRG;
    private Animator dinoAnimator;
    
    void Start()
    {
        DinoRG = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }

   
    void Update()
    {

        bool isGrounded = Physics2D.OverlapCircle(groundcheck.position, radius, ground1);
        dinoAnimator.SetBool("IsGrounded", isGrounded);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                DinoRG.AddForce(Vector2.up * upForce);

            }
            
        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.ShowGameOverScreen();
            dinoAnimator.SetTrigger("death");
            Time.timeScale = 0f;
        }
    }
}
