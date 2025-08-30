using UnityEngine;
using TMPro;

public class NotificationController : MonoBehaviour
{
    [SerializeField] private GameObject _notificationUI;
    [SerializeField] private TMP_Text _violationTxt;
    [SerializeField] private TMP_Text _penaltyTxt;

    public void CloseNotif()
    {
      _notificationUI.SetActive(false);
    }

    public void SetNotificationFalseAlarm(string medicineName, int penaltyAmt)
    {
      _violationTxt.text = $"{medicineName}: Nothing is incorrect about this prescription";
      if (penaltyAmt > 0)
      {
          _penaltyTxt.text = $"Warning issued: penalty - ${penaltyAmt}";
      }
      else
      {
          _penaltyTxt.text = "Warning issued: no penalty";
      }

      _notificationUI.SetActive(true);
    }

    public void SetNotification(PrescriptionViolation violationType, string medicineName, int penaltyAmt)
    {
        switch (violationType)
        {
            case PrescriptionViolation.IncorrectName:
                _violationTxt.text = $"{medicineName}: Name is misspelt";
                break;
            case PrescriptionViolation.IncorrectFormula:
                _violationTxt.text = $"{medicineName}: Chemical Formula is incorrect";
                break;
            case PrescriptionViolation.IncorrectWeight:
                _violationTxt.text = $"{medicineName}: Weight is incorrect";
                break;
            case PrescriptionViolation.IncorrectExpiry:
                _violationTxt.text = $"{medicineName}: Past expiry date";
                break;
            case PrescriptionViolation.NotSealed:
                _violationTxt.text = $"{medicineName}: Not packaged properly";
                break;
            default:
                _violationTxt.text = "The patient has died";
                break;
        }

        if (penaltyAmt > 0)
        {
            _penaltyTxt.text = $"Warning issued: penalty - ${penaltyAmt}";
        }
        else
        {
            _penaltyTxt.text = "Warning issued: no penalty";
        }

        _notificationUI.SetActive(true);
    }
}
