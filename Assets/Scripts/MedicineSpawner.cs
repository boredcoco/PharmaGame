using UnityEngine;

public class MedicineSpawner : MonoBehaviour
{
    public static MedicineSpawner Instance { get; private set; }

    [SerializeField] private GameObject[] _medicinePrefabs; // Assign in Inspector
    [SerializeField] private Vector3 _spawnPosition;

    private GameObject currentMed;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // Optional: Persist across scenes
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
      SpawnMedicine();
    }

    /// <summary>
    /// Spawns a medicine prefab at a given position and rotation.
    /// </summary>
    public void SpawnMedicine()
    {
        if (currentMed != null)
        {
            Destroy(currentMed);
        }

        int randomNumber = Random.Range(0, _medicinePrefabs.Length); // rng the prefab

        currentMed = Instantiate(_medicinePrefabs[randomNumber], _spawnPosition, Quaternion.identity);
    }

}
