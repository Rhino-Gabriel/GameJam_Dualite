using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrazyBar : MonoBehaviour
{
    [SerializeField]
    private Image crazyBar;
    private float currentCrazy;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        crazyBar = GetComponent<Image>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCrazy = player.currentCrazyBar;
        crazyBar.fillAmount = currentCrazy;
    }
}
