using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent))]
public class RandomWalk : MonoBehaviour
{
    public float _Range = 1.0f;
    private NavMeshAgent _Agent;
    public static bool freedom;
    public float timer;
    public float timeToSwitchBehaviour;
    public bool attacking;
    public bool attacked;

    public GameObject target;

    //public StateMachine stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();
        freedom = false;
        timer = 0;
        attacking = false;
        attacked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Agent.pathPending || !_Agent.isOnNavMesh || _Agent.remainingDistance > 0.1f)
        {
            return;
        }
        
        //RandomDestination();

        if (timer > timeToSwitchBehaviour)
        {
            timer = 0;
            attacking = !attacking;
            attacked = false;
        }
        if (freedom && !attacked)
        {
            if (attacking)
            {
                _Agent.destination = target.transform.position;
            }
            else
            {
                RandomDestination();
            }

            attacked = true;
        }
        
        timer += Time.deltaTime;
    }

    void RandomDestination()
    {
        Vector3 randomPosition = _Range * Random.insideUnitCircle;
        randomPosition = new Vector3(randomPosition.x, 0, randomPosition.y);
        _Agent.destination = transform.position + randomPosition;
    }
}
