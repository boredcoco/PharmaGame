using UnityEngine;

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
        notificationController.SetNotification(PrescriptionViolation.IncorrectName, _name, 1);
      }
      else if (medicine._chemicalName != _chemicalName)
      {
        notificationController.SetNotification(PrescriptionViolation.IncorrectFormula, _name, 1);
      }
      else if (medicine._weight != _weight)
      {
        notificationController.SetNotification(PrescriptionViolation.IncorrectWeight, _name, 1);
      }
      return medicine._name == _name && medicine._chemicalName == _chemicalName && medicine._weight == _weight;
    }

    public bool VerifyMedicineWhenDoctorCalled()
    {
      bool result = medicine._name == _name && medicine._chemicalName == _chemicalName && medicine._weight == _weight;

      if (!result)
      {
        return result;
      }

      notificationController.SetNotificationFalseAlarm(medicine._name, 1);
      return result;
    }
}
