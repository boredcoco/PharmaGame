using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlEnglargedView : MonoBehaviour
{
    [SerializeField] private Image _medicineImage;
    [SerializeField] private TMP_Text _chemicalFormulaText;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _dateText;

    public bool isActive;

    private void Start()
    {
      isActive = false;
    }

    public void CloseMedicineView()
    {
      isActive = false;
      _medicineImage.gameObject.SetActive(false);
    }

    public void SetMedicineView(Medicine medicine)
    {
      isActive = true;
      _medicineImage.gameObject.SetActive(true);
      setMedicineImage(medicine.urlToImgUsed);
      setChemicalFormulaText(medicine._chemicalName.ToString());
      setNameText(medicine._name);
      setDateText(medicine._issueDate);
    }

    private void setMedicineImage(string urlToImg)
    {
      // load up the sprite
      Sprite sprite = Resources.Load<Sprite>(urlToImg);
      _medicineImage.sprite = sprite;
    }

    private void setNameText(string name)
    {
      _nameText.text = name;
    }

    private void setDateText(string dateTxt)
    {
      _dateText.text = dateTxt;
    }

    private void setChemicalFormulaText(string chemicalFormulaText)
    {
      _chemicalFormulaText.text = chemicalFormulaText;
    }
}
