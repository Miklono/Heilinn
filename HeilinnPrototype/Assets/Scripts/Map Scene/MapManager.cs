using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class MapManager : MonoBehaviour
{

    private float delay = .05f;
    private string text;
    private string currentText = "";
    private AudioSource voice;
    private Regex regex;

    // Start is called before the first frame update
    void Start()
    {
        this.regex = new Regex("^[a-zA-Z0-9]*$");
        this.voice = GetComponent<AudioSource>();
        this.text = GetComponent<TextMeshPro>().text;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialog()
    {
        Enable();
    }

    private void Enable()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            string currentLetter = text[i].ToString();
            this.GetComponent<TextMeshPro>().text = currentText += currentLetter;
            yield return new WaitForSeconds(delay);
        }
    }
}
