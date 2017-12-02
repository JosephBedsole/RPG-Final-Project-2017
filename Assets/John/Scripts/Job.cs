using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job", menuName = "RPG/Job")]
public class Job : ScriptableObject {
	
	public string jobName = "";
	public List<UnlockableSkill> unlockableSkills;

	public List<Skill> GetSkills(int lvl){
		List<Skill> unlockedSkills = new List<Skill>();
		foreach (UnlockableSkill unlockable in unlockableSkills) {
			if (unlockable.lvl <= lvl) {
				unlockedSkills.Add(unlockable.skill);
			}
		}
		return unlockedSkills;
	}

	[System.Serializable]
	public class UnlockableSkill{
		public Skill skill;
		public int lvl;
	}
}