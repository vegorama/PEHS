using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGuide : MonoBehaviour {


    public GameObject guideRef;


    public void ShowGuideScreen()
    {
        guideRef.SetActive(true);
    }

	public void HideGuideScreen()
    {
        guideRef.SetActive(false);
    }

}
