using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PockeballManager : MonoBehaviour {

    public bool HasCaught;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pokemon")
        {
            StartCoroutine("CatchPokemon", other.gameObject);
        }
    }

    IEnumerator CatchPokemon(GameObject Pokemon)
    {
        transform.Translate(Vector3.up * 1, Space.World);
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Destroy(Pokemon.gameObject);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Player").transform.LookAt(this.transform);
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Camera>().fieldOfView = 8.6f;

        //Shake
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 5);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 5);
        //Shake 2
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 5);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 5);
        //Shake 3
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 5);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 5);
        //Finished shake
        yield return new WaitForSeconds(1);
        transform.Rotate(Vector3.right * 10);
        yield return new WaitForSeconds(0.1f);
        transform.Rotate(-Vector3.right * 10);

        HasCaught = true;
    }
}
