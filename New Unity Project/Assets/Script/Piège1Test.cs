using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piège1Test : MonoBehaviour
{
    Vector3 mousePosition;

    public GameObject arrow;

    public GameObject projectile;

    public float cooldown = 2;

    public Transform arrowTrans;

    public Transform cibleTrans;

    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (cooldown < 2)
        {
            cooldown += Time.deltaTime;
        }
        GetInTrap();
    }

    void GetInTrap()
    {
        if(SpiritMovement.trapID == 1)
        {
            //sprite.enabled = true;
            arrow.SetActive(true);

            MouseFollow();

            Shoot();

            ArrowPointer();
        }
        if(SpiritMovement.trapID == 0)
        {
            //sprite.enabled = false;
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
        if (Input.GetMouseButtonDown(1) && cooldown >= 2)
        {
            Debug.Log("Shoot");
            Instantiate(projectile);
            cooldown = 0;
        }
    }

    void ArrowPointer()
    {
        Debug.Log("bouge");

        //Vector3 dir = arrowTrans.position - transform.position;
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        
        float varx = (mousePosition.x - arrow.transform.position.x);
        float vary = (mousePosition.y - arrow.transform.position.y);
        Vector2 direction = new Vector2(varx, vary);
        arrow.transform.up = direction;
    }
}
