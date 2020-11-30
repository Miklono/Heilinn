using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject[] maps;
    public Transform respawnPosition;
    public Canvas loadingCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startGame()
    {
        loadingCanvas.gameObject.SetActive(true);
        /*foreach (GameObject map in maps)
        {
            Destroy(map);
        }*/
        yield return new WaitForSeconds(5f);
        Instantiate(maps[0], new Vector3(0f, 0f, 0f), Quaternion.identity);
        Instantiate(player, respawnPosition.position, Quaternion.identity);
        loadingCanvas.gameObject.SetActive(false);

    }
}
