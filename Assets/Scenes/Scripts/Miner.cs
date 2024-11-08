using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityHFSM;
[System.Serializable]
public class Miner : MonoBehaviour
{
    public StateMachine minerStateMachine;
    public float storageCapacity;
    public float amountHolding;
    public MineState mineState;
    public DepositState depositState;
    public GameObject storage;
    public GameObject progressBar;
    public GameObject progressBG;
    public string progressString => Mathf.Round(amountHolding).ToString();
    public TMP_Text ProgressText;

    public ParticleSystem PS_Mining;

    [SerializeField] public GameObject[] storageID;
    public static int newZoneID;

    

    // Start is called before the first frame update
    void Awake()
    {
        mineState = gameObject.GetComponent<MineState>();
        depositState = GetComponent<DepositState>();
        minerStateMachine = GetComponent<StateMachine>();
        minerStateMachine.ChangeState(mineState);
        PS_Mining = GetComponentInChildren<ParticleSystem>();
        if(PS_Mining != null)
            PS_Mining.enableEmission = false;
        newZoneID = 0;
        
        // Sets default storage to the first one
        storage = storageID[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(newZoneID);
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
            bool temp = true;
            PS_Mining.enableEmission = true;
        }
        else
        {
            PS_Mining.enableEmission = false;
        }
        if (depositState.Depositing() && amountHolding > 0)
        {
            amountHolding -= Time.deltaTime;
            MineStorage.storedOre += Time.deltaTime;
        }
        amountHolding = Mathf.Clamp(amountHolding, 0f, storageCapacity);

        progressBar.transform.localScale = new Vector3(amountHolding/storageCapacity,1,1);
        ProgressText.text = progressString;


        if (amountHolding == 0)
        {
            progressBG.gameObject.SetActive(false);
        }
        else
        {
            progressBG.gameObject.SetActive(true);
        }
    }
}
