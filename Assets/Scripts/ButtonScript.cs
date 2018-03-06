using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    GameObject GameManagerRef;
    GameManager gameManager;
    public Button button;
    public GameObject cardImage;
    Text buttonText;
    

    // Use this for initialization
    void Start ()
    { 
        GameManagerRef = GameObject.Find("GameManager");

        gameManager = GameManagerRef.GetComponent<GameManager>();

        buttonText = button.GetComponentInChildren<Text>();

        HideText();
    }

    public void HideText()
    {
        buttonText.color = new Color(0, 0, 0, 0);
        cardImage.SetActive(false);
    }

    private void ShowCard()
    {
        buttonText.color = new Color(0, 0, 0, 1);
        cardImage.SetActive(true);
    }

    public void FlipClick()
    {
        if (gameManager.cardText1 == "")
        {
            gameManager.card1 = button;
            gameManager.cardText1 = button.GetComponentInChildren<Text>().text;

            ShowCard();

            Debug.Log("<color=red>cardText1:</color>" + gameManager.cardText1);
            Debug.Log("<color=red>card1:</color>" + button);
        }
        else if (gameManager.cardText2 == "")
        {
            gameManager.card2 = button;
            gameManager.cardText2 = button.GetComponentInChildren<Text>().text;

            button.GetComponentInChildren<Text>().enabled = true;

            Debug.Log("<color=red>cardText2:</color>" + gameManager.cardText2);
            Debug.Log("<color=red>card2:</color>" + button);

            ShowCard();

            StartCoroutine(gameManager.CardCheck());
        }

    }


}
