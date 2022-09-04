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
    // Start is called before the first frame update
    void Start()
    {
        DinoRG = GetComponent<Rigidbody2D>();
        dinoAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
}
