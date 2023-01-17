using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {
    void OnCollisionEnter(Collision other) {

        switch(other.gameObject.tag) {
            case "Friendly":
                Debug.Log("it's ok");
                break;
            case "Finished":
                Debug.Log("finished level");
                break; 
            case "Fuel":
                Debug.Log("fuel");
                break;
            default:
                Debug.Log("explode");
                ReloadLevel();
                break;
        
        }

        void ReloadLevel() {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
