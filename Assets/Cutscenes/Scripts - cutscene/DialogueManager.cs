using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public static event System.Action<Dialog> NewTalker;
    public static event System.Action ResetText;
    public static event System.Action<string> ShowMessage;
    public static event System.Action<bool> UIState;

    public DialogueContainer currentDialogue;

    private bool endCurrentTalk = true;
    private bool buttonClicked = false;
    void Awake()
    {
        Instance = this;
    }

    public void StartConversation(DialogueContainer container)
    {
        currentDialogue = container;
        StartCoroutine(StartDialogue());
        UIState?.Invoke(true);
    }

    private IEnumerator StartDialogue()
    {
        for (int i = 0; i < currentDialogue._dialogues.Length; i++)
        {
            ResetText?.Invoke();
            NewTalker?.Invoke(currentDialogue._dialogues[i]);
            StartCoroutine(ShowDialogue(currentDialogue._dialogues[i].messages));

            yield return new WaitUntil(() => endCurrentTalk);
        }

        UIState?.Invoke(false);
    }

    private IEnumerator ShowDialogue(string[] messages)
    {
        endCurrentTalk = false;

        foreach(var message in messages)
        {
            ShowAllMessage(message);
            yield return new WaitUntil(() => buttonClicked);
        }

        endCurrentTalk = true;
    }

    private void ShowAllMessage(string message)
    {
        ShowMessage?.Invoke(message);
        buttonClicked = false;
    }
    public void ButtonWasClicked() =>
        buttonClicked = true;
}
