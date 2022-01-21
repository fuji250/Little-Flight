using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGimmck : MonoBehaviour
{
    //右から左に移動させる障害物のスクリプト（鳥や車など）
    //プレイヤーが近づいたら移動始める

    public float length = 0.0f;//ギミック発動させるプレイヤーとの距離

    bool isMove = false;//移動したかどうか
    public float speed = -1f;

    float x = 0,y=0,z=0;

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
        //障害物とプレイヤーとの距離
        float d = Vector2.Distance(transform.position, player.transform.position);

        if (length >= d)
        {
            x = transform.position.x - (speed * Time.deltaTime);
            isMove = true;
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
        //通り過ぎると消滅
        if (isMove && length < d)
        {
            Destroy(gameObject);
        }

    }
}
