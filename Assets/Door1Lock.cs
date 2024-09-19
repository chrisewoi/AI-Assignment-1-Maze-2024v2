using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door1Lock : MonoBehaviour
{
    public GameObject storage;

    public float oreNeeded;
    public bool doorUnlocked;
    public GameObject progressBar;
    public GameObject door;
    
    public string progressString => (Mathf.Round(oreNeeded*10)/10).ToString();
    public TMP_Text ProgressText;
    public ParticleSystem ps_doorZap;
    public ParticleSystem ps_doorZap2;
    
    // Start is called before the first frame update
    void Start()
    {
        doorUnlocked = false;
        ps_doorZap.enableEmission = false;
        ps_doorZap2.enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MineStorage.storedOre >= oreNeeded && !doorUnlocked)
        {
            //MineStorage.storedOre -= oreNeeded;
            UnlockDoor();
        }

        if (doorUnlocked && oreNeeded > 0)
        {
            float speed = 1f;
            MineStorage.storedOre -= Time.deltaTime * speed;
            oreNeeded -= Time.deltaTime * speed;
            ps_doorZap.enableEmission = true;
            ps_doorZap2.enableEmission = true;
        }

        if (oreNeeded <= 3 && doorUnlocked)
        {
            // it takes a while to stop
            ps_doorZap2.enableEmission = false;
        }

        if (oreNeeded <= 0)
        {
            ps_doorZap.enableEmission = false;
            progressBar.gameObject.SetActive(false);
            door.gameObject.transform.position = new Vector3(door.gameObject.transform.position.x,
                                                            door.gameObject.transform.position.y-Time.deltaTime,
                                                            door.gameObject.transform.position.z);
        }
        
        ProgressText.text = progressString;
    }

    void UnlockDoor()
    {
        doorUnlocked = true;
    }
}
