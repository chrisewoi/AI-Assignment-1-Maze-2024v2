using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;
using LitMotion;
using Unity.VisualScripting;

public class MoveDoor : MonoBehaviour
{

    public enum DoorStates
    {
        Closed,
        Open
    }

    public Transform doorClosed;
    public Transform doorOpen;
    public Transform door;

    public float transitionTime;
    public bool toggleDoor;
    private bool _isTrue;
    public bool isTrue => _isTrue;

    private StateMachine<DoorStates> stateMachine;
    public Ease ease;
    public DoorStates state;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine<DoorStates>();
        stateMachine.AddState(DoorStates.Closed, OnEnter_DoorClosed);
        stateMachine.AddState(DoorStates.Open, OnEnter_DoorOpen);
        
        stateMachine.Init();
    }

    protected virtual void OnEnter_DoorClosed(StateBase<DoorStates> state)
    {
        LMotion.Create(door.position, doorClosed.position, transitionTime)
            .WithEase(ease)
            .Bind(x => door.position = x);
    }

    protected virtual void OnEnter_DoorOpen(StateBase<DoorStates> state)
    {
        LMotion.Create(door.position, doorOpen.position, transitionTime)
            .WithEase(ease)
            .Bind(x => door.position = x);
    }
    

    // Update is called once per frame
    void Update()
    {
        if (toggleDoor)
        {
            state = state == DoorStates.Closed ? DoorStates.Open : DoorStates.Closed;
            stateMachine.RequestStateChange(state);
            toggleDoor = false;
        }
    }
    

}
