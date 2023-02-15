using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHealing : MonoBehaviour
{
   [SerializeField] GameObject[] healingPrefab;

   [SerializeField] float secondSpawn = 0.5f;
   [SerializeField] float minTras;
   [SerializeField] float maxTras;
    void Start()
    {
        StartCoroutine(spawnHealthPrefab());
    }

    IEnumerator spawnHealthPrefab()
    {
        while(true)
        {
            var wanted = Random.Range(minTras,maxTras);
            var position = new Vector3(wanted,transform.position.y);
            GameObject gameObject = Instantiate(healingPrefab[Random.Range(0,healingPrefab.Length)],position,Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject,5);

        }
    }

    
}
