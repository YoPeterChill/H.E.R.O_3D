using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancarGranadas : MonoBehaviour{

    public Granada _granada;
    public Transform localDeLancamento;
    public float forcaDeLancamento = 10;
    public float numeroDeGranadas = 20;
    public float tempoPorLancamento = 0.5f;
    //
    float cronometroGranada = 0;
    bool lancouGranada = false;

    void Update(){
        if (Input.GetKeyDown(KeyCode.G)) {
            if (localDeLancamento && numeroDeGranadas >= 0 && !lancouGranada) {
                numeroDeGranadas--;
                lancouGranada = true;
                Granada objGranada = Instantiate(_granada, localDeLancamento.position, transform.rotation) as Granada;
                Rigidbody rbGranada = objGranada.GetComponent<Rigidbody>();
                rbGranada.AddForce(Camera.main.transform.forward * forcaDeLancamento, ForceMode.Impulse);
            }
        }
        if (lancouGranada) {
            cronometroGranada += Time.deltaTime;
        }
        if (cronometroGranada >= tempoPorLancamento) {
            lancouGranada = false;
            cronometroGranada = 0;
        }
    }
}