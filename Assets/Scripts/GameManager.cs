using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image titleImage; //画像を表示するImageコンポーネント

    float x = 0;
    float y = 0;
    float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 v3 = new Vector3(x,y,z);
        mainImage.GetComponent<Transform>().DOMove(v3, 1f).SetEase(Ease.InOutElastic);
        Invoke("InactiveImage",1.0f);
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.gameState == "gameclear")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button bt = restartButton.GetComponent<Button>();
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSpr;
            //PlayerController.gameState = "gameend";
        }
        else if(PlayerController.gameState == "gameover")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            Button bt = nextButton.GetComponent<Button>();
            bt.interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSpr;
            //PlayerController.gameState = "gameend";
        }
        else if(PlayerController.gameState == "playing")
        {

        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
