using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverShoulderTablet : MonoBehaviour
{
    public GameObject subpages;


    private List<GameObject> pages;
    private int currentPageIndex = 0;


    // Start is called before the first frame update
    void Awake()
    {
        pages = new List<GameObject>();
        foreach (Transform child in subpages.transform)
        {
            pages.Add(child.gameObject);
        }
        pages[currentPageIndex].SetActive(true);
    }

    /*********************  HELPER METHODS  *********************/
    public void turnPage(bool next)
    {
        pages[currentPageIndex].SetActive(false);
        if (next)
        {
            currentPageIndex += currentPageIndex < pages.Count - 1 ? 1 : -(pages.Count - 1);
        }
        else
        {
            currentPageIndex -= currentPageIndex > 0 ? 1 : -(pages.Count - 1);
        }
        pages[currentPageIndex].SetActive(true);
    }

    public void swapPages(bool next)
    {

    }

}
