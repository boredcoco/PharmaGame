using UnityEngine;
using TMPro;

public class Ipad : MonoBehaviour
{
    [SerializeField] private GameObject _ipadPnl;
    [SerializeField] private GameObject _enlargedControllerview;

    // store objects here
    [SerializeField] private MedicineAnswer[] _medicines;

    // slots
    [SerializeField] private TMP_Text[] _nameDisplayslots;
    private int currentIndex = 0;

    private void Start()
    {
      currentIndex = 0;
      SetNameDisplaySlots();
    }

    public void ClosePanel()
    {
      _ipadPnl.SetActive(false);
    }

    private void OnMouseUp()
    {
      if (_enlargedControllerview.activeSelf)
      {
        // make sure no other UI is active
        return;
      }
      _ipadPnl.SetActive(true);
    }

    public void ForwardButtonClicked()
    {
      if (currentIndex >= _medicines.Length)
      {
        return;
      }
      SetNameDisplaySlots();
    }

    public void BackButtonClicked()
    {
      if (currentIndex <= _nameDisplayslots.Length)
      {
        return;
      }
      currentIndex -= 2 * _nameDisplayslots.Length;
      SetNameDisplaySlots();
    }

    private void SetNameDisplaySlots()
    {
      foreach (TMP_Text nameDisplaySlot in _nameDisplayslots)
      {
          if (currentIndex >= _medicines.Length)
          {
            nameDisplaySlot.gameObject.SetActive(false);
            currentIndex++;
            continue;
          }

          nameDisplaySlot.text = _medicines[currentIndex].GetName();
          nameDisplaySlot.gameObject.SetActive(true);
          currentIndex++;
      }
    }
}
