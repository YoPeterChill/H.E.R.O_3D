using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Granada : MonoBehaviour
{

    public float tempoParaEstourar = 2;
    public float raioDaExplosao = 7;
    public float forcaDaExplosao = 7;
    public GameObject particulaDeExplosao;
    //
    float cronometro = 0;
    bool explodiu = false;

    void Update()
    {
        cronometro += Time.deltaTime;
        if (cronometro >= tempoParaEstourar && !explodiu)
        {
            explodiu = true;
            cronometro = 0;
            Explodir(transform.position, raioDaExplosao);
        }
    }

    void Explodir(Vector3 centro, float raio)
    {
        Collider[] hitColliders = Physics.OverlapSphere(centro, raio);
        for (int x = 0; x < hitColliders.Length; x++)
        {
            Rigidbody tempRB = hitColliders[x].GetComponent<Rigidbody>();
            if (tempRB)
            {
                tempRB.AddExplosionForce(forcaDaExplosao, transform.position, 10, 1, ForceMode.Impulse);
            }
        }
        //
        if (particulaDeExplosao)
        {
            GameObject particula = Instantiate(particulaDeExplosao, transform.position, transform.rotation) as GameObject;
            Destroy(particula, 1);
        }
        Destroy(this.gameObject);
    }
}