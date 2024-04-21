using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject PlayerSpawnpoint;

    public void Respawn()
    {
        Instantiate(PlayerPrefab, PlayerSpawnpoint.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // Calculate new spawn position
        Vector3 spawnPosition = PlayerSpawnpoint.transform.position;
        spawnPosition.x = Random.Range(-screenBounds.x, screenBounds.x);
        spawnPosition.y = Random.Range(-screenBounds.y, screenBounds.y);
    }
}
