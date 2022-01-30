using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public PnjRef[] pnjRef;
    public GameObject uiCanvas;
    public bool uiIsActive;

    public Text uiNameOfPnj;
    public TextMeshProUGUI uiDialogue;
    public GameObject continueBouton;
    public Text textButtun;

    public float typingSpeed; //0.02f

    private int indexPnj;
    private int indexDialogue;
    private int index;



    IEnumerator Type()
    {
        foreach (char letter in pnjRef[indexPnj].allDialogue[indexDialogue].dialogue[index].dialogue.ToCharArray())
        {
            uiDialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Start()
    {
        LaunchDialogue(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (uiDialogue.text == pnjRef[indexPnj].allDialogue[indexDialogue].dialogue[index].dialogue)
        {
            continueBouton.SetActive(true);
        }
    }

    public void NextButton()
    {
        if (index < pnjRef[indexPnj].allDialogue[indexDialogue].dialogue.Length - 1)
        {
            continueBouton.SetActive(false);
            index++;
            uiDialogue.text = "";
            StartCoroutine(Type());

            if (index == pnjRef[indexPnj].allDialogue[indexDialogue].dialogue.Length - 1)
            {
                textButtun.text = "Close Dialogue";
            }
        }
        else
        {
            uiCanvas.SetActive(false);
            uiIsActive = false;
            uiNameOfPnj.text = "";
            uiDialogue.text = "";
        }
    }

    public void LaunchDialogue(int idPnj, int alldia, int dialogue)
    {
        textButtun.text = "Next Dialogue";
        continueBouton.SetActive(false);
        if (!uiIsActive)
        {
            uiCanvas.SetActive(true);
            uiIsActive = true;
        }

        indexPnj = idPnj;
        indexDialogue = alldia;
        index = dialogue;

        uiNameOfPnj.text = pnjRef[idPnj].nameOfPnj;
        StartCoroutine(Type());

    }


}
[System.Serializable]
public class PnjRef
{
    public int pnjId;
    public string nameOfPnj;
    public AllDialogue[] allDialogue;

}
[System.Serializable]
public class AllDialogue
{
    public DialogueClass[] dialogue;
}
[System.Serializable]
public class DialogueClass
{
    public int id;
    public string dialogue;

}
