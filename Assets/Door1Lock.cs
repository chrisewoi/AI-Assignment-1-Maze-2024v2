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

    public GameObject doorEndPosition;

    public string progressString => (Mathf.Round(oreNeeded * 10) / 10).ToString();
    public TMP_Text ProgressText;
    public ParticleSystem ps_doorZap;
    public ParticleSystem ps_doorZap2;
    public ParticleSystem ps_doorOpened;

    public bool open_ps_destroyed;

    public static bool[] doorComplete;


    void Awake()
    {
        doorComplete = new bool[10];
    }

    // Start is called before the first frame update
    void Start()
    {
        doorUnlocked = false;
        ps_doorZap.enableEmission = false;
        ps_doorZap2.enableEmission = false;

        ps_doorOpened.enableEmission = false;

        oreNeededMax = oreNeeded;

        if (progressBar == null)
        {
            progressBar = new GameObject();
        }
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
            // Transfer faster over time, with each door also opening faster than the last
            float speed = (2f - (oreNeeded / oreNeededMax)) * (doorID+1);

            MineStorage.storedOre -= Time.deltaTime * speed;
            oreNeeded -= Time.deltaTime * speed;
            progressBar.transform.localScale = progressBar.transform.localScale -
                                               Vector3.one * ((1 - (oreNeeded / oreNeededMax)) * Time.deltaTime / 90f);
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

            ps_doorOpened.enableEmission = true;
            if (!open_ps_destroyed)
            {
                ps_doorOpened.Play();
                open_ps_destroyed = true;
            }

            OpenDoor();
            // Set door to complete so zone is moved up THIS IS WHERE ISSUE IS
            doorComplete[doorID] = true;
        }

        ProgressText.text = progressString;
    }

    void UnlockDoor()
    {
        doorUnlocked = true;
    }

    void OpenDoor()
    {
        if (doorID == 0)
        {
            progressBar.gameObject.SetActive(false);
            door.gameObject.transform.position = new Vector3(door.gameObject.transform.position.x,
                door.gameObject.transform.position.y - Time.deltaTime,
                door.gameObject.transform.position.z);
        }

        if (doorID == 1)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position,doorEndPosition.transform.position, Time.deltaTime);
            door.transform.eulerAngles = Vector3.RotateTowards(door.transform.eulerAngles, doorEndPosition.transform.eulerAngles,
                Time.deltaTime, Time.deltaTime);
        }

        if (doorID == 2)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position,doorEndPosition.transform.position, Time.deltaTime);
            RandomWalk.freedom = true;
        }
    }
}