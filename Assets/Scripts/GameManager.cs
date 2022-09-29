using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    
    public GroundPiece[] allGroundPieces;

    public ParticleSystem particles;
    private AudioSource spawnAudio;
    public AudioClip spawnSound;

    

    public bool isGameActive = false;
    


    void Start()
    {
         
        
    }

        
     public void SetupNewLevel()
     {
        
           
         allGroundPieces = FindObjectsOfType<GroundPiece>();

     }

     public void Awake()
     {

                if (singleton == null)
                {
                    singleton = this;
                }
                else if (singleton != this)
                {
                    Destroy(gameObject);
                    DontDestroyOnLoad(gameObject);
                }
     }
        public void CheckComplete()
        {
            bool isFinished = true;

            for (int i = 0; i < allGroundPieces.Length; i++)
            {
                if (allGroundPieces[i].isColored == false)
                {
                    isFinished = false;

                    break;
                }
             
            }

            if (isFinished)
            {
             particles.Play();
              NextLevel();
              spawnAudio.PlayOneShot(spawnSound, 0.3f);
              
            }
        }

        public void OnEnable()
        {
           particles.Play();

                SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }
         public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
         {
              

              SetupNewLevel();
         }

            public void NextLevel()
            {
                if (SceneManager.GetActiveScene().buildIndex == 3)
                {

                    SceneManager.LoadScene(0);

                }
                else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }

            }

        

    
    

        
   
}
