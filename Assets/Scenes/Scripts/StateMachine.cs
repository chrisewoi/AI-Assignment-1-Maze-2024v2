using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour
{
    private IState currentState;



    void Update()
    {
        if(currentState != null) currentState.UpdateState();
    }
    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;
        currentState.OnEnter();
    }
}


public interface IState
{
    public void OnEnter();

    public void UpdateState();
    

    public void OnExit();
}