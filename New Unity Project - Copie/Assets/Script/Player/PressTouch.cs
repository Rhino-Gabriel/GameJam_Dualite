using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTouch : MonoBehaviour
{
     [SerializeField]
     private GameObject pressUI;
       

      private void OnTriggerStay2D(Collider2D collision)
      {
        pressUI.SetActive(true);
      }

      private void OnTriggerExit2D(Collider2D collision)
      {
           if (collision.tag == "Player")
           {
                pressUI.SetActive(false);
           }
      }
    
}
