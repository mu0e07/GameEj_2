using UnityEngine;

public class GMManager2 : MonoBehaviour
{
    public static GMManager2 Instance;

    public int selectedCharacter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}