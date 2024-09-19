using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    //track the current page we're on
    public int currentPage;

    //remember the last page we were on
    public int previousPage;

    //text that displays the current page
    public Text pageDisplay;

    //the transform to parent our buttos to
    public Transform buttonPanel;

    //the prefab for our button
    public ButtonEvent buttonPrefab;

    //create an instance of our inventory to track our items
    public Inventory inventory = new Inventory();


    // Start is called before the first frame update
    void Start()
    {
        //load the first page
        LoadPage(0);
    }

    public void LoadPage(int pageNumber)
    {
        //remember what page we were just on
        previousPage = currentPage;
        //update to the page we are on now
        currentPage = pageNumber;

        //load the page we're on now from Resources
        TextAsset newPage = Resources.Load<TextAsset>("page" + pageNumber.ToString());

        //pass the text from our file into the function
        UnpackPage(newPage.text);
    }

    private void UnpackPage(string pageContents)
    {
        //stringSplit() will seperate a sting into an array, using the provided character
        string[] unpackedPage = pageContents.Split("`");
            //here, unpackedPage[0] is the display text, and unpackedPage[1] is our button info

        pageDisplay.text = unpackedPage[0];

        //split the button information into seperate buttons
        string[] buttons = unpackedPage[1].Split("_");
        //pass those buttons into our functions
        SetButtons(buttons);
    }

    private string RewritePage(string pageContents)
    {
        return "";
    }

    private void SetButtons(string[] buttonInfo)
    {
        //for as long as i (which starts at 0) is less than the number of child objects in buttonPanel...
        for(int i = 0; i < buttonPanel.childCount; i++)
        {
            //destroy the child gameobject
            Destroy(buttonPanel.GetChild(i).gameObject);

            //automatically add 1 to i, and check the condition again
        }

        //do something with every string contained in buttonInfo
        foreach(string currentButtonInfo in buttonInfo)
        {
            //here, we break our currentButtonInfo into 3 strings
            string[] buttonDetail = currentButtonInfo.Split("|");

            //Instantiate means "create an instance (aka a copy)
            ButtonEvent currentButton = Instantiate(buttonPrefab, buttonPanel);
            currentButton.Initialise(buttonDetail[0], buttonDetail[1], buttonDetail[2], this);
        }

    }

}
