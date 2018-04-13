using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrawberryPower : MonoBehaviour {

    public Button refToSelf;
    public GameManager gameManager;
    public AssignPowerUp assignPowerUp;

    public void StrawbPower()
    {
        GameObject[] buttonList = gameManager.buttonList;

        int min = 0;
        int max = 15;

        int randomCard = Random.Range(min, max);

        if ((buttonList[randomCard] != null) && (buttonList[randomCard] != gameManager.card1))
        {
            buttonList[randomCard].GetComponent<ButtonScript>().cardImage.SetActive(true);

            refToSelf.interactable = false;

            //Set to 3 when used, for checking
            assignPowerUp.strawberryPower = 3;
        }

        else
        {
            StrawbPower();
        }

    }

}
