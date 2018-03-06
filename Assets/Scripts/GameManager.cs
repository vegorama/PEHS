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

    private int redScore;
    private int blueScore;

    [Header("Game Text")]
    [SerializeField]
    private Text InfoText;
    [SerializeField]
    private Text redScoreText;
    [SerializeField]
    private Text blueScoreText;

    [Header("Button Lists")]
    [SerializeField]
    private GameObject[] buttonList;
    [SerializeField]
    private string[] wordList;
    [SerializeField]
    private Sprite[] fruitImageList;

    public string PlayerSide;
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
        wordList = new string[] { "Pehs", "Pehs", "Apel", "Apel", "Oring", "Oring", "Cocnot", "Cocnot", "Raspsbsbry", "Raspsbsbry", "Plum", "Plum", "Bonoona", "Bonoona", "Grep", "Grep" };

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
            if (buttonList[t].GetComponentInChildren<Text>().text == "Pehs")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[0];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Apel")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[1];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Oring")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[2];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Cocnot")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[3];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Raspsbsbry")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[4];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Plum")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[5];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Bonoona")
            {
                buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[6];
            }
            else if (buttonList[t].GetComponentInChildren<Text>().text == "Grep")
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

                NextPlayer();
                UpdateText();
            }
        }
    }

    private void NextPlayer()
    {
        if (PlayerSide == string.Empty)
        {
            PlayerSide = "RED";
        }
        else if (PlayerSide == "BLUE")
        {
            PlayerSide = "RED";
        }
        else if (PlayerSide == "RED")
        {
            PlayerSide = "BLUE";
        }

        Debug.Log("<color=blue>PlayerSide:</color>" + PlayerSide);
    }

    private void UpdateText()
    {
        InfoText.text = "It is " + PlayerSide + "'s turn";
        redScoreText.text = "RED Score: " + redScore.ToString();
        blueScoreText.text = "BLUE Score: " + blueScore.ToString();
    }

    private void AwardPoint()
    {
        if (PlayerSide == "RED")
        {
            redScore++;
        }
        else if (PlayerSide == "BLUE")
        {
            blueScore++;
        }
    }

}
