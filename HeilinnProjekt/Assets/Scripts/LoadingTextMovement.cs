using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoadingTextMovement : MonoBehaviour
{
    private string loading = "Loading";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeText());
    }

    IEnumerator changeText()
    {
        while (true)
        {
            if (loading.Length == 10)
            {
                loading = "Loading";
            }
            loading += ".";
            GetComponent<TextMeshProUGUI>().text = loading;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
