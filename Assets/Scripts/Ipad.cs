using UnityEngine;

public class Ipad : MonoBehaviour
{
    [SerializeField] private GameObject _ipadPnl;

    public void ClosePanel()
    {
      _ipadPnl.SetActive(false);
    }

    private void OnMouseUp()
    {
      Debug.Log("HERE");
      _ipadPnl.SetActive(true);
    }
}
