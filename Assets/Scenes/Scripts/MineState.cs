using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MineState : MonoBehaviour, IState
{
    public NavMeshAgent agent;
    [SerializeField] public GameObject ore;
    [SerializeField] public float mineDistance;
    public bool mining;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMine())
        {
            
        }
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

    public float DistanceTo(GameObject gameObject)
    {
        return Vector3.Distance(transform.position, ore.transform.position);
    }

    public bool canMine()
    {
        if (DistanceTo(ore) < mineDistance)
        {
            mining = true;
        }
        else
        {
            mining = false;
        }

        return mining;
    }
}
