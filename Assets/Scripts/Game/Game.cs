using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


/// <summary>
/// The most general manager. All data that persists throughout runs (settings) runs through here.
/// </summary>

# region Global Enums
public enum Character
{
    Eivel,
    Ava,
    Vrail,
    Cassian
}
public enum GameScene
{
    MainMenu,
    Game
}

#endregion
public class Game : MonoBehaviour
{
    [SerializeField] private TransitionManager transition;
    [SerializeField] private AudioSource musicAudioSource;
    private float sceneTransitionDuration = 0.7f;

    public static bool PixellateOn;

    // order matters here. The order corresponds to the build integer used by the build
    #region singleton, DDOL
    public static Game i;
    private void Awake()
    {
        if (i == null) i = this;
        else
        {
            Debug.Log($"Destroying extra {this}");
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private void Start()
    {
        SaveSystem.Load();

        transition.Transition(TransitionManager.Type.BlackToScene, sceneTransitionDuration, null);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }

    #region scene management
    public void LoadScene(GameScene scene)
    {
        if ((int)scene == 0)
            Cursor.lockState = CursorLockMode.None;

        transition.Transition(TransitionManager.Type.SceneToBlack, sceneTransitionDuration, () =>
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadSceneAsync((int)scene);
        });
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transition.Transition(TransitionManager.Type.BlackToScene, sceneTransitionDuration);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Quit()
    {
        transition.Transition(TransitionManager.Type.SceneToBlack, sceneTransitionDuration, () =>
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        });

    }
    #endregion

}
