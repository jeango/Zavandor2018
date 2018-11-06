using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float minSpawnInterval;
    public float maxSpawnInterval;
    public GameObject enemyPrefab;
    public Vector2 spawnDistance;

    public LayerMask dontSpawnNearLayers;
    public float spawnRadius;

    private int maxSpawnAttempts = 10;

    private Vector3 GetRandomPositionInZone ()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < maxSpawnAttempts; i++)
        {
            pos = Random.insideUnitCircle;
            pos.Scale(spawnDistance);
            pos += transform.position;
            if (IsValidPosition(pos))
                return pos;
        }
        return Vector3.zero;
    }

    private bool IsValidPosition (Vector3 position)
    {
        return !Physics2D.OverlapCircle(position, spawnRadius, dontSpawnNearLayers.value);
    }

    private GameObject Spawn ()
    {
        Vector3 pos = GetRandomPositionInZone();
        if (pos != Vector3.zero)
            return Poolable.Instantiate(enemyPrefab, pos, transform.rotation);
        return null;
    }
	
    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
