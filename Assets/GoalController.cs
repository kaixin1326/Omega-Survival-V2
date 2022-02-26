using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    public GameObject enemyFolder;
    public Text enemyCount;

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
    }
}
