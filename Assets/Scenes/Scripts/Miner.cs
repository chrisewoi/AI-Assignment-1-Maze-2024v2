using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    private StateMachine minerStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        minerStateMachine.ChangeState(MineState);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
