using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap4 : MonoBehaviour
{
    public float timer = 5;
    public float cooldown = 3;
    bool trapactive = false;
    public GameObject ecran;
    public GameObject trap;
    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        if (cooldown < 3)
        {
            cooldown += Time.deltaTime;
        }
        if (SpiritMovement.trapID == 4)
        {
            HoleAppear();
        }
    }

    void HoleAppear()
    {
        if (Input.GetMouseButtonDown(1) && timer >= 5 && cooldown >= 3)
        {
            Debug.Log("shoot");
            ecran.SetActive(true);
            timer = 0;
            trapactive = true;
            trap.SetActive(true);
        }
        if (timer >= 5 && trapactive)
        {
            ecran.SetActive(false);
            trap.SetActive(false);
            trapactive = false;
            cooldown = 0;
        }
    }
}
