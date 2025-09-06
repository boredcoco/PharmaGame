using UnityEngine;

public class CallDoctor : MonoBehaviour
{
    private MedicineSpawner medSpawner;

    private void Start()
    {
      medSpawner = GameObject.FindWithTag(Tags.MedicineSpawner).GetComponent<MedicineSpawner>();
    }

    public void CallDoc()
    {
      // insert functionality here
      bool result = ValidateMedicine();
      medSpawner.SpawnMedicine();
    }

    private bool ValidateMedicine()
    {
      GameObject medicine = GameObject.FindWithTag(Tags.Medicine);
      MedicineAnswer med = medicine.GetComponent<MedicineAnswer>();

      return med.VerifyMedicineWhenDoctorCalled();
    }
}
