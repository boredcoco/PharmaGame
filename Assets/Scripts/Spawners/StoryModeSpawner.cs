using System.Collections.Generic;
using UnityEngine;

public class StoryModeSpawner : MedicineSpawner
{
    // in story mode, a specific patient requires a spcific medicine
    // eg. Kline is the 3rd patient and his medicine is antacid
    [SerializeField] private int[] _order;
    [SerializeField] GameObject[] _correspondingObjects;
    private Dictionary<int, GameObject> customObjects;
    private int numOfPatients;

    public static StoryModeSpawner Instance { get; private set; }
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
      numOfPatients = 0;
      formCustomObjectsDictionary();

      SpawnMedicine();
    }

    private void formCustomObjectsDictionary()
    {
      customObjects = new Dictionary<int, GameObject>();
      for (int i = 0; i < _order.Length; i++)
      {
        customObjects[_order[i]] = _correspondingObjects[i];
      }
    }

    /// <summary>
    /// Spawns a medicine prefab at a given position and rotation.
    /// </summary>
    public override void SpawnMedicine()
    {
      numOfPatients += 1;
      // if there is a pre specified medicine, spawn it
      if (customObjects.ContainsKey(numOfPatients))
      {
        SetCustomObjectActive();
        return;
      }

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

    private void SetCustomObjectActive()
    {
      DestroyCurrentMed();
      GameObject obj = customObjects[numOfPatients];
      SetCurrentMed(obj);
      
      obj.transform.position = _spawnPosition;
      obj.SetActive(true);
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
