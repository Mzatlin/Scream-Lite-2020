﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteIncrementedDialogue : HandleInteractBase
{
    public bool canRepeat = false;
    public DialogueLoader dialogueWrite;
    public List<DialogSO> dialogueSO;

    ILoadDialogue loader;
    int index =0;

    protected override void Awake()
    {
        base.Awake();
        dialogueWrite.OnEnd += HandleEnd;
        loader = GetComponent<ILoadDialogue>();
    }
    protected override void HandleEnd()
    {
        base.HandleEnd();
        if (IsInteracting)
        {
            dialogueWrite.OnEnd -= HandleEnd;
        }

    }
    protected override void HandleInteraction()
    {
        base.HandleInteraction();
        if(index <= dialogueSO.Capacity-1)
        {
            WriteDialogue();
            index++;
        }
        else
        {

            if (canRepeat)
            {
                index = 0;
                WriteDialogue();
                index++;
            }
            else
            {
                index--;
                WriteDialogue();
            }

        }

    }

    void WriteDialogue()
    {
        if(loader != null || dialogueSO[index] != null)
        {
            loader.SetDialogue(dialogueSO[index]);
        }
        else
        {
            Debug.Log("No loader found");
        }
    }

}
