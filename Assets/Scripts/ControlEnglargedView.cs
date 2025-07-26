using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlEnglargedView : MonoBehaviour
{
    [SerializeField] private Image _medicineImage;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _weightText;
    [SerializeField] private TMP_Text _dateText;

    public void CloseMedicineView()
    {
      _medicineImage.gameObject.SetActive(false);
    }

    public void SetMedicineView(Medicine medicine)
    {
      _medicineImage.gameObject.SetActive(true);
      setMedicineImage(medicine._urlToImg);
      setNameText(medicine._name);
      setWeightText(medicine._weight);
      setDateText(medicine._issueDate);
    }

    private void setMedicineImage(string urlToImg)
    {
      // load up the sprite
      Sprite sprite = Resources.Load<Sprite>(urlToImg);
      Debug.Log(sprite);
      Debug.Log(urlToImg);
      _medicineImage.sprite = sprite;
    }

    private void setNameText(string name)
    {
      _nameText.text = name;
    }

    private void setWeightText(float weight)
    {
      _weightText.text = $"{weight}mg/dose";
    }

    private void setDateText(string dateTxt)
    {
      _dateText.text = dateTxt;
    }
}
