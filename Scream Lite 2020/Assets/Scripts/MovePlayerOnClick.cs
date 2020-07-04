﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOnClick : GameObjectPathingBase, IMove
{
    [SerializeField]
    float moveSpeed = 4;
    [SerializeField]
    LayerMask floorMask;
    ICameraRaycast raycast;
    Vector2 mousePosition;
    bool isMoving = false;
    Camera cam;

    public AK.Wwise.Event MyEvent = null;

    bool IMove.isMoving { get => isMoving; set => isMoving = value; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        cam = Camera.main;
        raycast = cam.GetComponent<ICameraRaycast>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isMoving)
        {
            CheckPathing();
            MoveSeeker();
            UpdateWayPoint();
            CheckPosition();
        }
        else
        {
            MyEvent.Stop(gameObject);
        }
        if (Input.GetMouseButtonDown(0) && raycast.RayHit && (1 << raycast.RayHit.collider.gameObject.layer & floorMask) != 0)
        {
            MyEvent.Post(gameObject);
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            //  finalPosition.position = mousePosition;
            //  target = finalPosition;
            UpdatePath();
            isMoving = true;

        }

    }

    protected override void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, mousePosition, OnPathComplete);
        }
    }

    /*void SetPlayerPosition()
    {
        MyEvent.Post(gameObject);
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        isMoving = true;
    }*/

    void CheckPosition()
    {
        //   transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, mousePosition) <= 2.5f)
        {
            isMoving = false;
        }
    }
}