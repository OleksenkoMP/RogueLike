using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEnemy : MonoBehaviour
{
    private EnemySpawn templates;
    public int Lvl;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("EnemySpawn").GetComponent<EnemySpawn>();

        switch (Lvl)
        {
            case 1:
                templates.enemySpawnPointsLvl1.Add(this.gameObject);
                break;
            case 2:
                templates.enemySpawnPointsLvl2.Add(this.gameObject);
                break;
            case 3:
                templates.enemySpawnPointsLvl3.Add(this.gameObject);
                break;
            default:
                break;
        }
    }
}
