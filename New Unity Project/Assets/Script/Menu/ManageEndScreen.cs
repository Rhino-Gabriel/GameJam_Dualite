using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ManageEndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGameAgain ()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Playing Again!");
    }

    public void LoadMenu ()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu from death Screen");
    }
}
