using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritController : MonoBehaviour
{
    public GameObject spirit;
    RaycastHit2D ray;
    public GameObject selectedObject;
    SpriteRenderer sprite;
    static public bool InTrap;

    void Update()
    {
        sprite = GetComponent<SpriteRenderer>();

        //if (!InTrap)
        //{
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
            ray = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), Vector2.zero, 0);
        //}
        //else if (InTrap)
        //{
            /*Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = Mathf.Clamp(pos.x, 0, 5);
            pos.y = Mathf.Clamp(pos.y, 0, 5);
            pos.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = pos;
            ray = Physics2D.Raycast(new Vector2(pos.x, pos.y), Vector2.zero, 0);*/
        //}
        if (selectedObject && Input.GetMouseButtonDown(0))
        {
            if (selectedObject.tag == "Bonjour")
            {
                sprite.enabled = !sprite.enabled;
                bonjourscript.Shoot = true;
                InTrap = !InTrap;
            }
        }
    }
}

