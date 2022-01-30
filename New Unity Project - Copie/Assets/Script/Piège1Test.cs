using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piège1Test : MonoBehaviour
{
    Vector3 mousePosition;

    public GameObject arrow;

    public Transform arrowTrans;

    public Transform cibleTrans;

    SpriteRenderer sprite;

    float speed = 100f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetInTrap();
    }

    void GetInTrap()
    {
        Debug.Log(arrow.transform.position);

        if(SpiritMovement.trapID == 1)
        {
            sprite.enabled = true;
            arrow.SetActive(true);

            MouseFollow();

            Shoot();

            ArrowPointer();
        }
        if(SpiritMovement.trapID == 0)
        {
            sprite.enabled = false;
            arrow.SetActive(false);
        }
    }
    void MouseFollow()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Shoot");
        }
    }

    void ArrowPointer()
    {
        Debug.Log("bouge");

        //Vector3 dir = arrowTrans.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        float varx = (mousePosition.x - arrow.transform.position.x)*-1;
        float vary = (mousePosition.y - arrow.transform.position.y);
        Vector2 direction = new Vector2(vary, varx);
        arrow.transform.up = direction;
        if (Input.GetMouseButtonDown(1))
            Debug.Log(direction);
    }
}
