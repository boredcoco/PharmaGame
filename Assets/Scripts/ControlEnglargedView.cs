using UnityEngine;
using UnityEngine.UI;

public class ControlEnglargedView : MonoBehaviour
{
    [SerializeField] Image _medicineImage;

    public void SetMedicineImage(string urlToImg)
    {
      _medicineImage.gameObject.SetActive(true);
      Sprite sprite = Resources.Load<Sprite>(urlToImg);
      Debug.Log(sprite);
      Debug.Log(urlToImg);
      _medicineImage.sprite = sprite;
    }
}
