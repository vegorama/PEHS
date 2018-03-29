using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Variables")]
    public Button card1;
    public Button card2;
    public Button cardSpecial;
    public string cardText1;
    public string cardText2;

    public int p1Score;
    public int p2Score;

    [Header("Game Text")]
    public Text InfoText;
    [SerializeField]
    private Text p1ScoreText;
    [SerializeField]
    private Text p2ScoreText;

    [Header("Button Lists")]
    public GameObject[] buttonList;
    [SerializeField]
    private string[] wordList;
    [SerializeField]
    private Sprite[] fruitImageList;

    [Header("Power Ups")]
    public AssignPowerUp assignPowerUp;
    public bool powerUpMode;
    public bool bananaMode;
    public bool pineappleMode;


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
        wordList = new string[] { "Pear", "Pear", "Apple", "Apple", "Banana", "Banana", "Cherry", "Cherry", "Pineapple", "Pineapple", "Strawberry", "Strawberry", "Watermelon", "Watermelon", "Jam", "Jam" };

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
            if (buttonList[t].GetComponentInChildren<Text>().text == "Pear")
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

                assignPowerUp.GivePower(cardText1);

                Destroy(card1.gameObject);
                Destroy(card2.gameObject);

                cardText1 = string.Empty;
                cardText2 = string.Empty;
                card1 = null;
                card2 = null;

                AwardPoint();
                UpdateText();
            }
            else
            {
                assignPowerUp.CheckPower(playerOneTurn);

                yield return new WaitForSeconds(1.5f);

                card1.GetComponent<ButtonScript>().HideText();
                card2.GetComponent<ButtonScript>().HideText();

                cardText1 = string.Empty;
                cardText2 = string.Empty;
                card1 = null;
                card2 = null;

                if (bananaMode == true)
                {
                    yield return StartCoroutine( BananaShuffle() );
                }
            

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

    private IEnumerator BananaShuffle()
    {
        Debug.Log("<color=yellow>Banana Shuffle Coroutine called </color>");

        //Wait until card is Selected
        yield return new WaitUntil ( () => cardSpecial != null);

        //Make new string
        string[] rowToShuffle = { "", "", "", "" };

        //Row being shuffled
        int rowShuffled = 0;

        if (cardSpecial == buttonList[0].GetComponentInChildren<Button>() ||
            cardSpecial == buttonList[1].GetComponentInChildren<Button>() ||
            cardSpecial == buttonList[2].GetComponentInChildren<Button>() ||
            cardSpecial == buttonList[3].GetComponentInChildren<Button>())
        {
            //Loop through remaining buttons, adding them to array.
            for (int t = 0; t < 4; t++)
            {
                if (buttonList[t] != null)
                {
                    rowToShuffle[t] = buttonList[t].GetComponentInChildren<Text>().text;
                }
            }

            rowShuffled = 1;
            Debug.Log("<color=green>cardSpecial </color>" + cardSpecial + " rowShuffled " + rowShuffled);

        }
        else if (cardSpecial == buttonList[4].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[5].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[6].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[7].GetComponentInChildren<Button>())
        {
            rowToShuffle = new string[] { buttonList[4].GetComponentInChildren<Text>().text, buttonList[5].GetComponentInChildren<Text>().text, buttonList[6].GetComponentInChildren<Text>().text, buttonList[7].GetComponentInChildren<Text>().text };
            rowShuffled = 2;
            Debug.Log("<color=green>cardSpecial </color>" + cardSpecial + " rowShuffled " + rowShuffled);
        }
        else if (cardSpecial == buttonList[8].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[9].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[10].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[11].GetComponentInChildren<Button>())
        {
            rowToShuffle = new string[] { buttonList[8].GetComponentInChildren<Text>().text, buttonList[9].GetComponentInChildren<Text>().text, buttonList[10].GetComponentInChildren<Text>().text, buttonList[11].GetComponentInChildren<Text>().text };
            rowShuffled = 3;
            Debug.Log("<color=green>cardSpecial </color>" + cardSpecial + " rowShuffled " + rowShuffled);
        }
        else if (cardSpecial == buttonList[12].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[13].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[14].GetComponentInChildren<Button>() ||
                 cardSpecial == buttonList[15].GetComponentInChildren<Button>())
        {
            rowToShuffle = new string[] { buttonList[12].GetComponentInChildren<Text>().text, buttonList[13].GetComponentInChildren<Text>().text, buttonList[14].GetComponentInChildren<Text>().text, buttonList[15].GetComponentInChildren<Text>().text };
            rowShuffled = 4;
            Debug.Log("<color=green>cardSpecial </color>" + cardSpecial + " rowShuffled " + rowShuffled);
        }

        //Make a list from array to remove empty objects
        //TODO isn't working
        List<string> rowToShuffList = new List<string>(rowToShuffle);
        rowToShuffList.RemoveAll(p => string.IsNullOrEmpty(p));
        rowToShuffle = rowToShuffList.ToArray();

        //Shuffle Row
        for (int t = 0; t < rowToShuffle.Length; t++)
        {
            string tmp = rowToShuffle[t];
            int r = Random.Range(t, rowToShuffle.Length);
            rowToShuffle[t] = rowToShuffle[r];
            rowToShuffle[r] = tmp;
        }


        if (rowShuffled == 1)
        {
            wordList[0] = rowToShuffle[0];
            wordList[1] = rowToShuffle[1];
            wordList[2] = rowToShuffle[2];
            wordList[3] = rowToShuffle[3];
        }



        //Reset Values
        powerUpMode = false;
        bananaMode = false;
        cardSpecial = null;

        Debug.Log("<color=yellow>Banana Shuffled the Row </color>");

        yield return 0;
    }

}
