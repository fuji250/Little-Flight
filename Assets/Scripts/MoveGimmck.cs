using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGimmck : MonoBehaviour
{
    //�E���獶�Ɉړ��������Q���̃X�N���v�g�i����ԂȂǁj
    //�v���C���[���߂Â�����ړ��n�߂�

    public float length = 0.0f;//�M�~�b�N����������v���C���[�Ƃ̋���

    bool isMove = false;//�ړ��������ǂ���
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
        //��Q���ƃv���C���[�Ƃ̋���
        float d = Vector2.Distance(transform.position, player.transform.position);

        if (length >= d)
        {
            x = transform.position.x - (speed * Time.deltaTime);
            isMove = true;
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
        //�ʂ�߂���Ə���
        if (isMove && length < d)
        {
            Destroy(gameObject);
        }

    }
}
