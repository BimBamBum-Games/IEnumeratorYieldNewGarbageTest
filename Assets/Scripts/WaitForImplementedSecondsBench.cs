using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForImplementedSecondsBench : MonoBehaviour {
    [SerializeField] [Min(0)] int _stepCount;
    [SerializeField] [Min(0.0001f)] float _waitTime;
    WaitForDynamicSeconds _wait4dynamicSeconds = new WaitForDynamicSeconds(1f);
    void Start()
    {
        StartCoroutine(IRunWaitForSeconds());
    }
    public IEnumerator IRunWaitForSeconds() {
        Debug.LogWarning("IEnumerator Dynamic metodu basladi.");
        int stepper = _stepCount;
        while (stepper > 0) {
            stepper--;
            _wait4dynamicSeconds.SetNewDynamicSeconds(_waitTime);
            //Debug.LogWarning("Test : Dongu");
            yield return _wait4dynamicSeconds;
        }
        Debug.LogWarning("IEnumerator Dynamic metodu sonlandi.");
    }

}

public class WaitForDynamicSeconds : CustomYieldInstruction {
    //Dinamik olarak WaitForSeconds classi olusturma. Her bir yeni IEnumerator cagrisinin basinda resetlenmesi gerekir.
    private DateTime _lifeTime;
    public WaitForDynamicSeconds(double lifeTime) {
        //DateTime kullanilarak global alanda newlenebilirlik saglandi.
        _lifeTime = DateTime.Now.AddSeconds(lifeTime);
    }

    public void SetNewDynamicSeconds(double lifeTime) {
        _lifeTime = DateTime.Now.AddSeconds(lifeTime);
    }

    public override bool keepWaiting {
        get {
            return DateTime.Now < _lifeTime;
        }
    }
}