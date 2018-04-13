﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPowerUp : MonoBehaviour {

    public GameManager gameManager;
    public PowerUps powerUps;

    public int pearPower;
    public int applePower;
    public int bananaPower;
    public int cherryPower;
    public int pineapplePower;
    public int strawberryPower;
    public int watermelonPower;
    public int jamPower;
    public int onionPower;


    //Instant Effects + Awarding Power
    public void GivePower(string fruitType)
    {
       if (gameManager.playerOneTurn == true)
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
                //Instant Effect!
                strawberryPower = 1;
                powerUps.StrawberryPower();
            }
            if (fruitType == "Watermelon")
            {
                watermelonPower = 1;
            }
            if (fruitType == "Jam")
            {
                //Instant Effect!
                jamPower = 1;
                powerUps.JamPower();
            }
            if (fruitType == "Onion")
            {
                //Instant Effect!
                onionPower = 1;
                powerUps.OnionPower();
            }
        }

        else if (gameManager.playerOneTurn == false)
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
                //Instant Effect!
                strawberryPower = 2;
                powerUps.StrawberryPower();
            }
            if (fruitType == "Watermelon")
            {
                watermelonPower = 2;
            }
            if (fruitType == "Jam")
            {
                //Instant Effect!
                jamPower = 2;
                powerUps.JamPower();
            }
            if (fruitType == "Onion")
            {
                //Instant Effect!
                onionPower = 2;
                powerUps.OnionPower();
            }
        }
    }


    //End of Turn Effects
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
                gameManager.InfoText.text = "Pineapple Power! Pick a card to place smelly onions";
                gameManager.powerUpMode = true;
                gameManager.pineappleMode = true;
            }
            if (strawberryPower == 1)
            {
                //Effect is instant
            }
            if (watermelonPower == 1)
            {
                //dunno yet
            }
            if (jamPower == 1)
            {
                // award TWO points
                //Effect is instant
            }
            if (onionPower == 1)
            {
                //Effect is instant
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
                gameManager.InfoText.text = "Pineapple Power! Pick a card to place smelly onions";
                gameManager.powerUpMode = true;
                gameManager.pineappleMode = true;
            }
            if (strawberryPower == 2)
            {
                //Effect is instant
            }
            if (watermelonPower == 2)
            {
                //dunno yet
            }
            if (jamPower == 2)
            {
                // award TWO points
                //Effect is instant
            }
            if (onionPower == 2)
            {
                //Effect is instant
            }
        }
    }
}
