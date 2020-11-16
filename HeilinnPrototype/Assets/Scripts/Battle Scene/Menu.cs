using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{

    public Transform pointer;
    public Menus[] positions;
    public GameObject[] menus;
    public GameObject enemy;
    public GameObject enemyLife;
    public GameObject menuCanvas;
    public GameObject winCanvas;
    public GameObject defetCanvas;
    public GameObject manaObject;
    public GameObject lifeObject;

    int currentPosition = 0;
    int maxPosition = 2;
    int currentMenu = 0;
    int currentAttack = 3;
    int maxAttack = 5;
    int currentMage = 6;
    int maxMage = 8;
    Context currentContext = Context.MainMenu;
    int life = 0;
    TextMeshProUGUI txtMP;
    TextMeshProUGUI txtMana;
    TextMeshProUGUI txtLife;
    int playerLife = 100;
    bool isIndefense = false;
    int mana = 100;
    Context playerTrunContext;
    bool hasUsedMagic = false;

    // Start is called before the first frame update
    void Start()
    {
        winCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        currentMenu = 0;
        menus[0].SetActive(true);
        for (int i = 0; i<menus.Length; i++)
        {
            if (!(i == currentMenu))
            {
                menus[i].SetActive(false);
            }
        }
        currentPosition = 0;
        currentAttack = 3;
        currentMage = 6;
        pointer.position = positions[currentPosition].transform.position;
        txtMP = enemyLife.GetComponent<TextMeshProUGUI>();
        txtMana = manaObject.GetComponent<TextMeshProUGUI>();
        txtLife = lifeObject.GetComponent<TextMeshProUGUI>();
        life = 0;
        enemy.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentContext == Context.MainMenu)
        {
            currentPosition--;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentContext == Context.MainMenu)
        {
            currentPosition++;
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentContext == Context.AttackMenu)
        {
            currentAttack--;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentContext == Context.AttackMenu)
        {
            currentAttack++;
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentContext == Context.MagicMenu)
        {
            currentMage--;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentContext == Context.MagicMenu)
        {
            currentMage++;
        }


        if (currentPosition < 0)
        {
            currentPosition = maxPosition;
        }
        else if (currentPosition > maxPosition)
        {
            currentPosition = 0;
        }

        if (currentAttack < 3)
        {
            currentAttack = maxAttack;
        }
        else if (currentAttack > maxAttack)
        {
            maxAttack = 3;
        }

        if (currentMage < 6)
        {
            currentMage = maxMage;
        }
        else if (currentMage > maxMage)
        {
            currentMage = 6;
        }

        movePointer();

        if (Input.GetKeyDown(KeyCode.E) && currentContext == Context.MainMenu)
        {
            currentContext = positions[currentPosition].context;
            Debug.Log(currentContext);
        }
        else if(Input.GetKeyDown(KeyCode.E) && currentContext == Context.AttackMenu)
        {
            currentContext = positions[currentAttack].context;
        }
        else if (Input.GetKeyDown(KeyCode.E) && currentContext == Context.MagicMenu)
        {
            currentContext = positions[currentMage].context;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            currentContext = Context.MainMenu;
        }

        moveMenus();
    }

    void movePointer()
    {
        if (currentContext == Context.MainMenu)
        {
            switch (currentPosition)
            {
                case 0:
                    pointer.position = positions[0].transform.position;
                    break;
                case 1:
                    pointer.position = positions[1].transform.position;
                    break;
                case 2:
                    pointer.position = positions[2].transform.position;
                    break;
            }
        }
        else if (currentContext == Context.AttackMenu)
        {
            switch (currentAttack)
            {
                case 3:
                    pointer.position = positions[3].transform.position;
                    break;
                case 4:
                    pointer.position = positions[4].transform.position;
                    break;
                case 5:
                    pointer.position = positions[5].transform.position;
                    break;
            }
        }
        else if(currentContext == Context.MagicMenu)
        {
            switch (currentMage)
            {
                case 6:
                    pointer.position = positions[6].transform.position;
                    break;
                case 7:
                    pointer.position = positions[7].transform.position;
                    break;
                case 8:
                    pointer.position = positions[8].transform.position;
                    break;
            }
        }
    }

    void moveMenus()
    {
        switch (currentContext)
        {
            case Context.MainMenu:
                menus[0].SetActive(true);
                menus[1].SetActive(false);
                menus[2].SetActive(false);
                break;
            case Context.AttackMenu:
                menus[0].SetActive(false);
                menus[1].SetActive(true);
                menus[2].SetActive(false);
                break;
            case Context.MagicMenu:
                menus[0].SetActive(false);
                menus[1].SetActive(false);
                menus[2].SetActive(true);
                break;
            case Context.ScapeMenu:
                defet();
                break;
            case Context.BasicAttak:
                attack(10);
                currentContext = Context.EnemyTurn;
                playerTrunContext = Context.AttackMenu;
                break;
            case Context.MediumAttakc:
                attack(20);
                currentContext = Context.EnemyTurn;
                playerTrunContext = Context.AttackMenu;
                break;
            case Context.StrongAttack:
                attack(30);
                currentContext = Context.EnemyTurn;
                playerTrunContext = Context.AttackMenu;
                break;
            case Context.Fire:
                useMagic(20, "fire");
                if (hasUsedMagic)
                {
                    currentContext = Context.EnemyTurn;
                    playerTrunContext = Context.MagicMenu;
                }
                else
                {
                    currentContext = Context.MagicMenu;
                }
               
                break;
            case Context.Heal:
                useMagic(35, "heal");
                if (hasUsedMagic)
                {
                    currentContext = Context.EnemyTurn;
                    playerTrunContext = Context.MagicMenu;
                }
                else
                {
                    currentContext = Context.MagicMenu;
                }
                break;
            case Context.Defense:
                useMagic(50, "defense");
                if (hasUsedMagic)
                {
                    currentContext = Context.EnemyTurn;
                    playerTrunContext = Context.MagicMenu;
                }
                else
                {
                    currentContext = Context.MagicMenu;
                }
                break;
            case Context.EnemyTurn:
                enemyTurn();
                currentContext = playerTrunContext;
                break;
        }
    }

    void attack(int damage)
    {
        enemy.GetComponent<Animator>().SetTrigger("attacked");

        life += damage;

        if(life >= 100)
        {
            life = 100;
            winCanvas.SetActive(true);
            menuCanvas.SetActive(false);
            enemy.SetActive(false);
            StartCoroutine(endGame());
        }

        Debug.Log(life);
        Debug.Log(currentContext);
        string lifeText = life.ToString() + "%";
        txtMP.text = "Enemic: " + lifeText;
       
    }

    void useMagic(int manaCost, string action)
    {
        if(mana < manaCost)
        {
            hasUsedMagic = false;
            return;
        }
        hasUsedMagic = true;
        mana -= manaCost;
        string manaStr = "Mana: " + mana.ToString();
        string lifeStr = "Vida: " + playerLife.ToString();

        if (action == "fire")
        {
            attack(40);
        }
        else if (action == "heal")
        {
            if (!(playerLife >= 100))
            {
                playerLife += 30;
            }
        }
        else if (action == "defense")
        {
            isIndefense = true;
        }

        txtMana.text = manaStr;
        txtLife.text = lifeStr;
    }

    void enemyTurn()
    {
        enemy.GetComponent<Animator>().SetTrigger("attack");
        int randomAction = Random.Range(0, 100);

        if (!isIndefense)
        {
            if (randomAction >= 0 || randomAction <= 60)
            {
                playerLife -= 20;
            }
            else if (randomAction > 60 || randomAction <= 90)
            {
                playerLife -= 40;
            }
            else if (randomAction > 90 || randomAction <= 100)
            {
                playerLife -= 60;
            }

        }

        if(playerLife <= 0)
        {
            defet();
        }
        isIndefense = false;
        string lifeStr = "Vida: " + playerLife.ToString();
        txtLife.text = lifeStr;
    }

    void defet()
    {
        defetCanvas.SetActive(true);
        menuCanvas.SetActive(false);
        enemy.SetActive(false);
        StartCoroutine(endGame());
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }
}
