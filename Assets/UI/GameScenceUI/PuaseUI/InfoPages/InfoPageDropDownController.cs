using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Dropdown))]
public class InfoPageDropDownController : MonoBehaviour
{
    private Dropdown info_dropdown;
    private Dropdown Dropdown
    {
        get
        {
            if (info_dropdown == null)
            {
                info_dropdown=GetComponent<Dropdown>();
            }
            return info_dropdown;
        }
        
    }
    public Action<infoPages>onValueChanged;

    private void Start()
    {
        Dropdown.onValueChanged.AddListener(HandheldDropdownValueChanged);
    }

    [ContextMenu("UpdatePages()")]
    public void UpdatePages()
    {
        Dropdown.options.Clear();
       var values=Enum.GetValues(typeof(infoPages));
        foreach(infoPages infoPages in values)
        {
            Dropdown.options.Add(new Dropdown.OptionData(infoPages.ToString()));
        }
    }

  
    private void HandheldDropdownValueChanged(int value)
    {
        if (onValueChanged != null)
        {
            onValueChanged((infoPages)value);
         
        }
    }
    public void moveToNextPage( )
    {
       Dropdown.value=Dropdown.value+1;
        
    }
    public void moveToBackPage()
    {
        Dropdown.value = Dropdown.value - 1;
    }
}
