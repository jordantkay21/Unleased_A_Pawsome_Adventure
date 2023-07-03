using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                if (typeof(T).ToString() == "Player")
                {

                }
                else
                {
                    Debug.Log(typeof(T).ToString() + " is Null");
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = (T)this;
        Init();
    }

    public virtual void Init()
    {
        //Optional to Override
    }
}
