using System.Linq.Expressions;
using UnityEngine;
/// <summary>
/// ����ģʽ����
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonPattern<T> where T: class, new()
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();
            return instance;
        }
    }
}
