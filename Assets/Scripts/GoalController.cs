using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public GameObject enemyFolder;
    public Text enemyCount;

    public Text resultText;
    public GameObject resultMenu;

    private int startEnemyCount;

    // Start is called before the first frame update
    void Start()
    {
        startEnemyCount = enemyFolder.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        int killed = startEnemyCount - enemyFolder.transform.childCount;

        enemyCount.text = killed + "/" + startEnemyCount;

        if (enemyFolder.transform.childCount == 0)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        resultText.text = "You Win!";
        resultMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
