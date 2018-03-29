using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameManager gameManager;


    public void PearPower()
    {
        if (gameManager.playerOneTurn)
        {
            gameManager.card1.interactable = false;
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.card1.interactable = false;
        }
    }

    public void ApplePower()
    {
        if (gameManager.playerOneTurn)
        {
            gameManager.card2.interactable = false;
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.card2.interactable = false;
        }
    }

    public void BananaPower()
    {
        if (gameManager.playerOneTurn)
        {
            gameManager.InfoText.text = "Banana Power! Pick a card to shuffle the row";
            gameManager.powerUpMode = true;
            gameManager.bananaMode = true;
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.InfoText.text = "Banana Power! Pick a card to shuffle the row";
            gameManager.powerUpMode = true;
            gameManager.bananaMode = true;
        }
    }

    public void JamPower()
    {
        if (gameManager.playerOneTurn)
        {
            gameManager.p1Score++;
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.p2Score++;
        }
    }
}
