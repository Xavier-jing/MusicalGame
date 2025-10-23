using UnityEngine;
/// <summary>
/// ��Ʒ�ռ�
/// </summary>

public class Collection : MonoBehaviour
{
    [SerializeField]
    private bool isCollected = true;
    private Dispatcher dispatcher;
    [SerializeField]
    private Sprite itemSprite;

    private void Awake()
    {
        dispatcher = GetComponent<Dispatcher>();
    }

    public void AddItem()
    {
        if (dispatcher == null) return;
        if(isCollected && dispatcher.isCombo == true) 
        {
            //����UI
        }
    }

    public Sprite GetSprite() 
    {
        if (isCollected && dispatcher.isCombo == true)
        {
            return itemSprite;
        }
        else 
            return null;
    } //��ȡ��ƷͼƬ
}
