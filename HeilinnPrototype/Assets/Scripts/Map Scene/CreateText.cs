using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class CreateText : MonoBehaviour
{

    private float delay = .05f;
    private string dialog;
    private string currentText = "";
    private Regex regex;
    public bool isShowing = false;
    char[] letters;

    // Use this for initialization
    void Start()
    {
        this.regex = new Regex("^[a-zA-Z0-9]*$");
        dialog = GetComponent<TextMeshProUGUI>().text;
        //StartCoroutine(ShowText());
        letters = dialog.ToCharArray();
    }

    public void OnEnable()
    {
        if (!isShowing)
        {
            StartCoroutine(ShowText());
        }
        isShowing = true;
    }

    public void OnDisable()
    {
        isShowing = false;
        currentText = "";
    }

    IEnumerator ShowText()
    {
        Debug.Log(letters[0]);
        for (int i = 0; i < letters.Length; i++)
        {
            string currentLetter = letters[i].ToString();
            GetComponent<TextMeshProUGUI>().text = currentText += currentLetter;
            yield return new WaitForSeconds(delay);
        Debug.Log(i);
        }
    }
}
