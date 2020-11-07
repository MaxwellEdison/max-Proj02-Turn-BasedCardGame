using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    Button nextSceneButton;
    public Scene _proj2TestScene;
    private void Start()
    {
        nextSceneButton = gameObject.GetComponent<Button>();
        nextSceneButton.onClick.AddListener(PlayScene);
    }
    
    void PlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
