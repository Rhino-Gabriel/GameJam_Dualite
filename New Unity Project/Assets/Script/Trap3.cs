using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap3 : MonoBehaviour
{
    public float timer = 5;
    bool trapactive = false;
    public GameObject hole;
    void Update()
    {
        if (timer < 5)
        {
            timer += Time.deltaTime;
        }
        if (SpiritMovement.trapID == 3)
        {
            HoleAppear();
        }
    }

    void HoleAppear()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("shoot");
            hole.SetActive(true);
            timer = 0;
            trapactive = true;
        }
        if (timer >= 5 && trapactive)
        {
            hole.SetActive(false);
            trapactive = false;
        }
    }
}
