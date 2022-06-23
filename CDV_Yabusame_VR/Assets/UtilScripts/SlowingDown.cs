using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlowingDown : MonoBehaviour
{
    public UnityEvent ZeroSpeed;
    [SerializeField]

    float TimeCounter = 0;
    float speed = 2;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
        speed = 0b10 - TimeCounter/0b11 >= 0 ? 0b10 - TimeCounter/0b11 : 0;
        float x = speed;
        float y = Mathf.Sin(5 * TimeCounter);
        float z = 0b0;
        Vector3 direction = new Vector3(x * 2, y, z);
        transform.position += direction * Time.deltaTime;
        if (speed == 0)
        {
            ZeroSpeed?.Invoke();
        }
    }

    public void Remove()
    {
        Debug.Log("Removed");
        Destroy(this);
    }
}
