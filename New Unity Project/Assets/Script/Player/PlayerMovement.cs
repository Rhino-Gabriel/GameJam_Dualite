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
    private bool facingRight;
    Vector2 movement;

    [Header("Dodge")]
    [SerializeField]
    private float dodgeSpeed = 8f;
    [SerializeField]
    private Collider2D myCollider;
    [SerializeField]
    public float dashTime = 0;
    [SerializeField]
    private float dashEnd = 0;
    [SerializeField]
    public bool dodge = false;

    [Header("Caractéristique")]
    [SerializeField]
    private int maxCrazyBar = 1;
    [SerializeField]
    public float currentCrazyBar = 0;

    [Header("CrazyReact")]
    [SerializeField]
    private float slowSpeed = 3f;
    [SerializeField]
    private int randomDash;
    [SerializeField]
    public float randomDashTime = 0;
    [SerializeField]
    private float randomDashEnd = 0;
    [SerializeField]
    private bool randomDodge = true;
    [SerializeField]
    private AudioSource myAudio;
    public static bool lessDash = false;

    [Header("Interact")]
    [SerializeField]
    public static int collectable;

    

    private void Start()
    {
        moveSpeed = initialSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        TimeDash();
        CrazyReaction();
        RandomTimeDash();

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.Q) && facingRight)
        {          
                Flip();                   
        }

        else if (Input.GetKey(KeyCode.D) && !facingRight)
        {           
                Flip();          
        }

        if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dashTime <= 0 && !lessDash)
                {
                    dashTime = 2;
                }

                else if(dashTime <= 0 && lessDash)
                {
                    dashTime = 3;
                }                   
            }
        
        
        if (dodge && dashTime >= 1.5 && !lessDash)
        {
            moveSpeed = dodgeSpeed;
            myCollider.enabled = false;
        }

        else if (dodge && dashTime >= 2.5 && lessDash)
        {
            moveSpeed = dodgeSpeed;
            myCollider.enabled = false;
        }

        else if(collectable == 4)
        {
            Debug.Log("Win");
        }

        else
        {
            moveSpeed = initialSpeed;
            myCollider.enabled = true;
        }

      
    }
    void FixedUpdate()
    {
       
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

    public void RandomTimeDash()
    {
        if (randomDashTime > randomDashEnd)
        {
            randomDashTime -= Time.deltaTime;
            randomDodge = false;


            if (randomDashTime <= randomDashEnd)
            {
                randomDodge = true;
            }
        }
    }

    public void CrazyReaction()
    {
        if (currentCrazyBar == maxCrazyBar)
        {
            Destroy(gameObject);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            currentCrazyBar += 0.125f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            currentCrazyBar -= 0.125f;
        }

        else if(currentCrazyBar >= 0.25f && currentCrazyBar < 0.50f)
        {
            initialSpeed = slowSpeed;
            lessDash = false;
        }

        else if (currentCrazyBar >= 0.50f && currentCrazyBar < 0.75f)
        {          
            initialSpeed = slowSpeed;
            lessDash = true;
            myAudio.enabled = false;
        }

        else if (currentCrazyBar >= 0.75)
        {

            initialSpeed = slowSpeed;
            lessDash = true;
            myAudio.enabled = true;

            if (randomDodge)
            {
                randomDash = Random.Range(1, 2000);
            }
            
            if (randomDash == 1999)
            {               
                dashTime = 3;
                randomDashTime = 6;

                if(randomDodge == false)
                {
                    randomDash = 1998;
                }
            } 
        }

        else
        {
            initialSpeed = 5f;
        }

    }

    public void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 11)
        {
            currentCrazyBar += 0.125f;
        }
    }
}
