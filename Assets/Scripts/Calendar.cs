using UnityEngine;
using System;
using TMPro;

public class Calendar : MonoBehaviour
{
    [SerializeField] private TMP_Text _dateText;
    private DateTime todaysDate;

    private void Start()
    {
        todaysDate = DateTime.Today;
        _dateText.text = $"Today is\n{todaysDate.ToString("yyyy-MM-dd")}";
    }

}
