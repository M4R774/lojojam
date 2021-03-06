﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum gameState
{
    incoming_mission,
    mission_preparation,
    mission_debriefing
}

// Uses a coroutine to move cameraObject x.position to show one of the wanted screens.
// Use S and D to move between views.
// Also handles moving the agent sprite.
public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float caseFilePos;
    [SerializeField] private float itemsPos;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Coroutine cameraCoroutine;
    public bool canMove = true;

    [Space(10)]
    // Agent sprite stuff
    [SerializeField] private GameObject agentSprite;
    [SerializeField] private float agentCaseFilePos;
    [SerializeField] private float agentItemsPos;
    private float agentPosY;
    private bool flipX;
    [SerializeField] private Coroutine agentCoroutine;
    [SerializeField] private AgentAi agentAi;
    [SerializeField] private TextMeshProUGUI agentSpeechText;

    [Space(10)]
    // Game/mission status
    public gameState game_status;
    public Mission current_mission;
    public SoundEffectsController sound_effect_controller;

    public GameObject agentInventory;
    [SerializeField] private Animator reportAnimator;

  void Start()
    {
        cam = Camera.main;
        flipX = agentSprite.GetComponent<SpriteRenderer>().flipX;

        // Init mission
        current_mission = Missions.GetNextMission();

        agentAi = agentSprite.GetComponent<AgentAi>();
    }
    void Update()
    {
        if(canMove)
        {
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveToCaseFileByPlayer();
            }
            else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveToItemsByPlayer();
            }
        }
    }

    internal void StartNewMission()
    {
        foreach(GameObject item in current_mission.luggage) {
            Destroy(item);
        }
        current_mission = Missions.GetNextMission();
    }

    public void MoveToCaseFileByPlayer()
    {
        if (game_status == gameState.mission_preparation)
        {
            MoveToCaseFile();
        }
    }

    public void MoveToItemsByPlayer()
    {
        if (game_status == gameState.mission_preparation)
        {
            MoveToItems();
        }
    }


    public void MoveToCaseFile()
    {
        StopAllCoroutines();
        sound_effect_controller.PlayFootstepSound();
        cameraCoroutine = null;
        cameraCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, caseFilePos));

        agentCoroutine = null;
        agentCoroutine = StartCoroutine(MoveAgent(agentSprite.transform.position.x, agentCaseFilePos, true));

        agentSpeechText.transform.localPosition = new Vector3(155f, agentSpeechText.transform.localPosition.y, agentSpeechText.transform.localPosition.z);
    }

    public void MoveToItems()
    {
        if(game_status != gameState.incoming_mission)
        {
            StopAllCoroutines();
            sound_effect_controller.PlayFootstepSound();
            cameraCoroutine = null;
            cameraCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, itemsPos));

            agentCoroutine = null;
            agentCoroutine = StartCoroutine(MoveAgent(agentSprite.transform.position.x, agentItemsPos, false));

            agentSpeechText.transform.localPosition = new Vector3(7.5f, agentSpeechText.transform.localPosition.y, agentSpeechText.transform.localPosition.z);
        }
    }

    IEnumerator MoveCamera(float startPos, float endPos)
    {
        float timeElapsed = 0;
        float newPos = 0;
        while(timeElapsed < cameraSpeed)
        {
            newPos = Mathf.Lerp(startPos, endPos, timeElapsed/cameraSpeed);
            cam.transform.position = new Vector3(newPos,0,0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newPos = endPos;
        cam.transform.position = new Vector3(newPos,0,0);
        yield return null;
    }
    IEnumerator MoveAgent(float startPos, float endPos, bool flip)
    {
        agentPosY = agentSprite.transform.position.y;
        float timeElapsed = 0;
        float newPos = 0;
        while(timeElapsed < cameraSpeed)
        {
            newPos = Mathf.Lerp(startPos, endPos, timeElapsed/cameraSpeed);
            agentSprite.transform.position = new Vector3(newPos,agentPosY,0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newPos = endPos;
        agentSprite.transform.position = new Vector3(newPos,agentPosY,0);
        agentSprite.GetComponent<SpriteRenderer>().flipX = flip;
        flipX = agentSprite.GetComponent<SpriteRenderer>().flipX;

        yield return null;
    }

    public void SendAgentToMission()
    {
        HideAgent();
        MoveToCaseFile();
        FaxMissionReport();
    }

    public void FaxMissionReport()
    {
        StartCoroutine("faxAnimationTriggerDelay");
        sound_effect_controller.PlayIncomingFaxSound();
        game_status = gameState.mission_debriefing;
    }


    public void HideAgent()
    {
        agentAi.AgentExits();
    }

    public void ShowAgent()
    {
        agentAi.AgentEnters();
    }

    IEnumerator faxAnimationTriggerDelay()
    {
        yield return new WaitForSeconds(4);
        reportAnimator.SetTrigger("prints");
    }
}
