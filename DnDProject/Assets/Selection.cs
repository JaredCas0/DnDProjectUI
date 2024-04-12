using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selection : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    public void GetVal()
    {
        int picked = dropdown.value;
        Debug.Log(picked);
    }
}
