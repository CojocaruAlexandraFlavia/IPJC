using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Transform transformPlayer;

    // Update is called once per frame
    void Update()
    {
        if(transformPlayer.position.y < -5f){
            Invoke("Restart", 0.5f);
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
