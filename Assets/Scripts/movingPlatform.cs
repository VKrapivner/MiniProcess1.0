using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform platform;
    [SerializeField] float moveTime = 2.0f;
    float timer = 0.0f;
    float moveDir = 1.0f; // -1.0f

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * moveDir;
        if (moveDir == 1.0f && timer >= moveTime)
        {
            moveDir = -1.0f;
        }
        if (moveDir == -1.0f && timer <= 0.0f)
        {
            moveDir = 1.0f;
        }

        transform.position = Vector2.Lerp(pointA.position, pointB.position, timer / moveTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Sätta spelaren som barn till plattformen (valfritt)
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ta bort spelaren som barn
            other.transform.SetParent(null);
        }
    }

}
