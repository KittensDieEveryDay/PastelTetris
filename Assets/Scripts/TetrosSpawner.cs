using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrosSpawner : MonoBehaviour
{
    public GameObject[] Tetrominoes;
    // Start is called before the first frame update
    void Start()
    {
        spawnTetromino();
    }

    public void spawnTetromino()
    {
        Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], transform.position, Quaternion.identity);
    }
}
