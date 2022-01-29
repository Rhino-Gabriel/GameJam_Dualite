using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float initialSpeed = 5f;
    [SerializeField]
    private float slowSpeed = 3f;

    [Header("Dodge")]
    [SerializeField]
    private float dodgeSpeed = 8f;
    [SerializeField]
    private Collider2D myCollider;
    [SerializeField]
    private float dashTime = 0;
    [SerializeField]
    private float dashEnd = 0;
    [SerializeField]
    public bool dodge = false;

    [Header("Caractéristique")]
    [SerializeField]
    private int maxCrazyBar = 1;
    [SerializeField]
    public float currentCrazyBar = 0;

    Vector2 movement;

    private void Start()
    {
        moveSpeed = initialSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        TimeDash();
        CrazyReaction();

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashTime = 1;
        }

        if (dodge && dashTime >= 0.5)
        {
            moveSpeed = dodgeSpeed;
            myCollider.enabled = false;
        }

        else
        {
            moveSpeed = initialSpeed;
            myCollider.enabled = true;
        }

      
    }
    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void TimeDash()
    {
        if (dashTime > dashEnd)
        {
            dashTime -= Time.deltaTime;
            dodge = true;


            if (dashTime <= dashEnd)
            {
                dodge = false;
            }
        }
    }

    public void CrazyReaction()
    {
        if (currentCrazyBar == maxCrazyBar)
        {
            Destroy(gameObject);
        }

        else if (Input.GetKeyDown(KeyCode.F))
        {
            currentCrazyBar += 0.125f;
        }

        else if(currentCrazyBar >= 0.25)
        {
            moveSpeed = slowSpeed;
        }
    }

}
