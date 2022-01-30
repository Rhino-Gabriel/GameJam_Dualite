using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritMovement : MonoBehaviour
{
    Vector3 mousePosition;

    RaycastHit2D ray;

    GameObject selectedObject;

    SpriteRenderer sprite;

    public static int trapID = 0;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(trapID);
        MouseFollow();

        GameObjectDetector();

        UseObject();
    }

    void MouseFollow()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
    }

    void GameObjectDetector()
    {
        ray = Physics2D.Raycast(new Vector2(mousePosition.x, mousePosition.y), Vector2.zero, 0);
        selectedObject = ray.transform.gameObject;
    }

    void UseObject()
    {
        if (selectedObject.tag == "Bonjour" && Input.GetMouseButtonDown(0))
        {
            sprite.enabled = !sprite.enabled;
            trapID = TrapID(1);
        }
    }

    int TrapID(int value)
    {
        if(trapID == 0 && value == 1)
        {
            return 1;
        }
        else if(trapID == 1)
        {
            return 0;
        }
        else
        {
            return 0;
        }
    }
}
