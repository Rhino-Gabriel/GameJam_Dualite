using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonjourscript : MonoBehaviour
{
    static public bool Shoot;
    public GameObject fleche;
    
    private void Update()
    {
        if (Shoot)
        {
            Debug.Log("Shoot");
            Shoot = false;
            fleche.SetActive(SpiritController.InTrap);
        }
    }
}
