using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatHeight;
    void Start()
    {
        startPos = transform.position;
        //repeat a half of background
        repeatHeight = GetComponent<BoxCollider>().size.y / 2;
    }

    void FixedUpdate()
    {
        if (transform.position.y < startPos.y - repeatHeight)
        {
            transform.position = startPos;
        }
    }
}
