using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    private PlayerStats thePlayerStats;
    public int expToGive;

    public string enemyQuestName;
    private QuestManager theQM;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();

        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;
            Destroy (gameObject);
            thePlayerStats.AddExperience(expToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
