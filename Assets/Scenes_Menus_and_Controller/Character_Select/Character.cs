using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]//can be shared/accessed on another file
public class Character
{
    //reference objects per character
    public GameObject prefab;
    public string name;
    public Sprite icon;
}
