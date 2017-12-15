using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonController : MonoBehaviour {

	public Skill skill;

	public void SkillClick(){
		BattleCanvasController.instance.SkillClicked(skill);
	}
}
