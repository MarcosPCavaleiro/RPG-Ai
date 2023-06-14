using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NpcDialog : Interactable
{
    public GameObject dialogPanel;
    public TextMeshProUGUI text;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject button;

    void Start() 
    {
        text.text = string.Empty;
    }

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(delay());
        text.text = string.Empty;
        StartDialog();

    }


    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        dialogPanel.SetActive(true);
    } 

    public void StartDialog() 
    {
        index = 0;
        StartCoroutine(Typing());

    }
   
    IEnumerator Typing() 
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
        if(index < lines.Length - 1)
        {
            button.SetActive(true);
        }
    }

    public void NextLine()
    {
        button.SetActive(false);

        if(index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(Typing());
        }
    }
}
