using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    float axisV = 0.0f;
    public float speed = 3.0f;

    public static string gameState = "playing";

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        gameState = "playing";
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState != "playing")
        {
            return;
        }

        axisH = Input.GetAxisRaw("Horizontal");
        axisV = Input.GetAxisRaw("Vertical");

        ////移動の方向に合わせてプレイヤーの角度を変更
        if(axisV > 0.0f)
        {
            transform.rotation = Quaternion.Euler( 0, 0, 10);
        }
        else if(axisV < 0.0f)
        {
            transform.rotation = Quaternion.Euler(0, 0, -10);

        }
        else if(axisV == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void FixedUpdate()
    {
        //GamOver演出
        if(gameState == "gameover")
        {
            Vector2 myGravity = new Vector2(0, -10);
            rbody.AddForce(myGravity);
        }
        //ゲームが終わると操作不能にするため
        if(gameState != "playing")
        {
            Debug.Log(gameState);
            return;
        }
        //移動
        rbody.velocity = new Vector2(speed * axisH,speed * axisV);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if(collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }

    public void Goal()
    {
        gameState = "gameclear";
        GameStop();
        //GameClear演出
        GetComponent<PolygonCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(4,0),ForceMode2D.Impulse);
    }

    public void GameOver()
    {
        gameState = "gameover";
        GameStop();
        //GameOver演出
        GetComponent<PolygonCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0,5),ForceMode2D.Impulse);
    }
    //移動を止める
    void GameStop()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(0,0);
    }
}
