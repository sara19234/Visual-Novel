using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonEvent : MonoBehaviour
{

    //what the button will display to the user
    public Text buttonDisplayText;
    //so we can change pages on click
    public PageManager pageManager;
    //what should we do when we click
    public string action;
    //what number or item or thing to use
    public string key;

    public void Initialise(string action, string key, string label, PageManager pageManager)
    {
        //"this" is the current script
        this.action = action;
        this.key = key;
        this.pageManager = pageManager;


        buttonDisplayText = GetComponentInChildren<Text>();
        buttonDisplayText.text = label;
    }

    public void Event()
    {
        switch (action)
        {
            case "goto":
                int pageNumber = int.Parse(key);
                pageManager.LoadPage(pageNumber);
                break;
            case "collect":
                Item item = Enum.Parse<Item>(key);
                pageManager.inventory.Collect(item);

                //finish this code - we need to load a page according to what we collected
                break;
            default:
                Debug.LogWarning($"The button {this.name} failed to act, with action {action} and key {key}");
                break;
        }
    }
}







