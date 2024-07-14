using System;
using UnityEngine;


[Serializable]
public class SkillData
{
    /// <summary> 技能ID </summary>
    public int skillID;
    /// <summary> 技能名称 </summary>
    public string skillName;
    /// <summary> 技能描述 </summary>
    public string skillDesc;
    /// <summary> 技能图标 </summary>
    public string skillIcon;
    /// <summary> 冷却时间 </summary>
    public float cdTime;
    /// <summary> 冷却剩余时间 </summary>
    public float cdRemainTime;
    /// <summary> 技能等级 </summary>
    public int skillLevel;
    /// <summary> 魔法消耗 </summary>
    public int mpCost;
    /// <summary> 攻击距离 </summary>
    public float attackDistance;
    /// <summary> 攻击角度 </summary>
    public float attackAngle;
    /// <summary> 攻击目标Tags </summary>
    public string[] attackTargetTags;
    /// <summary> 攻击目标对象数组 </summary>
    [HideInInspector] public Transform[] attackTargets;
    /// <summary> 技能影响类型 </summary>
    public string[] impactType = {"CostMp", "Damage"};
    /// <summary> 伤害比率 </summary>
    public float atkRatio;
    /// <summary> 持续时间 </summary>
    public float duration;
    /// <summary> 伤害间隔 </summary>
    public float atkInterval;
    /// <summary> 技能释放者 </summary>
    [HideInInspector] public GameObject owner;
    /// <summary> 技能预制件名称 </summary>
    public string skillPrefabName;
    /// <summary> 技能预制件 </summary>
    public GameObject skillPrefab;
    /// <summary> 技能动画名称 </summary>
    public string animName;
    /// <summary> 受击特效名称 </summary>
    public string hitFxName;
    /// <summary> 受击特效预制件 </summary>
    [HideInInspector] public GameObject hitFxPrefab;
    // /// <summary> 攻击类型 (单攻，群体) </summary>
    // public SKillAttackType attackType;
    // /// <summary> 选择类型 (扇形，矩形) </summary>
    // public SelectorType selectorType;
}
