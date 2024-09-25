using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Door1Lock : MonoBehaviour
{
    public GameObject storage;

    public float oreNeeded;
    private float oreNeededMax;
    public bool doorUnlocked;
    public GameObject progressBar;
    public GameObject door;
    public int doorID;
    
    public string progressString => (Mathf.Round(oreNeeded*10)/10).ToString();
    public TMP_Text ProgressText;
    public ParticleSystem ps_doorZap;
    public ParticleSystem ps_doorZap2;
    public ParticleSystem ps_doorOpened;

    public bool open_ps_destroyed;

    public static bool door1Complete;
    
    // Start is called before the first frame update
    void Start()
    {
        doorUnlocked = false;
        ps_doorZap.enableEmission = false;
        ps_doorZap2.enableEmission = false;
        
        ps_doorOpened.enableEmission = false;
        

        oreNeededMax = oreNeeded;
    }

    // Update is called once per frame
    void Update()
    {
        // Only visible when active zone door
        if (doorID == Miner.newZoneID)
        {
            progressBar.SetActive(true);
        }
        else
        {
            progressBar.SetActive(false);
        }
        
        
        if (MineStorage.storedOre >= oreNeeded && !doorUnlocked)
        {
            UnlockDoor();
        }

        if (doorUnlocked && oreNeeded > 0)
        {
            // Transfer faster over time
            float speed = 2f - (oreNeeded/oreNeededMax);
            //Debug.Log("Speed: " + speed);
            
            MineStorage.storedOre -= Time.deltaTime * speed;
            oreNeeded -= Time.deltaTime * speed;
            progressBar.transform.localScale = progressBar.transform.localScale  - Vector3.one * ((1 - (oreNeeded / oreNeededMax)) * Time.deltaTime/90f);
            ps_doorZap.enableEmission = true;
            ps_doorZap2.enableEmission = true;
        }

        if (oreNeeded <= 6 && doorUnlocked)
        {
            // it takes a while to stop, so stop early
            ps_doorZap2.enableEmission = false;
        }

        if (oreNeeded <= 0)
        {
            ps_doorZap.enableEmission = false;
            //ps_doorOpened.enableEmission = true;
            //ps_doorOpened.Play();
            ps_doorOpened.enableEmission = true;
            ps_doorOpened.Play();
            if (!open_ps_destroyed)
            {
                Invoke("DestroyPS_DoorOpened", 3);
                open_ps_destroyed = true;
            }

            progressBar.gameObject.SetActive(false);
            door.gameObject.transform.position = new Vector3(door.gameObject.transform.position.x,
                                                            door.gameObject.transform.position.y-Time.deltaTime,
                                                            door.gameObject.transform.position.z);
            door1Complete = true;
        }
        
        ProgressText.text = progressString;
    }

    void UnlockDoor()
    {
        doorUnlocked = true;
    }

    void DestroyPS_DoorOpened()
    {
        ps_doorOpened.gameObject.transform.position = new Vector3(1000, 1000, 1000);
        Destroy(ps_doorOpened.gameObject);
    }
}
