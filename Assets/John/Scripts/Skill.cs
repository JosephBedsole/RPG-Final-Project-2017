using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "RPG/Skill")]
public class Skill : ScriptableObject {
    public string skillName = "";
	public int damage = 0;
    public bool multiTarget = false;
}
