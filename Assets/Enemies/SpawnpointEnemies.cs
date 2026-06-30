using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointEnemies : MonoBehaviour
{
   [Header("Spawn Settings")]
[SerializeField] private GameObject enemyPrefab;

[SerializeField] [Min(1)] private int minEnemies = 1;
[SerializeField] [Min(1)] private int maxEnemies = 5;

[SerializeField] [Min(0)] private float spawnRadius = 3f;

[SerializeField] private bool spawnOnStart = true;

private void Start()
{
if (spawnOnStart)
{
SpawnEnemies();
}
}

[ContextMenu("Spawn Enemies")]
public void SpawnEnemies()
{
if (enemyPrefab == null)
{
Debug.LogWarning($"Brak prefaba przeciwnika na {name}");
return;
}

int amount = Random.Range(minEnemies, maxEnemies + 1);

for (int i = 0; i < amount; i++)
{
Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

Vector3 spawnPosition = transform.position +
new Vector3(randomCircle.x, 0f, randomCircle.y);

Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
}
}

}
