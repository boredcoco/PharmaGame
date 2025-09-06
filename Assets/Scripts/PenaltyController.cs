using System.Collections.Generic;
using UnityEngine;

public class PenaltyController : MonoBehaviour
{
    [SerializeField] private int[] _penaltyAmtKeys;
    [SerializeField] private int[] _penaltyAmtValues;

    private Dictionary<int, int> penaltyDic;
    private int noOfMistakes;
    private int lastDrawnPenalty;

    private void Start()
    {
        noOfMistakes = 0;
        lastDrawnPenalty = 0;
        penaltyDic = new Dictionary<int, int>();

        for (int i = 0; i < _penaltyAmtValues.Length; i++)
        {
          penaltyDic.Add(_penaltyAmtKeys[i], _penaltyAmtValues[i]);
        }
    }

    public int GetPenalty()
    {
      noOfMistakes += 1;
      if (penaltyDic.ContainsKey(noOfMistakes))
      {
        lastDrawnPenalty = penaltyDic[noOfMistakes];
      }
      return lastDrawnPenalty;
    }
}
