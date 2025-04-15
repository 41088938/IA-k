using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ResultCheckList : MonoBehaviour
{
    [SerializeField]
    private GameObject _resultCheckListPanel = null;

    [SerializeField]
    private GameObject _contentArea = null;


    [SerializeField]
    private GameObject _leftPos = null;

    [SerializeField]
    private GameObject _tickItem = null;

    [SerializeField]
    private GameObject _rightPos = null;

    [SerializeField]
    private GameObject _crossItem = null;

    [SerializeField]
    private float _spaceFromTop = 110;

    [SerializeField]
    private float _space = 90;

    static private ResultCheckList m_resultCheckList = null;

    private List<GameObject> tickItems = null;
    private List<GameObject> crossItems = null;

#if UNITY_EDITOR
    [ContextMenu("Add Debug Tick Item")]
    private void AddDebugTickItem()
    {
        AddTickItem("Debug Debug Debug Debug");
    }
    [ContextMenu("Add Debug Cross Item")]
    private void AddDebugCrossItem()
    {
        AddCrossItem("Debug Debug Debug Debug");
    }
#endif

    private ResultCheckList()
    {
    }

    private void Awake()
    {
        Debug.Assert(_resultCheckListPanel, this);
        Debug.Assert(_contentArea, this);
        Debug.Assert(_leftPos, this);
        Debug.Assert(_tickItem, this);
        Debug.Assert(_rightPos, this);
        Debug.Assert(_crossItem, this);
        tickItems = new List<GameObject>();
        crossItems = new List<GameObject>();
        m_resultCheckList = this;
        ResizeTheContentArea();
    }

    private void OnDestroy()
    {
        m_resultCheckList = null;
    }

    [ContextMenu("ShowCheckList")]
    public void ShowCheckList()
    {
        _resultCheckListPanel.SetActive(true);
        ResizeTheContentArea();
    }

    [ContextMenu("HideCheckList")]
    public void HideCheckList()
    {
        _resultCheckListPanel.SetActive(false);
    }

    static public ResultCheckList GetResultCheckList()
    {
        return m_resultCheckList;
    }

    public void AddTickItem(string _str)
    {
        GameObject find = tickItems.Find((obj) =>
        {
            return obj.name.Contains(_str);
        });
        if (find != null) return;


        GameObject newObj = GameObject.Instantiate(_tickItem);
        newObj.transform.SetParent(_contentArea.transform);
        newObj.transform.localScale = Vector3.one;
        //newObj.transform.localPosition = _leftPos.transform.localPosition;
        newObj.GetComponent<RectTransform>().localPosition = _leftPos.GetComponent<RectTransform>().localPosition;
        newObj.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
        //newObj.GetComponent<RectTransform>().sizeDelta = new Vector2(175, 100);
        newObj.name = newObj.name + "(key: " + _str + ")";

        TextMeshProUGUI component = null;
        for (int i = 0; i < newObj.transform.childCount; ++i)
        {
            component = newObj.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            if (component)
            {
                component.text = _str;
                break;
            }
        }

        tickItems.Add(newObj);
        ResizeTheContentArea();
    }

    public void AddCrossItem(string _str)
    {
        GameObject find = crossItems.Find((obj) =>
        {
            return obj.name.Contains(_str);
        });
        if (find != null) return;

        GameObject newObj = GameObject.Instantiate(_crossItem);
        newObj.transform.SetParent(_contentArea.transform);
        newObj.transform.localScale = Vector3.one;
        //newObj.transform.localPosition = _rightPos.transform.localPosition;
        newObj.GetComponent<RectTransform>().localPosition = _rightPos.GetComponent<RectTransform>().localPosition;
        newObj.GetComponent<RectTransform>().localScale = new Vector3(1.1f, 1.1f, 1.1f);
        //newObj.GetComponent<RectTransform>().sizeDelta =new Vector2(175,100);
        newObj.name = newObj.name + "(key: " + _str + ")";

        TextMeshProUGUI component = null;
        for (int i = 0; i < newObj.transform.childCount; ++i)
        {
            component = newObj.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
            if (component)
            {
                component.text = _str;
                break;
            }
        }

        crossItems.Add(newObj);
        ResizeTheContentArea();
    }

    [ContextMenu("Remove Last Tick Item")]
    public void RemoveLastTickItem()
    {
        if (tickItems.Count == 0) return;
        Destroy(tickItems[tickItems.Count - 1]);
        tickItems.RemoveAt(tickItems.Count - 1);
        ResizeTheContentArea();
    }

    [ContextMenu("Remove Last Cross Item")]
    public void RemoveLastCrossItem()
    {
        if (crossItems.Count == 0) return;
        Destroy(crossItems[crossItems.Count - 1]);
        crossItems.RemoveAt(crossItems.Count - 1);
        ResizeTheContentArea();
    }

    [ContextMenu("Remove All")]
    public void RemoveAll()
    {
        foreach (GameObject obj in tickItems)
        {
            Destroy(obj);
        }
        tickItems.Clear();

        foreach (GameObject obj in crossItems)
        {
            Destroy(obj);
        }
        crossItems.Clear();
        ResizeTheContentArea();
    }

    [ContextMenu("ResizeTheContentArea")]
    private void ResizeTheContentArea()
    {
        int len = Mathf.Max(tickItems.Count, crossItems.Count);
        Vector2 sizeDelta = _contentArea.GetComponent<RectTransform>().sizeDelta;
        sizeDelta.y = (Mathf.Max(len, 1) + 0.5f) * _space;
        _contentArea.GetComponent<RectTransform>().sizeDelta = sizeDelta;

        Vector3 temp;
        float startY = sizeDelta.y / 2 - _spaceFromTop - _space / 2 * (len - 1);
        for (int i = 0; i < tickItems.Count; ++i)
        {
            temp = tickItems[i].transform.localPosition;
            temp.y = startY - _space * i;
            tickItems[i].transform.localPosition = temp;
        }
        for (int i = 0; i < crossItems.Count; ++i)
        {
            temp = crossItems[i].transform.localPosition;
            temp.y = startY - _space * i;
            crossItems[i].transform.localPosition = temp;
        }
    }
}
