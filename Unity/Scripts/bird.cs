using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class bird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        StartCoroutine("ResetGame", 2.0f);
    }

    IEnumerator ResetGame(float Count)
    {
        yield return new WaitForSeconds(Count);

        SceneManager.LoadScene("SocketIOTest");

        yield return null;
    }

}
