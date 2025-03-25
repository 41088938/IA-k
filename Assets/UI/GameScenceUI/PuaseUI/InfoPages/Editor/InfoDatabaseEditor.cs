using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(InfoPageDatabase))]
public class InfoDatabaseEditor : Editor
{
   private InfoPageDatabase InfoDatabase;

    private void OnEnable()
    {
        InfoDatabase=target as InfoPageDatabase;//allow enter database
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();//Creat button at database in Unity
        if(GUILayout.Button("PagesApply",GUILayout.Height(30))){
            PagesApply();
         }
    }
    private void PagesApply()
    {
        string filePath= Path.Combine(Application.dataPath,"GameInfo.cs");//create file to save the info pages data
        string code= "public enum infoPages{";
        foreach (InfoPages page in InfoDatabase.gamePlayinfo)
        {
            code+= page.pageID + ",";
        }
        code+="}";
        File.WriteAllText(filePath,code);
        AssetDatabase.ImportAsset("Assets/GameInfo.cs");
        
    }
}
