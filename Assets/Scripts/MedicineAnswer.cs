using UnityEngine;
using System.Text.RegularExpressions;

public class MedicineAnswer : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private ChemicalName _chemicalName;
    [SerializeField] private float _weight = 5f; // in mg

    // keep track of Medicine
    private Medicine medicine;

    private NotificationController notificationController;

    private void Start()
    {
      medicine = GetComponent<Medicine>();
      notificationController = GameObject.FindWithTag(Tags.NotificationController).GetComponent<NotificationController>();
    }

    public bool VerifyMedicine()
    {
      if (medicine._name != _name)
      {
        notificationController.SetNotification(PrescriptionViolation.IncorrectName, _name);
      }
      else if (medicine._chemicalName != _chemicalName)
      {
        notificationController.SetNotification(PrescriptionViolation.IncorrectFormula, _name);
      }
      else if (medicine._weight != _weight)
      {
        notificationController.SetNotification(PrescriptionViolation.IncorrectWeight, _name);
      }
      else if (!medicine.isPackedProperly)
      {
        notificationController.SetNotification(PrescriptionViolation.NotSealed, _name);
      }
      return medicine._name == _name && medicine._chemicalName == _chemicalName && medicine._weight == _weight;
    }

    public bool VerifyMedicineWhenDoctorCalled()
    {
      bool result = medicine._name == _name && medicine._chemicalName == _chemicalName && medicine._weight == _weight && medicine.isPackedProperly;

      if (!result)
      {
        return result;
      }

      notificationController.SetNotificationFalseAlarm(medicine._name);
      return result;
    }

    public string GetName()
    {
      return _name;
    }

    public string GetChemicalName()
    {
      return Regex.Replace(nameof(_chemicalName), "(?<=[a-z])([A-Z])", " $1");
    }
}
