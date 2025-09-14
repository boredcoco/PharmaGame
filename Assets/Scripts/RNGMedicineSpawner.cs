using UnityEngine;

public class RNGMedicineSpawner : MedicineSpawner
{
    public static RNGMedicineSpawner Instance { get; private set; }
    // weights for rng probability, need to be length = 2, the 0th index is correct medicine
    [SerializeField] private float[] weights;

    private void Awake()
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
    public override void SpawnMedicine()
    {

      int weightedIndexChosen = GetRandomWeightedIndex();

      if (weightedIndexChosen == 0)
      {
        SpawnMedicineCorrect();
      }
      else if (weightedIndexChosen == 1)
      {
        SpawnMedicineWrongWeight();
      }
      else if (weightedIndexChosen == 2)
      {
        SpawnMedicineNotPackedProperly();
      }
    }

    public int GetRandomWeightedIndex()
    {
        // Get the total sum of all the weights.
        float weightSum = 0f;
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
        }

        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = weights.Length - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, weightSum) < weights[index])
            {
                return index;
            }

            // Remove the last item from the sum of total untested weights and try again.
            weightSum -= weights[index++];
        }

        // No other item was selected, so return very last index.
        return index;
    }
}
