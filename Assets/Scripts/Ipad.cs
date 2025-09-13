using UnityEngine;

public class Ipad : MonoBehaviour
{
    [SerializeField] private GameObject _ipadPnl;
    [SerializeField] private GameObject _enlargedControllerview;

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
}
