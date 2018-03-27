using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPowerUp : MonoBehaviour {

    public GameManager GameManager;

    private int pearPower;
    private int applePower;
    private int bananaPower;
    private int cherryPower;
    private int pineapplePower;
    private int strawberryPower;
    private int watermelonPower;
    private int jamPower;


    private void Start()
    {
        Dictionary<string, int> fruitPowers = new Dictionary<string, int>();

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

}
