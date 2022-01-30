using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 3f;
    public float timer = 0;
    Vector3 mousePosition;
    void Start()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
    }

    void Update()
    {
        if (timer < 10)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 10)
        {
            Destroy(gameObject);
        }
        Vector3 var = mousePosition;
        transform.position += var * speed * Time.deltaTime;
    }
}
