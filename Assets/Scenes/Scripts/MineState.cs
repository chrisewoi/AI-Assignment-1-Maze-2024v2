using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MineState : MonoBehaviour, IState
{
    public NavMeshAgent agent;
    [SerializeField] public GameObject ore;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnter()
    {
        agent.destination = ore.transform.position;
    }

    public void UpdateState()
    {
    }

    public void OnHurt()
    {
    }

    public void OnExit()
    {
    }
}
