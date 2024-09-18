using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DepositState : MonoBehaviour
{
    [SerializeField] public GameObject storage;
    public NavMeshAgent agent;

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
        agent.destination = storage.transform.position;
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
