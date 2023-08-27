using UnityEngine;
using System.Collections.Generic;

public class Book : MonoBehaviour
{
    public List<Page> pages = new List<Page>();

    public void ActivateBookAndContents(int pageIndex)
    {
        foreach (Page page in pages)
        {
            page.DeactivatePage();
        }

        pages[pageIndex].ActivatePage();
    }

    public void DeactivateAllPages()
    {
        foreach (Page page in pages)
        {
            page.gameObject.SetActive(false);
        }
    }
}

