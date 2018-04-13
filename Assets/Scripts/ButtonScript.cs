using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    [Header("References")]
    GameObject GameManagerRef;
    GameManager gameManager;
    PowerUps powerUps;

    [Header("Show Picks")]
    public bool p1Picked;
    public bool p2Picked;

    [Header("Settings")]
    public int rowNum;
    public Button button;
    public GameObject cardImage;
    Text buttonText;
    

    // Use this for initialization
    void Start ()
    { 
        GameManagerRef = GameObject.Find("GameManager");
        gameManager = GameManagerRef.GetComponent<GameManager>();
        powerUps = GameManagerRef.GetComponent<PowerUps>();

        buttonText = button.GetComponentInChildren<Text>();
        HideCard();
    }

    public void CardBackReset(bool playerOneTurn)
    {
        if (playerOneTurn && p1Picked)
        {
            button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            p1Picked = false;
        }
        else if (!playerOneTurn && p2Picked)
        {
            button.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            p2Picked = false;
        }
    }

    public void CardBackColour()
    {
        buttonText.color = new Color(0, 0, 0, 0);
        cardImage.SetActive(false);

        if (gameManager.playerOneTurn)
        {
            button.GetComponent<Image>().color = new Color(0, 0, 1, 1);
            p1Picked = true;
        }
        else if (!gameManager.playerOneTurn)
        {
            button.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            p2Picked = true;
        }
    }

    public void HideCard()
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
        if (gameManager.powerUpMode)
        {
            if (gameManager.bananaMode)
            {
                gameManager.cardSpecial = button;
            }
            else if (gameManager.pineappleMode)
            {
                gameManager.cardSpecial = button;
            }
        }

        else if (!gameManager.powerUpMode)
        {   
            //Flip cards
            if (gameManager.cardText1 == "")
            {
                gameManager.card1 = button;
                gameManager.cardText1 = button.GetComponentInChildren<Text>().text;

                ShowCard();
            }
            else if (gameManager.cardText2 == "")
            {
                gameManager.card2 = button;

                if (gameManager.card1 == gameManager.card2)
                {
                    //Do nothing
                    gameManager.card2 = null;
                }
                else
                {           
                    gameManager.cardText2 = button.GetComponentInChildren<Text>().text;

                    button.GetComponentInChildren<Text>().enabled = true;

                    ShowCard();

                    StartCoroutine(gameManager.CardCheck());
                }
            }
        }

    }


}
