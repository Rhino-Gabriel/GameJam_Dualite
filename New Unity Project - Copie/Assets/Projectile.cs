using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 3f;
    Vector3 mousePosition;
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
    }

    void Update()
    {
        Vector3 var = mousePosition;
        transform.position += var * speed * Time.deltaTime;
    }
}
