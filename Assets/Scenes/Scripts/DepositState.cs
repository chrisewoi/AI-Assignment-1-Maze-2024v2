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

    public GameObject[] storageID;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
        storageID = GetComponent<Miner>().storageID;

        oreStorage = storageID[Miner.newZoneID];
    }

    // Update is called once per frame
    void Update()
    {
        if (Door1Lock.door1Complete && Miner.newZoneID == 0)
        {
            Miner.newZoneID = 1;
        }
    }

    public void OnEnter()
    {
        agent.destination = storageID[Miner.newZoneID].transform.position;
    }

    public void UpdateState()
    {
        if (Depositing())
        {
            agent.destination = transform.position;
        }
        else
        {
            agent.destination = storageID[Miner.newZoneID].transform.position;
        }
    }

    public void OnHurt()
    {
    }

    public void OnExit()
    {

    }

    public bool Depositing()
    {
        return Vector3.Distance(transform.position, storageID[Miner.newZoneID].transform.position) < depositDistance;
    }
}
