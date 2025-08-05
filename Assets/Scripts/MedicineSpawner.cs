using UnityEngine;

public class MedicineSpawner : MonoBehaviour
{
    public static MedicineSpawner Instance { get; private set; }

    [SerializeField] private GameObject _medicinePrefab; // Assign in Inspector
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

        currentMed = Instantiate(_medicinePrefab, _spawnPosition, Quaternion.identity);
    }

}
