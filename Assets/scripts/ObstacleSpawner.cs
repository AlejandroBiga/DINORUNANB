using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public Transform spawnPoint; 

    private float spawnInterval = 1.0f;
    public float objectLifetime = 5.0f;

    void Start()
    {
        // Llama a la función SpawnObject() cada 'spawnInterval' segundos.
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        // Obtiene un objeto del Object Pool (usando el singleton).
        GameObject spawnedObject = ObjectPool.SharedInstance.GetPooledObject();

        if (spawnedObject != null)
        {
            // Establece la posición y la rotación del objeto y lo activa.
            spawnedObject.transform.position = spawnPoint.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);

            StartCoroutine(DeactivateObject(spawnedObject));
        }
    }
    IEnumerator DeactivateObject(GameObject objToDeactivate)
    {
        yield return new WaitForSeconds(objectLifetime);

        // Desactiva el objeto después de 'objectLifetime' segundos.
        objToDeactivate.SetActive(false);
    }


}
