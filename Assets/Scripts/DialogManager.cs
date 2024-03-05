﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public InteractionManager InteractionManager;
    public GameObject dialoguePanel;
    public GameObject continueBtn;

    public Image charIcon;
    public Text charName;
    public Text dialogueText;

    private Queue<DialogueLine> lines = new Queue<DialogueLine>();

    public bool isTyping;
    public float wordSpeed = 0.01f;

    public Animator animator;

    [Header("UI Button")]
    [SerializeField] private GameObject MoveBtn;
    [SerializeField] private GameObject ActionBtn;


    private void Start()
    {
        if(Instance == null)
            Instance = this;
    }
    public void OpenDialoguePanel(Dialog dialogue)
    {
        isTyping = true;
        dialoguePanel.SetActive(true);

        MoveBtn.SetActive(false);
        ActionBtn.SetActive(false);


        lines.Clear();
        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }
        NextLine();
    }

    public void NextLine()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        charIcon.sprite = currentLine.charater.icon;
        charName.text = currentLine.charater.name;

        StopAllCoroutines();
        StartCoroutine(Typing(currentLine));
    }
    IEnumerator Typing(DialogueLine dialogue)
    {
        dialogueText.text = "";
        foreach (char letter in dialogue.line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);

        MoveBtn.SetActive(true);
        ActionBtn.SetActive(true);

        isTyping = false;
    }
}
