using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentHPLevel;
    public int currentExp;

    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    public int currentHP;
    public int currentMP;
    public int currentAttack;
    public int currentDefense;
    public int currentStealth;

    private PlayerHealthManager thePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
     if(currentExp >= toLevelUp[currentLevel])
        {
            //currentLevel++;
            LevelUp();
        }   
    }

    public void AddExperience(int expToAdd)
    {
        currentExp += expToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
    }

    public void LevelHPUp()
    {
        currentHPLevel++;
        currentHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentHPLevel - 1];

        currentAttack = attackLevels[currentHPLevel];
        currentDefense = defenseLevels[currentHPLevel];
    }
}
