using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriWallScript : MonoBehaviour {
    public float moveSpeed;
    public GameManagerScript gameManagerScript;
    public Vector3 endPoint;
	// Use this for initialization
	void Start () {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent <GameManagerScript> ();

        moveSpeed =gameManagerScript.speed;
        endPoint = new Vector3(0, 0, -25);
        
	}
	
	// Update is called once per frame
	void Update () {
        Move();

        if(gameObject.transform.position.z < -25)
        {
            DestroyObject();
        }
	}
    void Move()
    {
        transform.Translate(-moveSpeed * Time.deltaTime,0 ,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tri")
        {
            gameManagerScript.score++;
        }
        else
        {
            gameManagerScript.die = true;
        }
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
