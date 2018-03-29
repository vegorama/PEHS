using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPowerUp : MonoBehaviour {

    public GameManager GameManager;
    public PowerUps powerUps;

    public int pearPower;
    public int applePower;
    public int bananaPower;
    public int cherryPower;
    public int pineapplePower;
    public int strawberryPower;
    public int watermelonPower;
    public int jamPower;

    private void Start()
    {
        //Dictionary<string, int> fruitPowers = new Dictionary<string, int>();
    }

    public void GivePower(string fruitType)
    {
       if (GameManager.playerOneTurn == true)
        {
            if (fruitType == "Pear")
            {
                pearPower = 1;
            }
            if (fruitType == "Apple")
            {
                applePower = 1;
            }
            if (fruitType == "Banana")
            {
                bananaPower = 1;
            }
            if (fruitType == "Cherry")
            {
                cherryPower = 1;
            }
            if (fruitType == "Pineapple")
            {
                pineapplePower = 1;
            }
            if (fruitType == "Strawberry")
            {
                strawberryPower = 1;
            }
            if (fruitType == "Watermelon")
            {
                watermelonPower = 1;
            }
            if (fruitType == "Jam")
            {
                jamPower = 1;
            }
        }

        else if (GameManager.playerOneTurn == false)
        {
            if (fruitType == "Pear")
            {
                pearPower = 2;
            }
            if (fruitType == "Apple")
            {
                applePower = 2;
            }
            if (fruitType == "Banana")
            {
                bananaPower = 2;
            }
            if (fruitType == "Cherry")
            {
                cherryPower = 2;
            }
            if (fruitType == "Pineapple")
            {
                pineapplePower = 2;
            }
            if (fruitType == "Strawberry")
            {
                strawberryPower = 2;
            }
            if (fruitType == "Watermelon")
            {
                watermelonPower = 2;
            }
            if (fruitType == "Jam")
            {
                jamPower = 2;
            }
        }
    }

    public void CheckPower(bool PlayerOneTurn)
    {
        if (PlayerOneTurn)
        {
            if (pearPower == 1)
            {
                //Lockdown first card
                powerUps.PearPower();
            }
            if (applePower == 1)
            {
                //lockdown second card
                powerUps.ApplePower();
            }
            if (bananaPower == 1)
            {
                //reshuffle
                powerUps.BananaPower();
            }
            if (cherryPower == 1)
            {
                //keep picks hidden
            }
            if (pineapplePower == 1)
            {
                //pick a square and place down two onions
            }
            if (strawberryPower == 1)
            {
                //show a reveal-a-card button
            }
            if (watermelonPower == 1)
            {
                //dunno yet
            }
            if (jamPower == 1)
            {
                // award TWO points
                powerUps.JamPower();
                Debug.Log("Awarding TWO points for the JAM");
            }
        }

        else if (!PlayerOneTurn)
        {
            if (pearPower == 2)
            {
                //Lockdown first card
                powerUps.PearPower();
            }
            if (applePower == 2)
            {
                //Lockdown second card
                powerUps.ApplePower();
            }
            if (bananaPower == 2)
            {
                //reshuffle
                powerUps.BananaPower();
            }
            if (cherryPower == 2)
            {
                //keep picks hidden
            }
            if (pineapplePower == 2)
            {
                //pick a square and place down two onions
            }
            if (strawberryPower == 2)
            {
                //show a reveal-a-card button
            }
            if (watermelonPower == 2)
            {
                //dunno yet
            }
            if (jamPower == 2)
            {
                // award TWO points
                powerUps.JamPower();
                Debug.Log("Awarding TWO points for the JAM");
            }
        }
    }
}
