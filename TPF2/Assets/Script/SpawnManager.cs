using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] Enemies;
    public GameObject[] Positions;
    private float EstartTime = 2f;
    private float ErepeatRate = 30f;
    

    void Start()
    {

        InvokeRepeating("EnemyPrefab", EstartTime, ErepeatRate);
        
        
    }
    //Función de Invoke de los Enemigos
    void EnemyPrefab()
    {
        
        for (int i = 0; i < Positions.Length; i++)
        {
            Instantiate(Enemies[i], Positions[i].transform.position,
                Enemies[i].transform.rotation);
        }
    }

}

