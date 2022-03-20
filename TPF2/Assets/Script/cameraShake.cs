using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    /*Este script indica que la camara se mueva y cree el efecto de sacudida. Se ha conseguido con una courrutina que activamos en otro script*/
    public IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f; 
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            //Esto indicará que no haga nada más hasta que llegue el nuevo frame

            yield return null;
        }

        transform.localPosition = originalPos;

    }
}
