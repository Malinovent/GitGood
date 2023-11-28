using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "rename this asset", menuName = "Git good/Create Dialogue Data", order = 0)]
public class DialogueData : ScriptableObject
{
    public Sprite characterPortait;
    public string characterName;

    public string[] boxText;

}
