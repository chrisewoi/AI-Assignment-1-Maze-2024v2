using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MineStorage : MonoBehaviour
{
    [SerializeField] public static float storedOre;
    public GameObject progressBar;
    public GameObject progressBG;
    
    public string progressString => Mathf.Round(storedOre).ToString();
    public TMP_Text ProgressText;

    // Start is called before the first frame update
    void Start()
    {
        storedOre = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ProgressText.text = progressString;
    }

    public void AddOre(float amount)
    {
        storedOre += amount;
    }
    public void AddOre()
    {
        storedOre ++;
    }
}
