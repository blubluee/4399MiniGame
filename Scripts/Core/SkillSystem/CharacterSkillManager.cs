
using System.Collections;
using System.Linq;
using UnityEngine;

/// <summary>
/// 技能管理器
/// </summary>
public class CharacterSkillManager : MonoBehaviour
{
    // 技能列表
    public SkillData[] skills;

    private void Start()
    {
        foreach (var t in skills)
        {
            InitSkill(t);
        }
    }
    
    
    private void InitSkill(SkillData data)
    {
        data.skillPrefab = ResourceManager.Load<GameObject>(data.skillPrefabName);
        data.owner = gameObject;
    }
    
    // 准备技能
    public SkillData PrepareSkill(int skillID)
    {
        SkillData data = skills.FirstOrDefault(skill => skill.skillID == skillID);
        float mp = GetComponent<CharacterStatus>().mp;
        if (data != null && data.cdRemainTime <= 0 && mp >= data.mpCost) // 检测冷却时间、魔法值
            return data;
        
        return null;
    }
    
    // 释放技能
    public void GenerateSkill(SkillData data)
    {
        // 创建技能预制件
        GameObject skillGo = Instantiate(data.skillPrefab, transform.position, transform.rotation);
        
        // 销毁技能
        Destroy(skillGo, data.duration);
        
        // 开启技能冷却
        StartCoroutine(SkillCoolDown(data));
    }
    
    // 技能冷却
    private IEnumerator SkillCoolDown(SkillData data)
    {
        data.cdRemainTime = data.cdTime;
        while (data.cdRemainTime > 0)
        {
            yield return new WaitForSeconds(1); // TODO: 每次减少1秒，可以改为每帧减少，更加精确
            data.cdRemainTime--;
        }
    } 
}
