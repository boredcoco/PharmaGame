using UnityEngine;

public class MedicineSpawner : MonoBehaviour
{
    public static MedicineSpawner Instance { get; private set; }

    [SerializeField] private GameObject[] _medicinePrefabs; // Assign in Inspector
    [SerializeField] private Vector3 _spawnPosition;

    private GameObject currentMed;

    [SerializeField] private float _weightOffset = 1f;
    [SerializeField] private int[] _spawnOrder;
    private int _orderPointer;

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
      _orderPointer = 0;
      SpawnMedicine();
    }

    /// <summary>
    /// Spawns a medicine prefab at a given position and rotation.
    /// </summary>
    public void SpawnMedicine()
    {
      if (_orderPointer > _spawnOrder.Length - 1)
      {
        _orderPointer = 0;
      }
      if (_spawnOrder[_orderPointer] == 0)
      {
        SpawnMedicineCorrect();
      }
      else if (_spawnOrder[_orderPointer] == 1)
      {
        SpawnMedicineWrongWeight();
      }
      _orderPointer += 1;
    }
    public void SpawnMedicineCorrect()
    {
        if (currentMed != null)
        {
            Destroy(currentMed);
        }

        int randomNumber = Random.Range(0, _medicinePrefabs.Length); // rng the prefab

        currentMed = Instantiate(_medicinePrefabs[randomNumber], _spawnPosition, Quaternion.identity);
    }

    public void SpawnMedicineWrongWeight()
    {
      if (currentMed != null)
      {
          Destroy(currentMed);
      }

      int randomNumber = Random.Range(0, _medicinePrefabs.Length); // rng the prefab

      currentMed = Instantiate(_medicinePrefabs[randomNumber], _spawnPosition, Quaternion.identity);
      currentMed.GetComponent<Medicine>().RngMedWeight(_weightOffset);
    }

}
