using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MineState : MonoBehaviour, IState
{
    public NavMeshAgent agent;
    [SerializeField] public GameObject ore;
    [SerializeField] public float mineDistance;
    public bool mining;
    
    public static List<GameObject> mineRocks;
    public static List<GameObject> availableMineRocks;


    public void Start()
    {
        availableMineRocks = new();
        UpdateAvailableMineRocks();
    }

    public void OnEnter()
    {
        GameObject selectedOreToMine;
        if(ore != null)
            agent.destination = ore.transform.position;
    }

    public void Update()
    {
        canMine();
    }
    public void UpdateState()
    {
        if (!canMine())
        {
            UpdateDestination();
        }
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

    public void UpdateAvailableMineRocks()
    {
        availableMineRocks.Clear();
        
        // adds mineRocks from scene
        foreach (GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            if (go.name.Contains("MineRock") && go.GetComponent<MineRockZoneID>().zoneID == Miner.newZoneID)
            {
                availableMineRocks.Add(go);
            }
        }
    }

    public void UpdateDestination()
    {
        UpdateAvailableMineRocks();
        int randomDestination = Random.Range(0, availableMineRocks.Count);
        ore = availableMineRocks[randomDestination];
        agent.destination = ore.transform.position;
    }
}
