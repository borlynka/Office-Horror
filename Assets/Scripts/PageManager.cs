using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PageManager : MonoBehaviour
{
    public Transform pageContent;
    public GameObject textPrefab;
    public GameObject buttonPrefab;

    void Start()
    {
        LoadPage("home");
    }

    public void LoadPage(string pageName)
    {
        // Clear old content
        foreach (Transform child in pageContent)
        {
            Destroy(child.gameObject);
        }

        // Load new content
        if (pageName == "home")
        {
            CreateText("WELCOME TO MY PAGE!!!");
            CreateButton("Go to Page 2", () => LoadPage("page2"));
        }
        else if (pageName == "page2")
        {
            CreateText("This is page 2");
            CreateButton("Back Home", () => LoadPage("home"));
        }
    }

    void CreateText(string message)
    {
        GameObject obj = Instantiate(textPrefab, pageContent);
        obj.GetComponent<TextMeshProUGUI>().text = message;
    }

    void CreateButton(string label, Action onClick)
    {
        GameObject obj = Instantiate(buttonPrefab, pageContent);

        // Set button text (TMP)
        obj.GetComponentInChildren<TextMeshProUGUI>().text = label;

        // Add click event
        obj.GetComponent<Button>().onClick.AddListener(() => onClick());
    }
}