using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    public float timer = 5;
    bool trapactive = false;
    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        if (SpiritMovement.trapID == 2)
        {
            SpiderFollow();
        }
    }

    void SpiderFollow()
    {
        Vector3 move2 = new Vector3(-2, 0, 0);
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 move = new Vector3(2, 0, 0);
            
            transform.position += move;
            timer = 0;
            trapactive = true;
        }
        if (timer >= 5 && trapactive)
        {
            transform.position += move2;
            trapactive = false;
        }
    }
}
