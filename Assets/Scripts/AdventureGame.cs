using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    

    State state;

    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        
    }

    
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        for (int index = 0; index < nextStates.Length; index++)
        {
            if (Input.GetKeyDown(KeyCode.A + index))
            {
                state = nextStates[index];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            var totalElements = nextStates.Length;
            state = nextStates[totalElements - 1];
        }

        textComponent.text = state.GetStateStory();
    }
}
