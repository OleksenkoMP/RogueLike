using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Lvl1;
    public GameObject Lvl2;
    public GameObject Lvl3;


    public List<GameObject> enemySpawnPointsLvl1;
    public List<GameObject> enemySpawnPointsLvl2;
    public List<GameObject> enemySpawnPointsLvl3;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 2f);
    }

    void Spawn()
    {
        foreach (var item in enemySpawnPointsLvl1)
        {
            Instantiate(Lvl1, item.transform);
        }
        foreach (var item in enemySpawnPointsLvl2)
        {
            Instantiate(Lvl2, item.transform);
        }
            foreach (var item in enemySpawnPointsLvl3)
        {
            Instantiate(Lvl3, item.transform);
        }
    }

}
