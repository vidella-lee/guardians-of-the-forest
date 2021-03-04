using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;
    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueActive&& Input.GetKeyUp(KeyCode.Space))
        {
            //dBox.SetActive(false);
            //dialogueActive = false;

            currentLine++;
        }

        if(currentLine >= dialogueLines.Length)
        {
            //Deactivate textbox once the array of dialogue lines reaches its end
            dBox.SetActive(false);
            dialogueActive = false;

            //Reset currentLine to beginning
            currentLine = 0;

            //Allow player movement when dialogue box is no longer active
            thePlayer.canMove = true;
        }

        dText.text = dialogueLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);

        //Stop player movement when dialogue box is active
        thePlayer.canMove = false;
    }
}
