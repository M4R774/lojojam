﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaseFileController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject header;
    public GameObject body;
    public GameObject caseimage;

    public CameraController camera_controller;
    public TextMeshProUGUI header_text;
    public TextMeshProUGUI body_text;
    public Image caseimage_image;
    
    void Start()
    {
        camera_controller = cameraObject.GetComponent<CameraController>(); 
        header_text = header.GetComponent<TextMeshProUGUI>();
        body_text = body.GetComponent<TextMeshProUGUI>();
        caseimage_image = caseimage.GetComponent<Image>();
    }

    public void UpdateText()
    {
        body_text.text = camera_controller.current_mission.description;
        header_text.text = camera_controller.current_mission.title;
        caseimage_image.sprite = Resources.Load<Sprite>(camera_controller.current_mission.picture_file_name);
    }
}
