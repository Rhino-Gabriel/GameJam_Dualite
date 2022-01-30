using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    private AudioSource myAudio1;
    [SerializeField]
    private AudioSource myAudio2;
    [SerializeField]
    private AudioSource myAudio3;
    public static bool lessDash = false;
    public Image eyes;
    public Image eyes1;
    public Image eyes2;
    public Image eyes3;

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
        Echap();

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movement.Normalize();
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q) && facingRight)
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

            else if (dashTime <= 0 && lessDash)
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

        else if (collectable == 4)
        {
            Win();
        }

        else
        {
            moveSpeed = initialSpeed;
            myCollider.enabled = true;
        }


    }

    public void Win()
    {
        SceneManager.LoadScene("PlayerWin");
    }

    public void Echap()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
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
            SceneManager.LoadScene("GhostWin");
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
            eyes.enabled = false;
            eyes1.enabled = true;
            eyes2.enabled = false;
            initialSpeed = slowSpeed;
            lessDash = false;
            myAudio1.enabled = true;
            myAudio2.enabled = false;
            myAudio3.enabled = false;
            lessDash = false;
        }

        else if (currentCrazyBar >= 0.50f && currentCrazyBar < 0.75f)
        {
            eyes1.enabled = false;
            eyes2.enabled = true;
            eyes3.enabled = false;
            initialSpeed = slowSpeed;
            lessDash = true;
            myAudio.enabled = false;
            myAudio2.enabled = true;
            myAudio1.enabled = false;           
        }

        else if (currentCrazyBar >= 0.75)
        {
            eyes2.enabled = false;
            eyes3.enabled = true;
            initialSpeed = slowSpeed;
            lessDash = true;
            myAudio.enabled = true;
            myAudio2.enabled = false;

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
            eyes1.enabled = false;
            eyes.enabled = true;
            myAudio3.enabled = true;
            myAudio1.enabled = false;
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
