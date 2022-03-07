using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public GameObject enemyFolder;
    public Text enemyCount;
    public Text currentGoal;

    public Text resultText;
    public GameObject resultMenu;

    private int startEnemyCount;
    private bool isInstantiate = false;
    public GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        startEnemyCount = enemyFolder.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInstantiate){
            int killed = startEnemyCount - enemyFolder.transform.childCount;
            enemyCount.text = killed + "/" + startEnemyCount;
        }

        if (enemyFolder.transform.childCount >0)
        {
            // WinGame();
            
            if(isInstantiate == false)
            {
                currentGoal.text = "    Kill Boss: "; 
                isInstantiate = true;
                Vector3 pos = new Vector3(438f,-9f,453f);
                // Vector3(-510.937134,-227.34436,-529.339355)
                GameObject boss = GameObject.Instantiate(bossPrefab, pos, Quaternion.identity);
                boss.transform.parent = GameObject.Find("Enemy").transform;
                enemyCount.text = 0 + "/" + 1;
            }
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
