using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRandom : MonoBehaviour
{
    //public float jumpHeight;

    public float maxWait;
    public float wait;

    public float floorPos;

    public float gravity;

    public float timer;
    public float jumpPos;
    public float velocity;

    public bool grounded => isGrounded();
    // Start is called before the first frame update
    void Start()
    {
        floorPos = gameObject.transform.position.y;
        gravity = 10f;
        maxWait = 2;
        timer = 0;
        jumpPos = 0;
        velocity = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded())
        {
            timer = 0;
            wait = Random.value * maxWait;
            Jump();
        }
        else // if Grounded
        {

            if (timer > wait)
            {
                
                velocity = 3.5f;
                velocity += Random.value * 2 - 1f;
                jumpPos = 0;
                Jump();
            }
            
            timer += Time.deltaTime;
        }
    }

    public bool isGrounded()
    {
        return gameObject.transform.position.y <= floorPos;
    }

    public void Jump()
    {
        jumpPos += velocity * Time.deltaTime;
        velocity -= gravity * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,floorPos + jumpPos, gameObject.transform.position.z);
    }
}
