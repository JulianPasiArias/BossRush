
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Vector2 respawnPoint;
    [SerializeField] GameObject gameOverScreen;
   
    public Transform spawn;

    public static GameManager instance;

    private float countdown = 2f;
    
    public bool gameHasEnded = false;
  
  
    void Awake()
    {
       
        instance = this;    
        
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("PlayerStartPosition").GetComponent<Transform>();
        respawnPoint = spawn.position;
    }

    void Update()
    {
           
       
        if(gameHasEnded)
        {
            
            UpdateGameOverScreen(true);
           
            countdown -= Time.deltaTime;
            if( countdown <=0)
            {
                
                countdown =2;
                PlayerDie();
                
            }
        
        }
       

    }
  
  
   public void UpdateGameOverScreen(bool value)
   {
        gameOverScreen.SetActive(value);
   }
   

   public Vector2 SetNewRespawn()
   {
        return respawnPoint;
   }

   void LoadCurrentScene()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void CheckpointPosition(Vector2 newSpawn)
   {
        
        respawnPoint = newSpawn;
   }

   public void PlayerDie()
    {
        LoadCurrentScene();
        UpdateGameOverScreen(false);
    
        gameHasEnded = false;
    }


}
