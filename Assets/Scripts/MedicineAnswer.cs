using UnityEngine;

public class MedicineAnswer : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ChemicalName _chemicalName;
    [SerializeField] private float _weight = 5f; // in mg

    // keep track of Medicine
    private Medicine medicine;

    private void Start()
    {
      medicine = GetComponent<Medicine>();
    }

    public bool VerifyMedicine()
    {
      bool result = medicine._name == _name && medicine._chemicalName == _chemicalName
      && medicine._weight == _weight;
      return result;
    }
}
