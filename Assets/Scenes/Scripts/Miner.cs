using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityHFSM;

public class Miner : MonoBehaviour
{
    public StateMachine minerStateMachine;
    public float storageCapacity;
    public float amountHolding;
    public MineState mineState;
    public DepositState depositState;
    public GameObject storage;

    // Start is called before the first frame update
    void Awake()
    {
        mineState = gameObject.GetComponent<MineState>();
        depositState = GetComponent<DepositState>();
        minerStateMachine = GetComponent<StateMachine>();
        minerStateMachine.ChangeState(mineState);
    }

    // Update is called once per frame
    void Update()
    {
        if (amountHolding >= storageCapacity)
        {
            minerStateMachine.ChangeState(depositState);
        }

        if (amountHolding <= 0)
        {
            minerStateMachine.ChangeState(mineState);
        }


        if (mineState.mining)
        {
            amountHolding += Time.deltaTime;
        }
        Debug.Log("Distance to storage: " + Vector3.Distance(transform.position, storage.transform.position));
        if (depositState.Depositing())
        {
            amountHolding -= Time.deltaTime;
        }
        amountHolding = Mathf.Clamp(amountHolding, 0f, storageCapacity);
    }
}
