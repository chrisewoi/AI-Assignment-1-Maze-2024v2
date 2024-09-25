using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    static int position;
    [SerializeField] public int positionView; //=> position;
    public GameObject[] positions;
    public float transitionTime;
    public float transitionDelta;
    public float timer;
    public bool triggerTransition;

    public Vector3 myPosition;
    public Vector3 destination;

    public Quaternion myRotation;
    public Quaternion destinationRotation;

    public float transitionDelay;
    
    // positions
    void Start()
    {
        position = 1;
        myPosition = transform.position;
        myRotation = transform.rotation;
        transitionDelta = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        positionView = position;
        if (Door1Lock.door1Complete && position < 2)
        {
            Invoke("UpdatePosition2", transitionDelay);
            
        }

        if (position > 1)
        {
            transform.position = positions[position].gameObject.transform.position;
            transform.rotation = positions[position].gameObject.transform.rotation;
            destination = positions[position].gameObject.transform.position;
            destinationRotation = positions[position].gameObject.transform.rotation;
        }

        transform.position = Vector3.Lerp(myPosition, destination, transitionDelta / transitionTime);
        transform.rotation = Quaternion.Lerp(myRotation, destinationRotation, transitionDelta / transitionTime);
        
        if(triggerTransition) transitionDelta += Time.deltaTime;
        if (transitionDelta > transitionTime) triggerTransition = false;
        timer += Time.deltaTime;
    }

    void UpdatePosition(int newPosition)
    {
        position = newPosition;
        triggerTransition = true;
    }

    // Because Invoke can't pass parameters
    void UpdatePosition2()
    {
        UpdatePosition(2);
    }
    void UpdatePosition3()
    {
        UpdatePosition(3);
    }
    void UpdatePosition4()
    {
        UpdatePosition(4);
    }
}
