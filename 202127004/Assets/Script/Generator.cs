using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    List<int> existList = new();

    private void Awake()
    {
        int value = 0;
        for (int forth = 0; forth < 5; forth++)
        {
            for (int third = 0; third < 10; third++)
            {
                for (int second = 0; second < 10; second++)
                {
                    for (int first = 0; first < 10; first++)
                    {
                        if (value <= 5000 && !existList.Contains(value))
                            existList.Add(value);
                        value += 2;
                    }
                    value -= 9;
                }
                value -= 9;
            }
            value -= 9;
        }

        int returnValue = 0;
        for (int i = 1; i < 5001; i++)
        {
            if (!existList.Contains(i))
            {
                returnValue += i;
            }
        }

        Debug.Log(returnValue);
    }
}
