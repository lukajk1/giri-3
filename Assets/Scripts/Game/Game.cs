using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// The most general manager. All data that persists throughout runs (settings) runs through here.
/// </summary>
public class Game : MonoBehaviour
{
    public static Game i;

    // order matters here. The order corresponds to the build integer used by the build
    public enum Scene
    {
        MainMenu,
        Game
    }

    private void Awake()
    {
        if (i == null) i = this;
        else
        {
            Debug.LogWarning($"multiple {this} singletons found. (destroying extra)");
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadSceneAsync((int)scene);
    }

}