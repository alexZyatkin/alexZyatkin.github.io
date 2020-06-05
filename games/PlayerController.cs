using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;
    private float horizontalInput;
    private float xRange = 2.5f;

    public Animator anim;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //border of scene
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        //control gaming
        if (gameManager.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            float horizontalMove = horizontalInput * speed;
            transform.Translate(Vector3.right * horizontalMove * Time.deltaTime);

            //moveAnimation
            if (horizontalMove > 0)
            {
                anim.SetTrigger("Right");
            }
            if (horizontalMove < 0)
            {
                anim.SetTrigger("Left");
            }
            if (horizontalMove == 0)
            {
                anim.SetTrigger("Idle");
            }
        } else
        {
            anim.SetTrigger("Death");
        }
        
    }
}
