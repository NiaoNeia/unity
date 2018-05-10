using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    Rigidbody rb;
    public GameObject[] cubes;
    public float jorneytime = 0.1f;
    public GameObject cube3;
    public GameObject sphere;
    float EnemyHP;
    public float Damage;
    bool DSphere;
    Vector3 Dist;
    // Use this for initialization
    void Start() {
        rb = sphere.GetComponent<Rigidbody>();
        EnemyHP = 100f;
        Damage = 50f;
        DSphere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Spawn());
            
        }
        sphere.transform.position = Vector3.Lerp(sphere.transform.position, cubes[0].transform.position, jorneytime * Time.deltaTime);
        Check();
        Distance();

    }
    void Distance ()
    {
        var Dist = cubes[1].transform.position - cube3.transform.position;
        Debug.Log(Dist.magnitude);
    }
 float HP ()
    {   
        return EnemyHP -= Damage;
    }
    void Check()
    {
        if (Physics.Raycast(sphere.transform.position, cubes[0].transform.position, 1f)&&DSphere==false)
        { 
            
            HP();
            Debug.Log(EnemyHP);
            
            DSphere = true;
            
        }
        
        if (EnemyHP <= 0)
        {

            Destroy(cubes[0]);
        }
    }
    IEnumerator Spawn ()
    {   while (true)
        {
            sphere = Instantiate(sphere, cube3.transform.position, Quaternion.identity) as GameObject;
            DSphere = false;
            yield return new WaitForSeconds(2f);
        }
    }
}
