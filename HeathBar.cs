using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    // Start is called before the first frame update
    Slider slider;
    void Start()
    {
        slider=GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void decreaseValue(int hp)
    {
        slider.value=hp;
    }
}
