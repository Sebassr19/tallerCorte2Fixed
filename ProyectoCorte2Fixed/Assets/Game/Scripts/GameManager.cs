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

    private Dictionary<string, int> fruitValues = new Dictionary<string, int>();

    private void Awake()
    {
        if (!ReferenceEquals(Instance, null) && !ReferenceEquals(Instance, this))
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGameData();
    }

    private void Start()
    {
        globalTime = 0;
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void SumarItem(string itemName, int itemValue)
    {
        int valueToAdd = GetValueFromJson(itemName, itemValue);

        switch (itemName)
        {
            case "Apple":
                totalApple += valueToAdd;
                Debug.Log("Total Apple: " + totalApple);
                break;

            case "Orange":
                totalOrange += valueToAdd;
                Debug.Log("Total Orange: " + totalOrange);
                break;

            case "Banana":
            case "Bananas":
                totalBanana += valueToAdd;
                Debug.Log("Total Banana: " + totalBanana);
                break;

            case "Kiwi":
            case "kiwi":
                totalKiwi += valueToAdd;
                Debug.Log("Total Kiwi: " + totalKiwi);
                break;

            default:
                Debug.LogWarning("Item no reconocido: " + itemName);
                break;
        }
    }

    private int GetValueFromJson(string itemName, int fallbackValue)
    {
        if (string.IsNullOrEmpty(itemName))
            return fallbackValue;

        if (fruitValues.TryGetValue(itemName, out int jsonValue))
            return jsonValue;

        Debug.LogWarning("No se encontró valor en JSON para: " + itemName + ". Se usa el valor del ItemData.");
        return fallbackValue;
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

        if (ReferenceEquals(data, null))
        {
            Debug.LogWarning("GameData es null");
            return;
        }

        if (ReferenceEquals(data.Coleccionables, null) || data.Coleccionables.Length < 1)
        {
            Debug.LogWarning("La lista Coleccionables está vacía o es null");
            return;
        }

        fruitValues.Clear();

        foreach (CollectibleData collectible in data.Coleccionables)
        {
            if (!string.IsNullOrEmpty(collectible.id))
            {
                fruitValues[collectible.id] = collectible.valor;
                Debug.Log("Cargado desde JSON: " + collectible.id + " = " + collectible.valor);
            }
        }
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
    public CollectibleData[] Coleccionables;
    public MissionData[] missions;
}

[Serializable]
public class CollectibleData
{
    public string id;
    public string nombre;
    public string rareza;
    public int valor;
    public string iconId;
}

[Serializable]
public class MissionData
{
    public string id;
    public string titulo;
    public string descripcion;
    public string coleccionable;
}