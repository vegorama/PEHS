using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public Button card1;
    public Button card2;
    public string cardText1;
    public string cardText2;

    private int p1Score;
    private int p2Score;

    [Header("Game Text")]
    [SerializeField]
    private Text InfoText;
    [SerializeField]
    private Text p1ScoreText;
    [SerializeField]
    private Text p2ScoreText;

    [Header("Button Lists")]
    [SerializeField]
    private GameObject[] buttonList;
    [SerializeField]
    private string[] wordList;
    [SerializeField]
    private Sprite[] fruitImageList;

    public bool playerOneTurn;
    public int NumberOfPlayers;


    // Use this for initialization
    public void Start()
    {
        RandomiseCards();
        AssignCardValues();
        NextPlayer();
        UpdateText();
    }

    void RandomiseCards()
    {
        wordList = new string[] { "Pears", "Pears", "Apple", "Apple", "Banana", "Banana", "Cherry", "Cherry", "Pineapple", "Pineapple", "Strawberry", "Strawberry", "Watermelon", "Watermelon", "Jam", "Jam" };

        // Knuth shuffle algorithm
        for (int t = 0; t < wordList.Length; t++)
        {
            string tmp = wordList[t];
            int r = Random.Range(t, wordList.Length);
            wordList[t] = wordList[r];
            wordList[r] = tmp;
        }
    }

    void AssignCardValues()
    {
        //Assign text
        for (int t = 0; t < buttonList.Length; t++)
        {
            buttonList[t].GetComponentInChildren<Text>().text = wordList[t];
        }

        //Assign Sprites
        for (int t = 0; t < buttonList.Length; t++)
        {
            if (buttonList[t].GetComponentInChildren<Text>().text == "Pears")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[0];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Apple")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[1];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Banana")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[2];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Cherry")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[3];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Pineapple")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[4];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Strawberry")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[5];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Watermelon")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[6];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Jam")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[7];
            }
        }
    }

    public IEnumerator CardCheck()
    {
        Debug.Log("<color=yellow>CardCheck being called!!!!:</color>");

        if ((cardText1 != string.Empty) && (cardText1 != string.Empty))
        {
            if (cardText1 == cardText2)
            {
                yield return new WaitForSeconds(1f);

                Destroy(card1.gameObject);
                Destroy(card2.gameObject);

                cardText1 = string.Empty;
                cardText2 = string.Empty;
                card1 = null;
                card1 = null;

                //GivePowerUp(cardText1);

                AwardPoint();
                UpdateText();
            }
            else
            {
                yield return new WaitForSeconds(1.5f);

                card1.GetComponent<ButtonScript>().HideText();
                card2.GetComponent<ButtonScript>().HideText();

                cardText1 = string.Empty;
                cardText2 = string.Empty;
                card1 = null;
                card1 = null;

                //CheckPowerUps;

                NextPlayer();
                UpdateText();
            }
        }
    }

    private void NextPlayer()
    {
        if (playerOneTurn == false)
        {
            playerOneTurn = true;
        }

        else if (playerOneTurn == true)
        {
            playerOneTurn = false;
        }

        Debug.Log("<color=blue>Human Players Turn? -</color>" + playerOneTurn);
    }

    private void UpdateText()
    {
        if (playerOneTurn == true)
        {
            InfoText.text = "It's Your Turn";
        }
        else if (playerOneTurn == false)
        {
            InfoText.text = "Evil Robot Computer Player's Turn";
        }

        p1ScoreText.text = "Your Score: " + p1Score.ToString();
        p2ScoreText.text = "Enemy Score: " + p2Score.ToString();
    }

    private void AwardPoint()
    {
        if (playerOneTurn == true)
        {
            p1Score++;
        }
        else if (playerOneTurn == false)
        {
            p2Score++;
        }
    }


}
