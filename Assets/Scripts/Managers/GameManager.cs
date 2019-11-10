using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager levelManager;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Haptics.Handler.Instance.Trigger(Haptics.Feedback.Type.Success);

        PersistentData.Instance.Load();
        PersistentData.Instance.Init();
    }

    private void Start()
    {
        levelManager.Load();
        levelManager.Init();
    }
}
