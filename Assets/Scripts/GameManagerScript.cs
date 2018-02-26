using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public static GameManagerScript instance = null;
    public int score,spawnChoose;
    public float speed;
    public float spawnRate;
    public int playerChoose=300,oldPlayerChoose;
    public bool die;
    public int highscore;
    public float colorCount;
    public bool flag;
    

    public GameObject tryAgainButton;
    public GameObject triWall, sphereWall, cubeWall;
    public GameObject triPlayer, spherePlayer, cubePlayer;
    public GameObject scoreTextObj, gameOverTextObj;
    public GameObject starEffect;
    
   
    public Text scoreText;
    public Text gameOverText;
    public Text tapToNext;
    public Camera mainCamera;
    
   


   


    void Awake()
    {
       
         
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }
    // Use this for initialization
    void Start () {
        die = false;
        
        flag = true;
        score = 0;
        colorCount = 255;
        cubePlayer.active = false;
        spherePlayer.active = false;
        oldPlayerChoose = playerChoose;
        speed = 20;
        scoreText.text = "0";
        highscore = PlayerPrefs.GetInt("High Score", highscore);
        StartCoroutine(SpawnBalloons());
    }

    // Update is called once per frame
    private void Update()
    {   

        if (die)
        {
            Die();
            
        }
    }
    void LateUpdate () {

        spawnChoose = Random.Range(1, 4);

    }
    private void FixedUpdate()
    {
       
        scoreText.text = ""+score;
        

    }
    //Spawn function(use spawnChoose variable for which shape spawn)
    void Spawn()
    {
        if (spawnChoose%4 == 1)

            Instantiate(triWall, new Vector3(0, 0, 100), Quaternion.Euler(90, 0, 90));
        if (spawnChoose%4 == 2)
            Instantiate(sphereWall, new Vector3(0, 0, 100), Quaternion.identity);
        if (spawnChoose%4 == 3)
            Instantiate(cubeWall, new Vector3(0, 0, 100), Quaternion.Euler(0, 90, 0));

        if (score % 5 == 0 && score != 0)
        {
            if (spawnRate > 2)
            {
                
              spawnRate -= 1f;
            }
            else if (spawnRate > 1f)
            {
                spawnRate -= 0.2f;
            }
            
        }
        speed++;

      
       
    }
    //swaping function
    void SwapPlayer()
    {
        starEffect.active = false;

        if (playerChoose%3 == 0)
        {

            
            starEffect.active = true;
            triPlayer.active = true;
            cubePlayer.active = false;
            spherePlayer.active = false;

        }
        if (playerChoose%3 == 1)
        {

            starEffect.active = true;
            triPlayer.active = false;
            cubePlayer.active = true;
            spherePlayer.active = false;

        }
        if (playerChoose%3 == 2)
        {

            starEffect.active = true;
            triPlayer.active = false;
            cubePlayer.active = false;
            spherePlayer.active = true;
            
        }
          
    }
    //when player press button this function active
    
    public void ChangePlayerNext()
    {
        tapToNext.text = "";
        playerChoose++;
       
            SwapPlayer();
            
        
    }
    // when you die this happens
    void Die()
     {
        
        if (score > highscore)
            highscore = score;
        


        gameOverText.text = "GAME OVER\n" + score+"\nHighscore\n"+highscore;
        gameOverTextObj.active = true;
        
        scoreTextObj.active = false;
        Time.timeScale = 0;
        Debug.Log("dead");
        tryAgainButton.active = true;

        //*********************************************************
       
    }
   public void TryAgain()
    {
        
         die = false;
         flag = true;
         
         Time.timeScale = 1;
         score = 0;
         playerChoose = 0;
         colorCount = 255;
       
         var clones = GameObject.FindGameObjectsWithTag("Wall");
         foreach (var clone in clones)
         {
             Destroy(clone);
         }
         gameOverTextObj.active = false;
         scoreTextObj.active = true;
         speed = 20;
         spawnRate = 4;
         tryAgainButton.active = false;
       

       
    }
    

    IEnumerator SpawnBalloons()
    {
        

        while (true)
        {
            Spawn();
           

            yield return new WaitForSeconds(spawnRate);

            
        }

    }
}
