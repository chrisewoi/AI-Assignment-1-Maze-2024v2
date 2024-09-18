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

    public void OnEnter()
    {
        agent.destination = ore.transform.position;
    }

    public void UpdateState()
    {
        canMine();
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
