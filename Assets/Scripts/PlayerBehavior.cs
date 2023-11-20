using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum changeColor
{
    Red, Green, Blue
}

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed, range, x, y, z, rotationSpeed;
    public Quaternion rotation, eularAngles, currentRotation;
    public Vector3 currentEularAngles;
    public GameObject[] target;
    public changeColor cg;
    public GameObject redPlayer, greenPlayer, bluePlayer;
    public GameObject cube;
    public GameOverManager gameOverManager;

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if (cg == changeColor.Red)
        {
            cg = changeColor.Green;
        }
        else if (cg == changeColor.Green)
        {
            cg = changeColor.Blue;
        }
        else if (cg == changeColor.Blue)
        {
            cg = changeColor.Red;
        }
        else
        {
            cg = changeColor.Red;

        }

    }

    void Update()
    {
        EnemyDetector();
        switch (cg)
        {
            case changeColor.Red:
                redPlayer.SetActive(true);
                bluePlayer.SetActive(false);
                greenPlayer.SetActive(false);
                break;
            case changeColor.Green:
                greenPlayer.SetActive(true);
                redPlayer.SetActive(false);
                bluePlayer.SetActive(false);
                break;
            case changeColor.Blue:
                bluePlayer.SetActive(true);
                greenPlayer.SetActive(false);
                redPlayer.SetActive(false);
                break;
            default:
                break;
        }
    
    }
    public void EnemyDetector()
    {
        target = GameObject.FindGameObjectsWithTag("Enemy");
        cube = target[0];
        
        float dist = Vector3.Distance(cube.transform.position, transform.position);

        if (dist <= range)
        {
            Debug.Log("EnemyDetected");
            LookRotation();
        }
        
    }


    void LookRotation()
    {
        Vector3 relativePos = transform.position - target[0].transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameOverManager.gameOver.SetActive(true);
        }
    }
}
