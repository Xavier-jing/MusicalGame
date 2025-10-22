using UnityEngine;
using UnityEngine.UIElements;

public class Level1UiController: MonoBehaviour
{
    private Button _btnRhythm1;
    private Button _btnRhythm2;
    private Button _btnUltimate;
    private Button _btnSecSkill;
    private Button _btnAttackSkill;

    //技能解锁状态
    private bool _hasSecSkill = false;
    private bool _hasUltimate = false;

    private VisualElement _root;
    public void OnEnable()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;
        
        _btnRhythm1 = _root.Q<Button>("Btn_Rhythm1");
        _btnRhythm2 = _root.Q<Button>("Btn_Rhythm2");
        _btnSecSkill = _root.Q<Button>("Btn_SecSkill");
        _btnUltimate = _root.Q<Button>("Btn_Ultimate");
        _btnAttackSkill = _root.Q<Button>("Btn_AttackSkill");
        
        //按钮事件
        _btnSecSkill.clicked += OnSecSkillClick;
        _btnUltimate.clicked += OnUltimateClick;
        _btnAttackSkill.clicked += OnAttackClick;

        UpdateSkillButtons();

    }
    
    //模拟拾取道具
    public void UnlockSkill(string skillName)
    {
        switch (skillName)
        {
            case"SecSkill":
                _hasSecSkill = true;
                break;
            case"Ultimate":
                _hasUltimate = true;
                break;
        }
        UpdateSkillButtons();
    }
    private void UpdateSkillButtons()
    {
        // 更新按钮可交互性 + 样式
        UpdateButtonState(_btnSecSkill, _hasSecSkill);
        UpdateButtonState(_btnUltimate, _hasUltimate);
    }

    private void UpdateButtonState(Button btn, bool unlocked)
    {
        btn.SetEnabled(unlocked);
        if (unlocked)
            btn.RemoveFromClassList("locked");
        else
            btn.AddToClassList("locked");
    }

    // 点击逻辑
    private void OnSecSkillClick()
    {
        if (!_hasSecSkill) return;
        Debug.Log("释放空中绞杀技能！");
    }

    private void OnUltimateClick()
    {
        if (!_hasUltimate) return;
        Debug.Log("释放大招！");
    }

    private void OnAttackClick()
    {
        Debug.Log("普通攻击或轮盘技能释放！");
    }

    // 🎵 节奏高亮函数（由节奏系统调用）
    public void HighlightRhythmButton(int index)
    {
        Button btn = index == 1 ? _btnRhythm1 : _btnRhythm2;
        btn.AddToClassList("highlight");
        // 自动消失
        btn.schedule.Execute(() => btn.RemoveFromClassList("highlight")).StartingIn((long)0.3f);
    }
}
