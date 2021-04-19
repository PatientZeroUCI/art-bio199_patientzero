using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public GameObject blackOutSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator fadeToBlack(bool fadeToBlack = true, int fadeSpeed = 5)
    {
        Color canvasColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while(blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = canvasColor.a + (fadeSpeed * Time.deltaTime);
            }
        }
        else
        {

        }



        yield return new WaitForEndOfFrame();
    }
}
