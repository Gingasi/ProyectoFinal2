using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject Objects;
    public GameObject[] Positions;
    private float OstartTime = 2f;
    private float OrepeatRate = 50f;
    private float OSpawnLim = 10;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObjectPrefab", OstartTime, 0);
    }

    //Función de Invoke de los Objetos
    void ObjectPrefab()
    {

        for (int i = 0; i < Positions.Length; i++)
        {
            Instantiate(Objects, Positions[i].transform.position,
                Objects.transform.rotation);
            if (i >= OSpawnLim)
            {
                CancelInvoke("ObjectPrefab");
            }
        }
    }
}
