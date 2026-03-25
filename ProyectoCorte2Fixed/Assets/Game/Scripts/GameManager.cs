using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;

    private int totalApple = 0;
    private int totalOrange = 0;
    private int totalKiwi = 0;
    private int totalBanana = 0;


    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    void Start()
    {
        globalTime = 0;
    }


    void Update()
    {

    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalItem(ItemData item)
    {
        switch(item.itemType)
        {
            case ItemType.Apple:
                totalApple += item.itemValue;
                break;
                case ItemType.Orange:
                totalOrange += item.itemValue;
                break;
            case ItemType.Banana:
                totalBanana += item.itemValue;
                break;
            case ItemType.kiwi:
                totalKiwi += item.itemValue;
                break;
        }
    }

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalApple { get => totalApple; set => totalApple = value; }
    public int TotalOrange { get => totalOrange; set => totalOrange = value; }
    public int TotalKiwi { get => totalKiwi; set => totalKiwi = value; }
    public int TotalBanana { get => totalBanana; set => totalBanana = value; }
}
