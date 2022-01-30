using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    public SpriteRenderer sprite;
    [SerializeField]
    private float apparition;
    [SerializeField]
    private float mustApparition;
    [SerializeField]
    private float mustDisparition;
    [SerializeField]
    private float disparition;
    [SerializeField]
    private bool goDisparition = false;
    // Start is called before the first frame update
    void Start()
    {       
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(apparition < mustApparition)
        {
            apparition += Time.deltaTime;

            if(apparition >= mustApparition)
            {
                goDisparition = true;
                sprite.enabled = true;             
            }
        }

         if (goDisparition == true)
         {
            if (disparition < mustDisparition)
            {
                disparition += Time.deltaTime;

                if (disparition >= mustDisparition)
                {
                    sprite.enabled = false;
                }
            }
         }
    }
}
