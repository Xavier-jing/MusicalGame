using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UiController.LevelUIController
{
    public class TextController : MonoBehaviour
    {
        private Label _textLabel;

        // 对话内容（按顺序一行一行显示）
        private readonly List<string> _dialogues = new List<string>
        {
            "【室友？】：蓝月将节拍简化为左右两侧的按键。",
            "【室友？】：跟随节拍，追击虫族，清理电子馆藏。",
            "【室友？】：作为你的AI助手",
            "我将协助你校准新设备，降低延迟。",
            "（音乐道具筝）",
            "【室友？】：频率校准中……这是只为你开启的通道。",
            "（蘑菇）",
            "【室友？】：试试借助节拍采摘它，有惊喜。",
            "（护盾触发）",
            "【室友？】：被你发现了。数据攻击过滤权限已开启。",
            "（技能1·分割）",
            "【室友？】：战斗协议「分割」已激活。请小心运用。",
            "【室友？】：它能摧毁垃圾数据，也会伤害你的数据身体。",
            "（蟪蛄出场）",
            "【室友？】：过时的杂音不该打扰你。",
            "（技能2·索引）",
            "【室友？】：安全距离计算完成。",
            "蓝月为你开启了远程攻击技能。你可以从远处解决威胁了。",
            "（音乐道具鼓）",
            "【室友？】：跟着鼓点，穿过这片菌林。",
            "（技能3·照见）",
            "【室友？】：我把我能给出的最高权限，都交给你了。",
            "（嵌彩萤闪烁）",
            "【室友？】：高威胁目标已清除。检测到异常美学数据残留。",
            "（战斗结束）",
            "【室友？】：蓝月正在恢复宁静。",
            "区域清洁完成。准备载入下一阶段。",
            "（空拍）",
            "【室友？】：通行权限已更新。",
            "无论前往何方，我始终在这里，与你同步。"
        };

        private int _currentIndex = 0;  // 当前行索引
        private Coroutine _showCoroutine;

        public float displayInterval = 3f; // 每条对话间隔时间

        private void OnEnable()
        {
            var root = GetComponent<UIDocument>().rootVisualElement;
            _textLabel = root.Q<Label>("DialogText"); // Label 名需在 UXML 中命名为 "DialogText"

            // 启动逐行显示协程
            _showCoroutine = StartCoroutine(ShowDialogues());
        }

        private IEnumerator ShowDialogues()
        {
            while (_currentIndex < _dialogues.Count)
            {
                _textLabel.text = _dialogues[_currentIndex];
                _currentIndex++;

                yield return new WaitForSeconds(displayInterval);
            }

            // 全部显示完毕后可执行回调或隐藏UI
            _textLabel.text = "（对话结束）";
        }

        // 可供外部调用（例如点击“继续”按钮）手动显示下一句
        public void ShowNext()
        {
            if (_currentIndex < _dialogues.Count)
            {
                _textLabel.text = _dialogues[_currentIndex];
                _currentIndex++;
            }
            else
            {
                _textLabel.text = "（对话结束）";
            }
        }
    }
}


