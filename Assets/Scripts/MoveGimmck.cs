using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGimmck : MonoBehaviour
{
    //ギミック発動させるプレイヤーとの距離
    public float length = 0.0f;
    public bool isDelete = false;

    bool isMove = false;
    public float speed = -1f;

    float x = 0;
    float y = 0;
    float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
            float d = Vector2.Distance(transform.position,player.transform.position);

            if(length >= d)
            {
                Debug.Log("!!!!!!!");
                x = transform.position.x - (speed * Time.deltaTime);
                isMove = true;
            Vector3 v3 = new Vector3(x,y,z);
        transform.position = v3;
            }
            if (isMove || length < d)
            {
                //消滅
                //Destroy(gameObject);
            }
        
    }
}
