using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    public float timer = 5;
    public float cooldown = 5;
    bool trapactive = false;
    public GameObject spider;

    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        if (cooldown < 5)
        {
            cooldown += Time.deltaTime;
        }
        if (SpiritMovement.trapID == 2)
        {
            SpiderFollow();
        }
    }

    void SpiderFollow()
    {
        Vector3 move2 = new Vector3(-3, -2, 0);
        if (Input.GetMouseButtonDown(1) && timer >= 5 && cooldown >= 5)
        {
            Vector3 move = new Vector3(1, 1, 0);
            
            spider.transform.position += move;
            timer = 0;
            trapactive = true;
        }
        if (timer >= 5 && trapactive)
        {
            spider.transform.position += move2;
            trapactive = false;
            cooldown = 0;
        }
    }
}
