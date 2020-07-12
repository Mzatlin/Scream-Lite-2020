﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteDialogueOnStart : MonoBehaviour
{
    [SerializeField]
    DialogueLoader dialogueWrite;
    [SerializeField]
    List<DialogSO> dialogueSOs = new List<DialogSO>();
    [SerializeField]
    int index;

    // Start is called before the first frame update
    void Start()
    {
        if(dialogueSOs.Capacity > 0)
        {
            if(index > dialogueSOs.Capacity-1)
            {
                index = 0;
            }
            dialogueWrite.SetupDialougeWriter(dialogueSOs[index]);
            index++;
        }
      
        //  StartCoroutine(WriteDelay());

    }

    IEnumerator WriteDelay()
    {
        yield return new WaitForSeconds(2f);
     //   dialogueWrite.SetupDialougeWriter(dialogueSO);
    }

}
