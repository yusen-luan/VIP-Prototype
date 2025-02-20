using System.Collections;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogUI : MonoBehaviour
{

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialogue;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogObject dialogObject)
    {
        StartCoroutine(StepThroughDialogue(dialogObject));
    }

    private IEnumerator StepThroughDialogue(DialogObject dialogObject)
    {       

        for (int i = 0; i < dialogObject.Dialogue.Length; i++)
        {
            string dialogue = dialogObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            if (i == dialogObject.Dialogue.Length - 1 && dialogObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        if (dialogObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogObject.Responses);
        } 
        else 
        { 
            CloseDialogueBox(); 
        }

        
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
   
}
