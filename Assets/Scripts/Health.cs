using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100;
    public float infectionRate;
    public bool masked = false;
    public float infectionInterval;

    private bool isDead;
    private bool isInfected;
    private float nextInfectionTime = 0.0f;

    public Text HealthText;
    public Text InfectionText;

    public Text resultText;
    public GameObject resultMenu;

    public Image damageScreen;
    Color alpha;
    public float lastDamageTime = -1;
    private float delay = 2;

    private void Start()
    {

        isDead = false;
        isInfected = false;

        infectionRate = 25;
        infectionInterval = 3f;

        alpha = damageScreen.color;

        resultMenu.SetActive(false);

    }

    private void Update()
    {
        UpdateHealthInfo(health.ToString());
        UpdateInfectionInfo(infectionRate.ToString());
        StartCoroutine(PauseGame());

        if (Time.time >= nextInfectionTime && !masked) {

            nextInfectionTime += infectionInterval;
            TakeInfection(1f);
        }
        if (lastDamageTime >= 0 && (Time.time - lastDamageTime) >= delay)
        {
            if (alpha.a <= 0) {
                lastDamageTime = -1;
            }
            else {
                alpha.a -= 0.01f;
                damageScreen.color = alpha;
            }
        }
    }

        public void TakeDamage(float damage)
        {
            health -= damage;
            // alpha.a += 2*(damage / health);\
            if (health > 50)
            {
                alpha.a += 0.2f;
            }
            else
            {
                alpha.a = ((100 - health) / 100);
            }
            damageScreen.color = alpha;
            lastDamageTime = Time.time;
            if (!isDead && health <= 0)
            {
                isDead = true;
            }
        }

        public void AddHealth(float amount)
        {
            health += amount;
            if (health >= 100)
            {
                health = 100;
            }
        }

        public void TakeInfection(float infection)
        {
            infectionRate += infection;

            if (!isInfected && infectionRate >= 100)
            {
                isInfected = true;
            }
        }

        private void UpdateHealthInfo(string _health)
        {
            HealthText.text = "Health: " + _health;
        }

        private void UpdateInfectionInfo(string _infection)
        {
            InfectionText.text = "Infection: " + _infection;
        }

        IEnumerator PauseGame()
        {
            if (isDead)
            {
                resultText.text = "Game Over!";
                resultMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                yield return new WaitForSecondsRealtime(1);
                Time.timeScale = 0f;
            }

            if (isInfected)
            {
                resultText.text = "You are infected!";
                resultMenu.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                yield return new WaitForSecondsRealtime(1);
                Time.timeScale = 0f;
            }
        }

    }