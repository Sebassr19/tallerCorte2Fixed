using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float globalTime;

    private int totalApple = 0;
    private int totalOrange = 0;
    private int totalKiwi = 0;
    private int totalBanana = 0;

    private Dictionary<ItemType, int> fruitValues = new Dictionary<ItemType, int>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    void Start()
    {
        globalTime = 0;
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalItem(ItemData item)
    {
        int valueToAdd = GetFruitValue(item);

        switch (item.itemType)
        {
            case ItemType.Apple:
                totalApple += valueToAdd;
                break;
            case ItemType.Orange:
                totalOrange += valueToAdd;
                break;
            case ItemType.Banana:
                totalBanana += valueToAdd;
                break;
            case ItemType.kiwi:
                totalKiwi += valueToAdd;
                break;
        }

        Debug.Log($"Se sumaron {valueToAdd} puntos para {item.itemType}");
    }

    private int GetFruitValue(ItemData item)
    {
        if (item == null)
            return 0;

        if (fruitValues.TryGetValue(item.itemType, out int jsonValue))
            return jsonValue;

        return item.itemValue;
    }

    private void LoadGameData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "GameData.json");

        if (!File.Exists(path))
        {
            Debug.LogWarning("No se encontró GameData.json en StreamingAssets");
            return;
        }

        string json = File.ReadAllText(path);
        GameData data = JsonUtility.FromJson<GameData>(json);

        if (data == null || data.fruits == null)
        {
            Debug.LogWarning("GameData.json está vacío o mal estructurado");
            return;
        }

        fruitValues.Clear();

        foreach (FruitJson fruit in data.fruits)
        {
            if (Enum.TryParse(fruit.itemType, out ItemType parsedType))
            {
                fruitValues[parsedType] = fruit.value;
            }
            else
            {
                Debug.LogWarning($"No se pudo leer el itemType '{fruit.itemType}' del JSON");
            }
        }

        Debug.Log("GameData.json cargado correctamente");
    }

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int TotalApple { get => totalApple; set => totalApple = value; }
    public int TotalOrange { get => totalOrange; set => totalOrange = value; }
    public int TotalKiwi { get => totalKiwi; set => totalKiwi = value; }
    public int TotalBanana { get => totalBanana; set => totalBanana = value; }
}

[Serializable]
public class GameData
{
    public FruitJson[] fruits;
}

[Serializable]
public class FruitJson
{
    public string itemType;
    public int value;
}