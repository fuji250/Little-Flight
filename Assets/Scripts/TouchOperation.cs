using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchOperation : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //スマホでも操作出来るようにするスクリプト

    private bool _isPushed = false; // マウスが押されているか押されていないか
    private Vector3 _nowMousePosi; // 現在のマウスのワールド座標

    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameState == "playing")
        {
            Vector3 nowmouseposi;
            Vector3 diffposi;

            // マウスが押下されている時、オブジェクトを動かす
            if (_isPushed) {
                // 現在のマウスのワールド座標を取得
                nowmouseposi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // 一つ前のマウス座標との差分を計算して変化量を取得
                diffposi = nowmouseposi - _nowMousePosi;

                //移動の方向に合わせてプレイヤーの角度を変更（今はうまくいってない）
                //直近100フレームの平均値とかをとっていけば上手く行くか、、？
                if(diffposi.y > 0.0f)
                {
                    player.transform.rotation = Quaternion.Euler( 0, 0, 10);
                }
                else if(diffposi.y < 0.0f)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, -10);
                }
                else if(diffposi.y == 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0);
                }

                diffposi.z = 0;
                // 開始時のオブジェクトの座標にマウスの変化量を足して新しい座標を設定
                GetComponent<Transform>().position += diffposi;
                // 現在のマウスのワールド座標を更新
                _nowMousePosi = nowmouseposi;
           }
        }

        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        // 押下開始　フラグを立てる
        _isPushed = true;
        // マウスのワールド座標を保存
        _nowMousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // 押下終了　フラグを落とす
        _isPushed = false;
        _nowMousePosi = Vector3.zero;
    }
}
