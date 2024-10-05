using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObstacleScript : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed;

    private bool movingRight;

    void Start()
    {
        if (transform.position.x < 0)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }
    }


    void FixedUpdate()
    {

        if (movingRight)
        {
            if (transform.position.x < 15f)
            {
                transform.Translate(Vector2.right * (Time.deltaTime * obstacleSpeed));
            }
        }

        else
        {
            if (transform.position.x > -15f)
            {
                transform.Translate(Vector2.left * (Time.deltaTime * obstacleSpeed));
            }

            if (transform.position.x == 15.00002f)
            {
                Destroy(gameObject);
            }
        }     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
