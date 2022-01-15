using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Transform transformPlayer;

    // Update is called once per frame
    // public GameObject spawnPointManager;
    // int lives = 3;
    // void Start(){
      
    //    spawnPointManager = GameObject.FindWithTag("Start");
    //    Debug.Log(spawnPointManager.transform.position);
       
    // }
    // void Update()
    // {
    //     if(transformPlayer.position.y < -5f){
    //         //Invoke("Restart", 0.5f);
    //         lives -=1;
    //         Debug.Log(spawnPointManager.transform.position);
    //         transformPlayer.position = spawnPointManager.transform.position;
    //     }
    // }

    void OnApplicationQuit(){
        SavePrefs();
    }
    public void SavePrefs(){
       
    }
    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}