using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForSecondsBench : MonoBehaviour
{
    [SerializeField] int _stepcount;
    [SerializeField] [Min(0.00001f)] float _waitTime;
    [ContextMenu("WaitForSeconds")]
    private void Awake() {
        RunWaitForSeconds();
    }
    public void RunWaitForSeconds() {
        StartCoroutine(IRunWaitForSeconds());
    }

    public IEnumerator IRunWaitForSeconds() {
        Debug.LogWarning("IEnumerator NewYield metodu basladi.");
        int stepper = _stepcount;
        while (stepper > 0) {
            stepper--;
            yield return new WaitForSecondsRealtime(_waitTime);
        }
        Debug.LogWarning("IEnumerator NewYield metodu sonlandi.");
    }

}
