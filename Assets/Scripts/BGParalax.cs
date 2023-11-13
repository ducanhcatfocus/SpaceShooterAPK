using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParalax : MonoBehaviour
{
    [SerializeField] float paralaxSpeed;

     float srpiteHeight;
    Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
        srpiteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    private void Update()
    {
        BackGroundParalax();
    }

    private void BackGroundParalax()
    {
        transform.Translate(paralaxSpeed * Time.deltaTime * Vector3.down);

        if (transform.position.y < startPos.y - srpiteHeight)
        {
            transform.position = startPos;
        }
    }
}
