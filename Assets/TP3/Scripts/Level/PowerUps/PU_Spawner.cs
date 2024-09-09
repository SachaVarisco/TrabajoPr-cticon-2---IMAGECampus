using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Spawner : MonoBehaviour
{
    [Header("Poewer Ups")]
    [SerializeField] private GameObject[] powerUps;
    private int currentPU;
    [Header("Spawns")]
    [SerializeField] private Transform[] spawns;
    private int currentSpawn;

    [Header ("Time")]
    [SerializeField] private float timer;

    private void Awake()
    {
        Invoke("SpawnPU", timer);
    }

    private void SpawnPU()
    {
        if (currentPU < powerUps.Length && currentSpawn < spawns.Length)
        {
            powerUps[currentPU].transform.position = spawns[currentSpawn].position;
            powerUps[currentPU].SetActive(true);
        }
        else
        {
            if (currentPU >= powerUps.Length && currentSpawn < spawns.Length)
            {
                currentPU = 0;
            }
            else
            {
                if (currentSpawn >= spawns.Length && currentPU < powerUps.Length)
                {
                    currentSpawn = 0;
                }else{
                    currentPU = 0;
                    currentSpawn = 0;
                }
            }
            powerUps[currentPU].transform.position = spawns[currentSpawn].position;
            powerUps[currentPU].SetActive(true);
        }
        StartCoroutine(Despawn(powerUps[currentPU]));
        currentPU++;
        currentSpawn++;
    }

    private IEnumerator Despawn(GameObject PU){
        yield return new WaitForSeconds(timer);
        PU.SetActive(false);
        SpawnPU();
    }
}
