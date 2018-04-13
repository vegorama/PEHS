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
    public bool playerOneTurn;
    public int NumberOfPlayers;

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
    public string[] wordList;
    [SerializeField]
    private Sprite[] fruitImageList;

    [Header("Power Ups")]
    public PowerUps powerUps;
    public AssignPowerUp assignPowerUp;
    public Button strawberryPowerButton;
    public bool powerUpMode;
    public bool bananaMode;
    public bool pineappleMode;




    // Use this for initialization
    public void Start()
    {
        RandomiseCards();
        AssignCardValues();
        NextPlayer();
        UpdateText();
    }

    private void RandomiseCards()
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

    public void AssignCardValues()
    {
        //Assign text
        for (int t = 0; t < buttonList.Length; t++)
        {
            if (buttonList[t] != null)
            {
                buttonList[t].GetComponentInChildren<Text>().text = wordList[t];
            }          
        }

        //Assign Sprites
        for (int t = 0; t < buttonList.Length; t++)
        {
            if (buttonList[t] != null)
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
                else if (buttonList[t].GetComponentInChildren<Text>().text == "Onion")
                {
                    buttonList[t].GetComponentsInChildrenNoParent<Image>()[0].sprite = fruitImageList[8];
                }
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

        //Unlock Own Locked Cards
        UnlockCards();
        //Check for Strawb Power
        LuckyStrawbButton();

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

    private void ResetCardBackColour()
    {
        for (int t = 0; t < buttonList.Length; t++)
        {
            if (buttonList[t] != null)
            {
                buttonList[t].GetComponent<ButtonScript>().CardBackReset(playerOneTurn);
            }
        }
    }

    private void ShowCherryPicks()
    {
        if (assignPowerUp.cherryPower == 1 && (playerOneTurn == true))
        {
            card1.GetComponent<ButtonScript>().HideText();
            card2.GetComponent<ButtonScript>().HideText();
        }
        else if (assignPowerUp.cherryPower == 2 && (playerOneTurn == false))
        {
            card1.GetComponent<ButtonScript>().HideText();
            card2.GetComponent<ButtonScript>().HideText();
        }
        else
        {
        card1.GetComponent<ButtonScript>().CardBackColour();
        card2.GetComponent<ButtonScript>().CardBackColour();
        }
    }


    //Card Check system
    public IEnumerator CardCheck()
    {
        //Debug.Log("CardCheck being called!");

        if ((cardText1 != string.Empty) && (cardText1 != string.Empty))
        {
            //A match
            if (cardText1 == cardText2)
            {
                yield return new WaitForSeconds(1f);

                assignPowerUp.GivePower(cardText1);

                //check for Double Onion
                if (cardText1 == "Onion")
                {
                    DoubleOnion();
                }

                else
                {
                    Destroy(card1.gameObject);
                    Destroy(card2.gameObject);

                    cardText1 = string.Empty;
                    cardText2 = string.Empty;
                    card1 = null;
                    card2 = null;

                    AwardPoint();
                    UpdateText();
                }
            }


            //Not a match
            else
            {
                assignPowerUp.CheckPower(playerOneTurn);

                yield return new WaitForSeconds(.5f);

                ShowCherryPicks();

                cardText1 = string.Empty;
                cardText2 = string.Empty;
                card1 = null;
                card2 = null;

                if (bananaMode == true)
                {
                    yield return StartCoroutine(BananaShuffle());
                }
                if (pineappleMode == true)
                {
                    yield return StartCoroutine( powerUps.PineapplePower() );
                }


                NextPlayer();
                ResetCardBackColour();
                UpdateText();
            }
        }
    }


    //Special Cases
    private void UnlockCards()
    {
        if (playerOneTurn && assignPowerUp.pearPower == 1)
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                if (buttonList[i] != null && buttonList[i].tag == "PearLock")
                {
                    buttonList[i].tag = "Untagged";
                    buttonList[i].GetComponent<Button>().interactable = true;
                }
            }
        }
        if (playerOneTurn && assignPowerUp.applePower == 1)
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                if (buttonList[i] != null && buttonList[i].tag == "AppleLock")
                {
                    buttonList[i].tag = "Untagged";
                    buttonList[i].GetComponent<Button>().interactable = true;
                }
            }
        }
        if (!playerOneTurn && assignPowerUp.pearPower == 2)
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                if (buttonList[i] != null && buttonList[i].tag == "PearLock")
                {
                    buttonList[i].tag = "Untagged";
                    buttonList[i].GetComponent<Button>().interactable = true;
                }
            }
        }
        if (!playerOneTurn && assignPowerUp.applePower == 2)
        {
            for (int i = 0; i < buttonList.Length; i++)
            {
                if (buttonList[i] != null && buttonList[i].tag == "AppleLock")
                {
                    buttonList[i].tag = "Untagged";
                    buttonList[i].GetComponent<Button>().interactable = true;
                }
            }
        }
    }

    private void LuckyStrawbButton()
    {
        if (assignPowerUp.strawberryPower == 1 && playerOneTurn)
        {
            strawberryPowerButton.interactable = true;
        }
        else if (assignPowerUp.strawberryPower == 2 && !playerOneTurn)
        {
            strawberryPowerButton.interactable = true;
        }
        else
        {
            strawberryPowerButton.interactable = false;
        }
    }

    private IEnumerator BananaShuffle()
    {
        Debug.Log("<color=yellow>Banana Shuffle Coroutine called </color>");

        //Make new string
        string[] rowToShuffle = { "", "", "", "" };
        //Simple Counter
        int counter = 0;

        //Wait until card is Selected
        yield return new WaitUntil(() => cardSpecial != null);

        //Get int rowNum
        int rowNum = cardSpecial.GetComponent<ButtonScript>().rowNum;

        //Loop through remaining buttons, adding them to array.
        //QUICK MAFS here just works out which cards to pick from the rowNum, 1= 0-4, 2= 4-8, 3= 8-12, 4= 12-16
        for (int t = ((rowNum - 1) * 4); t < (((rowNum - 1) * 4) + 4); t++)
        {
            if (buttonList[t] != null)
            {
                rowToShuffle[counter] = buttonList[t].GetComponentInChildren<Text>().text;
                counter++;
            }
        }

        Debug.Log("<color=green>Banana Card Picked is </color>" + cardSpecial + " and rowShuffled is " + rowNum);

        //Make a list from array to remove empty objects
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

        //Put Back
        counter = 0;
        for (int t = ((rowNum - 1) * 4); t < (((rowNum - 1) * 4) + 4); t++)
        {
            if (buttonList[t] != null)
            {
                wordList[t] = rowToShuffle[counter];
                counter++;
            }
        }

        //Reassign card values
        AssignCardValues();

        //Reset Values
        powerUpMode = false;
        bananaMode = false;
        cardSpecial = null;
        counter = 0;

        //Remove Banana Power
        assignPowerUp.bananaPower = 0;

        Debug.Log("<color=yellow>Banana Shuffled Row number: </color>" + rowNum);

        yield return 0;
    }

    /*
    private IEnumerator PineappleBomb()
    {
        //Wait until card is Selected
        yield return new WaitUntil(() => cardSpecial != null);

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

            //Reassign card values
            AssignCardValues();

            //Reset Values
            powerUpMode = false;
            pineappleMode = false;
            cardSpecial = null;

            //Remove Pineapple Power
            assignPowerUp.pineapplePower = 0;
        }

        yield return 0;
    }
    */

    private void DoubleOnion()
    {
        assignPowerUp.CheckPower(playerOneTurn);

        Destroy(card1.gameObject);
        Destroy(card2.gameObject);

        cardText1 = string.Empty;
        cardText2 = string.Empty;
        card1 = null;
        card2 = null;

        NextPlayer();
        ResetCardBackColour();
        UpdateText();
    }

}
