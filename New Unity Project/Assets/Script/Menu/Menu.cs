using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SceneAymeric");
        Debug.Log("Left Menu");
    }
}
