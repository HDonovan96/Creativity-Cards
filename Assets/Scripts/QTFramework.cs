﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

// Quick time event handler.
// Code from https://gist.github.com/grimmdev/b85994d1b7cad444eb69 has been used as inspiration.

// This class has been designed to be added to a game object which defines the area you want the quick time event to occur in. 
// The function runQTEvent should then be called whenever a quick time event should run and must be passed the sequence of key presses to display

public class QTFramework : MonoBehaviour
{
    private enum CurrentState 
    {
        Ready,
        Active,
        Completed
    };

    private CurrentState QTState = CurrentState.Ready;

    private enum Response
    {
        Null,
        Success,
        Fail
    };

    private Response QTResponse = Response.Null;

    // Stores the keys in the quick time event sequence.
    // This should be passed to the framework
    public List<KeyCode> sequence;

    public int buttonOffset = 5;
    public int keySpeed = 1;
    public GameObject buttonPrefab;
    private RectTransform QTArea;
    private bool firstRun = true;
    private GameObject[] QTButtons;

    void Start() 
    {
        // Gets the area the quick time event is happening in and uses it for refrence when placing the buttons. 
        QTArea = gameObject.GetComponent<RectTransform>();
    }

    private void GenerateButtons()
    {
        if (sequence != null)
            {
                firstRun = false;
                //Initialises an array to store all of the generated buttons for the quick time events
                QTButtons = new GameObject[sequence.Count];

                Vector3 buttonPos = new Vector3();
                buttonPos.y = QTArea.position.y;
                buttonPos.z = QTArea.position.z;

                RectTransform buttonTransform = buttonPrefab.GetComponent<RectTransform>();
                float buttonWidth = buttonTransform.sizeDelta.x;

                // Spawns all of the quick time buttons for the sequence
                for (int i = 0; i < sequence.Count; i++) 
                {
                    buttonPos.x = QTArea.position.x + buttonOffset * (i +  1) + buttonWidth * i; 
                    QTButtons[i] = Instantiate(buttonPrefab, buttonPos, new Quaternion(), transform) as GameObject;

                    TextMeshProUGUI buttonText = QTButtons[i].transform.GetComponentInChildren<TextMeshProUGUI>();
                    buttonText.text = sequence[i].ToString();
                }  
            }
    }

    void Update()
    {
        if(firstRun)
        {
            GenerateButtons();
        }

        for (int i = 0; i < QTButtons.Length; i++)
        {
            QTButtons[i].transform.position -= new Vector3(keySpeed * Time.deltaTime, 0, 0);
        }
            
    }
}
