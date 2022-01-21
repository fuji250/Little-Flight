using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    //障害物を右から左に動かすスクリプト

    public PlayerController playerController;
    public float length = 78f;//ステージの長さ
    public float ForceScrollSpeedX = 1.0f;
    
    public GameObject subscreen;//背景の山など


    // Start is called before the first frame update
    void Start()
    {
        length *= -1; 
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0,y = 0,z = 0;
       
        //移動
        x = transform.position.x - (ForceScrollSpeedX * Time.deltaTime); 

        if(x <= length)
        {
            //leftLimitまで移動し終わるとゴール
            playerController.Goal();
            x = length;
        }
        Vector3 v3 = new Vector3(x,y,z);
        transform.position = v3;

        if(subscreen != null)
        {
            y = subscreen.transform.position.y;
            z = subscreen.transform.position.z;
            Vector3 v = new Vector3(x / 2.0f ,y,z);
            subscreen.transform.position = v;
        }
    }
}
