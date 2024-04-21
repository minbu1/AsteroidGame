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
}
