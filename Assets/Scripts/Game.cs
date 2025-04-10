using UnityEngine;
public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public int SurgeriesDone { get; private set; }
    public int Score { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {

    }
}
