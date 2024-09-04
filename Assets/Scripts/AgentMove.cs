using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityHFSM;


[RequireComponent(typeof(NavMeshAgent))]
public class AgentMove : MonoBehaviour
{
    public enum AgentStates
    {
        Selected,
        Deselected
    }

    public bool selected;
    
    private NavMeshAgent agent;
    private StateMachine<AgentStates> stateMachine;

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new StateMachine<AgentStates>();
        stateMachine.AddState(AgentStates.Selected, OnEnter_Selected);
        stateMachine.AddState(AgentStates.Deselected, OnEnter_Deselected);
        
        stateMachine.Init();
    }

    protected virtual void OnEnter_Selected(StateBase<AgentStates> state) {
        
    }
    protected virtual void OnEnter_Deselected(StateBase<AgentStates> state) {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}