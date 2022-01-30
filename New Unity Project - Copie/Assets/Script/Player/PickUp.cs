using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(gameObject);              
            }

        }
    }

    private void OnDestroy()
    {
        PlayerMovement.collectable += 1;
    }
}
