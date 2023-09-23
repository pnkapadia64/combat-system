using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;

    private bool keepMoving = true;

    void FixedUpdate()
    {
        if (keepMoving)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        keepMoving = false;
    }
}
