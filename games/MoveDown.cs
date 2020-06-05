using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = -2f;
    private float downBound = -11.2f;
    private Vector3 waveSpawn = new Vector3(0, 11.2f, -0.1f);

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Player").GetComponent<GameManager>();    
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //ban movement if gameover
        if (gameManager.isGameActive == false)
        {
            speed = 0;
        }
        
        if (transform.position.y < downBound)
        {
            if (gameObject.CompareTag("Wave"))
            {
                transform.position = waveSpawn; 
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
