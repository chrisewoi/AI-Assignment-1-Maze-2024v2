using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DepositState : MonoBehaviour, IState
{
    [SerializeField] public GameObject storage;
    public NavMeshAgent agent;
    [SerializeField] public float depositDistance;
    public GameObject oreStorage;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
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
        if (Depositing())
        {
            agent.destination = transform.position;
        }
        else
        {
            agent.destination = storage.transform.position;
        }
    }

    public void OnHurt()
    {
    }

    public void OnExit()
    {
        //agent.speed = speed;
    }

    public bool Depositing()
    {
        return Vector3.Distance(transform.position, storage.transform.position) < depositDistance;
    }
}
