using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPageManager : MonoBehaviour
{
    public InfoPageDatabase infoPageDatabase;
    public InfoPageController pageController;
    public InfoPageDropDownController infoDropDownController;
    public infoPages infoPageToShow;
    InfoPages page;

    public void Start()
    {
        infoDropDownController.onValueChanged += HandheldDropdownValueChanged;

        showPages();
    }
    public void showPages()
    {
        page=infoPageDatabase.gamePlayinfo[(int)infoPageToShow];
        pageController.showPages(page, infoPageDatabase);
    }
    public void nextPages()
    {
        infoDropDownController.moveToNextPage();
        infoDropDownController.onValueChanged += HandheldDropdownValueChanged;
        showPages();
    }
    public void BackPage()
    {
        infoDropDownController.moveToBackPage();
        infoDropDownController.onValueChanged += HandheldDropdownValueChanged;
        showPages();
    }
    private void HandheldDropdownValueChanged(infoPages infoPage)
    {
        infoPageToShow=infoPage;
    }
}
