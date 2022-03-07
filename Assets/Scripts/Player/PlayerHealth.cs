using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 500;

    private float currentHealth;

    [SerializeField]
    private string SceneToLoadOnDeath;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float MaxHealth { get => maxHealth;}


    public GameObject TakingDamageSoundEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth < 0)
        {
            GameOver();
        }
    }

    public void reduceHealth(int amount)
    {
        currentHealth -= amount;

        if (TakingDamageSoundEffectPrefab != null)
            Instantiate(TakingDamageSoundEffectPrefab);
    }

    public void addHealth(int amount)
    {
        currentHealth += amount;
    }

    void GameOver()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(SceneToLoadOnDeath);
        currentHealth = maxHealth;
        if (!PlayerPrefs.HasKey("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", 0);
        }

        if(PlayerPrefs.GetInt("Highscore") < HighScore.currentScore)
        {
            PlayerPrefs.SetInt("Highscore", HighScore.currentScore);
        }
    }
}
