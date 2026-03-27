using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [Header("Contenedor de puntos")]
    [SerializeField] private Transform spawnContainer;

    [Header("Prefabs de frutas")]
    [SerializeField] private GameObject[] fruitPrefabs;

    private Transform[] spawnPoints;

    private void Awake()
    {
        int count = spawnContainer.childCount;
        spawnPoints = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            spawnPoints[i] = spawnContainer.GetChild(i);
        }
    }

    private void Start()
    {
        SpawnRandom();
    }

    void SpawnRandom()
    {
        foreach (Transform point in spawnPoints)
        {
            int randomIndex = Random.Range(0, fruitPrefabs.Length);

            Instantiate(fruitPrefabs[randomIndex],
                        point.position,
                        Quaternion.identity);
        }
    }
}
