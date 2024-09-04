using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



[RequireComponent(typeof(NavMeshAgent))]
public class RandomWalk : MonoBehaviour
{
    public float _Range = 25.0f;
    private NavMeshAgent _Agent;

    // Start is called before the first frame update
    void Start()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Agent.pathPending || !_Agent.isOnNavMesh || _Agent.remainingDistance > 0.1f)
        {
            return;
        }

        Vector3 randomPosition = _Range * Random.insideUnitCircle;
        randomPosition = new Vector3(randomPosition.x, 0, randomPosition.y);
        _Agent.destination = transform.position + randomPosition;
    }
}
