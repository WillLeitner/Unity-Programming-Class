using UnityEngine;

public class ControlFlow : MonoBehaviour
{
    public bool flag = true;

    void Start()
    {
        if(flag)
        {
            Debug.LogFormat("Boolean flag is set.");
        }
        else
        {
            Debug.LogFormat("Boolean flag isn't set.");
        }
        for (int x = 1; x < 11; x++)
        {
            Debug.LogFormat($"The {x} power of 2 is {Mathf.Pow(2,x)}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
