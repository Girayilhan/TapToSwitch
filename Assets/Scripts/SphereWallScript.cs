using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereWallScript : MonoBehaviour {
    public float moveSpeed;
    public GameManagerScript gameManagerScript;
    // Use this for initialization
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        moveSpeed = gameManagerScript.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (gameObject.transform.position.z < -25)
        {
            DestroyObject();
        }
    }
    void Move()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere")
        {
            gameManagerScript.score++;
        }
        else
        {
            gameManagerScript.die = true;
        }
    }
}
