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
        currentState.UpdateState();
    }
    public void ChangeState(IState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }
}


public interface IState
{
    public void OnEnter();

    public void UpdateState();

    public void OnHurt();

    public void OnExit();
}



/*enum EventType
{
    OnEnter,
    OnUpdate,
    OnExit,
}*/