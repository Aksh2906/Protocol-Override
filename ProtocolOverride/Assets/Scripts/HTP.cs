using UnityEngine;
using System.Collections.Generic;

public class HTP : MonoBehaviour
{
    public List <GameObject> pages = new List<GameObject>();
    public GameObject htp;

    int currentPage = 0;

    public void incrementPage()
    {
        if(currentPage < pages.Count - 1)
        {
            currentPage++;
        }
        NextPage();
    }
    public void decrementPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
        }
        PreviousPage();
    }

    public void NextPage()
    {
        for(int i=0; i<pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }

    public void PreviousPage()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
        pages[currentPage].SetActive(true);
    }

    public void CloseHTP()
    {
        htp.SetActive(false);
    }

    public void OpenHTP()
    {
        htp.SetActive(true);
        currentPage = 0;
        NextPage();
    }

}
