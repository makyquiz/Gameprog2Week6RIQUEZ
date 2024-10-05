using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    public Transform rotateAround;

    public float rotateSpeed = 1f;

    private float direction;
    private bool autoRotate = true;
    private bool rotateClockwise = true;

    public CoinManager cm;

    void Update()
    {
        if (autoRotate)
        {
            if (rotateClockwise)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }
            this.transform.RotateAround(rotateAround.position, Vector3.forward, rotateSpeed * direction * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleRotationDirection();
        }
    }

    void ToggleRotationDirection()
    {
        rotateClockwise = !rotateClockwise;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            cm.collectibleCount++;
        }
    }
}
