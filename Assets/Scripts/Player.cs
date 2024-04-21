using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public float moveSpeed = 1;
    public float rotationSpeed = 200f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0.5f;

    private bool isMoving = false;

    private void Start()
    {
        nextFireTime = Time.time;
    }

    private void Update()
    {
        // Rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        // Movement
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isMoving = true;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isMoving = false;
        }

        if (isMoving)
        {
            Vector3 moveDirection = transform.up;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }

        //firing
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
    }
}
