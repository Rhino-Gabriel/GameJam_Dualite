using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField]
    private Image dashBar;
    private float currentDash;
    private float maxDash1 = 2;
    private float maxDash2 = 3;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        dashBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDash = player.dashTime;
        dashBar.fillAmount = currentDash/ maxDash1;

        if(PlayerMovement.lessDash == true)
        {
            maxDash1 = maxDash2;
        }
    }
}