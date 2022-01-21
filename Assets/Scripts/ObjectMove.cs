using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public PlayerController playerController;

    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;

    public float ForceScrollSpeedX = 1.0f;

    public GameObject subscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        x = transform.position.x - (ForceScrollSpeedX * Time.deltaTime); 

        if(x <= leftLimit)
        {
            playerController.Goal();
        }
        if(x < leftLimit)
        {
            x = leftLimit;
        }
        else if(x > rightLimit)
        {
            x = rightLimit;
        }
        Vector3 v3 = new Vector3(x,y,z);
        transform.position = v3;

        if(subscreen != null)
        {
            y = subscreen.transform.position.y;
            z = subscreen.transform.position.z;
            Vector3 v = new Vector3(x / 2.0f +19.8f,y,z);
            subscreen.transform.position = v;
        }
    }
}
