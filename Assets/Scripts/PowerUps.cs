using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    public GameManager gameManager;
    public AssignPowerUp assignPowerUp;

    public void PearPower()
    {
        if (gameManager.playerOneTurn)
        {
            gameManager.card1.interactable = false;
            gameManager.card1.tag = "PearLock";
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.card1.interactable = false;
            gameManager.card1.tag = "PearLock";
        }
    }

    public void ApplePower()
    {
        if (gameManager.playerOneTurn)
        {
            gameManager.card2.interactable = false;
            gameManager.card2.tag = "AppleLock";
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.card2.interactable = false;
            gameManager.card2.tag = "AppleLock";
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

    public IEnumerator PineapplePower()
    {
        //Wait until card is Selected
        yield return new WaitUntil(() => gameManager.cardSpecial != null);

        Button cardSpecial = gameManager.cardSpecial;
        string[] wordList = gameManager.wordList;

        string bombTarget = cardSpecial.GetComponentInChildren<Text>().text;

        for (int t = 0; t < wordList.Length; t++)
        {
            if (wordList[t] != null)
            {
                if (wordList[t] == bombTarget)
                {
                    wordList[t] = "Onion";
                }
            }
        }

        //Reassign card values
        gameManager.AssignCardValues();

        //Reset Values
        gameManager.powerUpMode = false;
        gameManager.pineappleMode = false;
        cardSpecial = null;

        //Remove Pineapple Power
        assignPowerUp.pineapplePower = 0;

        yield return 0;
        }

   
    public void StrawberryPower()
    {
        gameManager.InfoText.text = "Strawberry Power! Use the button to reveal a card";
        gameManager.strawberryPowerButton.interactable = true;
    }

    public void OnionPower()
    {
        gameManager.InfoText.text = "Onion Power! Lose two points, ouch.";
        if (gameManager.playerOneTurn)
        {
            gameManager.p1Score--;
            gameManager.p1Score--;
        }
        else if (!gameManager.playerOneTurn)
        {
            gameManager.InfoText.text = "Onion Power! Lose two points, ouch.";
            gameManager.p2Score--;
            gameManager.p2Score--;
        }
    }


}
