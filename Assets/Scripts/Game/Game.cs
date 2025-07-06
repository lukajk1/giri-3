using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// The most general manager. All data that persists throughout runs (settings) runs through here.
/// </summary>
public class Game : MonoBehaviour
{
    [SerializeField] private TransManager transition;
    private float sceneTransitionDuration = 0.7f;
    public static Game i;

    // order matters here. The order corresponds to the build integer used by the build
    public enum SceneName
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
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        transition.Transition(TransManager.Type.BlackToScene, sceneTransitionDuration, null);
    }

    public void LoadScene(SceneName scene)
    {
        if ((int)scene == 0)
            Cursor.lockState = CursorLockMode.None;

        transition.Transition(TransManager.Type.SceneToBlack, sceneTransitionDuration, () =>
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadSceneAsync((int)scene);
        });
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transition.Transition(TransManager.Type.BlackToScene, sceneTransitionDuration);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Quit()
    {
        Application.Quit();
    }

}