using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawns;
    [SerializeField] private GameObject obstacle;

    [Header ("Timer")]
    [SerializeField] private float time;
    private float currenTime;
    private void Start()
    {
        currenTime = time;
    }

    private void Update()
    {
        currenTime -= Time.deltaTime;
        if (currenTime < 0){

            if (!obstacle.activeInHierarchy)
            {
                SpawnObstacle();
                StartCoroutine(DespawnObstacle());
            }
            currenTime = time;
        }
    }

    private void SpawnObstacle(){
        obstacle.transform.position = SelectSpawn();
        obstacle.SetActive(true);
    }

    private Vector3 SelectSpawn(){
        int index = Random.Range(0, spawns.Length);
        return spawns[index].position;
    }
    private IEnumerator DespawnObstacle(){
        yield return new WaitForSeconds(2f);
        obstacle.SetActive(false);
    }
}
