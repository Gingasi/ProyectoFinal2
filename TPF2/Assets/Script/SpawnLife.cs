using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLife : MonoBehaviour
{
    public GameObject Lifes;
    public GameObject[] Positions;
    private float LstartTime = 2f;
    private float LrepeatRate = 5f;
    private float LSpawnLim = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LifePrefab", LstartTime, 0);
    }

    //Función de Invoke de la recuperación de vida
    void LifePrefab()
    {

        for (int i = 0; i < Positions.Length; i++)
        {
            Instantiate(Lifes, Positions[i].transform.position,
                Lifes.transform.rotation);
            if (i >= LSpawnLim)
            {
                CancelInvoke("LifePrefab");
            }
        }
    }
}
