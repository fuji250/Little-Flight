using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallGimmick : MonoBehaviour
{
    public float length = 0.0f;
    public bool isDelete = false;

    bool isFell = false;
    float fadeTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //物理挙動停止
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            float d = Vector2.Distance(transform.position,player.transform.position);
            if(length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if(rbody.bodyType == RigidbodyType2D.Static)
                {
                    transform.DOPunchPosition(punch: new Vector3(0.3f, 0f, 0f),duration: 1.5f, vibrato: 4);
                    //transform.DOShakePosition(1.5f, 0.3f, 5, 0, false, true);
                    //落ちる
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
        if (isFell)
        {
            //フェードアウトして消滅
            fadeTime -= Time.deltaTime;
            Color col = GetComponent<SpriteRenderer>().color;
            col.a = fadeTime;
            GetComponent<SpriteRenderer>().color = col;
            if(fadeTime <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            isFell = true;
        }
    }
}
