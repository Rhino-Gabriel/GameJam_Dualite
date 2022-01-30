using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulleApparition : MonoBehaviour
{
    public Transform point;
    public SpriteRenderer[] bulle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Photo"))
        {
            Debug.Log("collis");
            for(int i = 0; i < bulle.Length; i++)
            {
                Debug.Log("recherche");
                if (i == 2)
                {
                    Debug.Log("affiches");
                    bulle[i].enabled = true;
                }
            }
        }

    }
}
