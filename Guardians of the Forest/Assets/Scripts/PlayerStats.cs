using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentHPLevel;

    /* CURRENT EXP BY TYPE */
    public int currentExp;
    public int generalExp;
    public int currentVitalityExp;
    public int currentMPExp;
    public int currentAttackExp;
    public int currentDefenseExp;
    public int currentSneakyExp;
    public int currentSpeedExp;
    public int currentSpiritExp;

    /* array to hold the required EXP to level up for each level */
    public int[] toLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    /* CURRENT STATS */
    public int baseHP;
    public int baseMP;
    public int baseAttack;
    public int baseDefense;
    public int baseStealth;
    public int baseSpeed;
    public int baseSpiritAffinity;

    /* INITIALIZE CURRENT STAT LEVELS */
    //public int currentHPLevel;
    //public int currentMPLevel;
    //public int currentAttackLevel;
    //public int currentDefenseLevel;
    //public int currentStealthLevel;
    //public int currentSpeedLevel;
    //public int currentSpiritAffinityLevel;




    private PlayerHealthManager thePlayerHealth;

    // Start is called before the first frame update
    void Start()
    {
        baseHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();


        currentAttackLevel = 1;
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
        baseHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = baseHP;
        thePlayerHealth.playerCurrentHealth += baseHP - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
    }

    public void LevelUpStat(string stat)
    {
        if (stat == "attack")
        {
            baseAttack += baseAttack * toLevelUp[currentAttackLevel + 1];

            currentAttackLevel += 1;
        }

    }

    public void LevelHPUp()
    {
        currentHPLevel++;
        baseHP = HPLevels[currentLevel];

        thePlayerHealth.playerMaxHealth = baseHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentHPLevel - 1];

        //baseAttack = attackLevels[currentHPLevel];
        //baseDefense = defenseLevels[currentHPLevel];
    }
}
