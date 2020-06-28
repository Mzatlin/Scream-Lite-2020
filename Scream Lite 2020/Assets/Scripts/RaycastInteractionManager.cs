﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractionManager : MonoBehaviour
{
    [SerializeField]
    DialogueSO dialog;
    ICameraRaycast raycast;
    // Start is called before the first frame update
    void Start()
    {
        if (dialog != null)
        {
            dialog.OnWrite += HandleWriteDialog;
            dialog.OnEnd += HandleEndDialog;
        }
        raycast = GetComponent<ICameraRaycast>();
    }

    private void HandleWriteDialog()
    {
        raycast.CanCast = false;
    }

    private void HandleEndDialog()
    {
        raycast.CanCast = true;
    }

}