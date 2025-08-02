using System.Collections;
using UnityEngine;
using TMPro;


public class ElectronicScale : MonoBehaviour
{
    [SerializeField] private TMP_Text _weightText;
    [SerializeField] private float _measureTime;
    [SerializeField] private string[] _waitTexts;
    [SerializeField] private string _defaultWeightTxt;

    // offset for contact ContactPoints
    [SerializeField] private float _yOffset = -4f;

    private bool isMedicineOn;
    private Medicine currentMedicine;
    private int index;

    private void Start()
    {
      isMedicineOn = false;
    }

    private void Update()
    {
      if (isMedicineOn && !Input.GetMouseButton(0))
      {
        HandleWeightingMed(); // only show the loading sign if the mouse is off
      }
      else // set the weight sign to the default of 0mg
      {
        _weightText.text = _defaultWeightTxt;
        index = 0;
        StopAllCoroutines();
      }
      // else if (currentMedicine != null)
      // {
      //   _weightText.text = $"{currentMedicine._weight}mg";
      // }
    }

    private void HandleWeightingMed()
    {
      if (index >= _waitTexts.Length - 1)
      {
        StopCoroutine(ShowMeasuringSign());
        _weightText.text = $"{currentMedicine._weight}mg";
      }
      else
      {
        StartCoroutine(ShowMeasuringSign());
      }
    }

    IEnumerator ShowMeasuringSign()
    {
      for (index = 0; index < _waitTexts.Length; index++)
      {
        _weightText.text = _waitTexts[index];
        yield return new WaitForSeconds(1f);
      }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag == Tags.Medicine)
      {
        ContactPoint2D[] contactPoints = new ContactPoint2D[collision.contactCount];
        collision.GetContacts(contactPoints);

        foreach (ContactPoint2D contactPoint in contactPoints)
        {
          if (contactPoint.point.y < _yOffset)
          {
            return;
          }
        }

        currentMedicine = collision.gameObject.GetComponent<Medicine>();
        isMedicineOn = true;
      }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
      if (collision.gameObject.tag == Tags.Medicine)
      {
        Debug.Log("entered ehre");
        StopAllCoroutines();
        isMedicineOn = false;
        currentMedicine = null;
        _weightText.text = _defaultWeightTxt;
        index = 0;
      }
    }

}
