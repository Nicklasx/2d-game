using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;

    public int currentExp;

    public int[] toLevelUp;

    public int[] HPLvl;
    public int[] attcakLvl;
    public int[] defenceLvl;

    public int currentHP;
    public int currentAttack;
    public int currentDefence;

    private PlayerHealthManager thePlayerHealth;
	// Use this for initialization
	void Start () {
        currentHP = HPLvl[1];
        currentAttack = attcakLvl[1];
        currentDefence = defenceLvl[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentExp >= toLevelUp[currentLevel])
        {
            //currentLevel++;

            LevelUp();
        }
	}

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;
        currentHP = HPLvl[currentLevel];

        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLvl[currentLevel - 1];

        currentAttack = attcakLvl[currentLevel];
        currentDefence = defenceLvl[currentLevel];
    }
}
