using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Asteroid : MonoBehaviour
{
    public GameObject smallAsteroidPrefab;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BreakAsteroid();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.Respawn();

            Destroy(collision.gameObject);
        }
    }

    private void BreakAsteroid()
    {
        if (smallAsteroidPrefab != null)
        {
            Vector3 offset = new Vector3(0.5f, 0.5f, 0);

            Instantiate(smallAsteroidPrefab, transform.position + offset, Quaternion.identity);
            Instantiate(smallAsteroidPrefab, transform.position - offset, Quaternion.identity);

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
