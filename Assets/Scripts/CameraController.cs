﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses a coroutine to move camera x.position to show one of the wanted screens.
// Use S and D to move between views
public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float caseFilePos;
    [SerializeField] private float itemsPos;
    //[SerializeField] private float reportsPos;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Coroutine thisCoroutine;
    public bool canMove = true;
    [Space(10)]
    // Agent sprite stuff
    [SerializeField] private GameObject agentSprite;
    private float agentPosY;
    private bool flipX;
    void Start()
    {
       cam = Camera.main;
       agentPosY = agentSprite.transform.position.y;
       flipX = agentSprite.GetComponent<SpriteRenderer>().flipX;

    }
    void Update()
    {
        if(canMove)
        {
            // For debugging
            if(Input.GetKeyDown(KeyCode.A))
            {
                MoveToCaseFile();
            }
            else if(Input.GetKeyDown(KeyCode.D))
            {
                MoveToItems();
            }
            /*else if(Input.GetKeyDown(KeyCode.A))
            {
                MoveToReports();
            }*/
        }
    }
    public void MoveToCaseFile()
    {
        StopAllCoroutines();
        thisCoroutine = null;
        thisCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, caseFilePos));
    }
    public void MoveToItems()
    {
        StopAllCoroutines();
        thisCoroutine = null;
        thisCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, itemsPos));
    }
    /*public void MoveToReports()
    {
        StopAllCoroutines();
        thisCoroutine = null;
        thisCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, reportsPos));
    }*/

    IEnumerator MoveCamera(float startPos, float endPos)
    {
        float timeElapsed = 0;
        float newPos = 0;
        while(timeElapsed < cameraSpeed)
        {
            newPos = Mathf.Lerp(startPos, endPos, timeElapsed/cameraSpeed);
            cam.transform.position = new Vector3(newPos,0,0);
            agentSprite.transform.position = new Vector3(newPos,agentPosY,0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newPos = endPos;
        cam.transform.position = new Vector3(newPos,0,0);

        agentSprite.transform.position = new Vector3(newPos,agentPosY,0);
        agentSprite.GetComponent<SpriteRenderer>().flipX = !flipX;
        flipX = agentSprite.GetComponent<SpriteRenderer>().flipX;
        
        yield return null;
    }
}
