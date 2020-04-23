using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHay : MonoBehaviour
{

    public float horizontalBoundary;
    public float movementSpeed;

    public GameObject hayBalePrefab;
    public Transform haySpawnpoint;
    public float shootInterval;
    private float shootTimer;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();

    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 1
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 2
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }


    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();

    }


    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime; // 1

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space)) // 2
        {
            shootTimer = shootInterval; // 3
            ShootHay(); // 4
        }
    }



}