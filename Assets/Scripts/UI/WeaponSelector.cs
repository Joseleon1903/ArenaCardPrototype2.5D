using Assets.Scripts.Logs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSelector : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Dropdown dropdown;

    public void OnChangeWeapon() {

        LoggerFile.Instance.DEBUG_LINE("Entering in OnChangeWeapon..");
        int valueSelect = dropdown.value;
        LoggerFile.Instance.DEBUG_LINE("value select: "+ dropdown.options[valueSelect].text);


    }

}
