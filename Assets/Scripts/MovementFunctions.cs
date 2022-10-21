using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFunctions : MonoBehaviour
{
    public Vector3 _rotationPoint;
    private float _previousTime;
    public float _fallTime = 0.8f;
    public static int _height = 20;
    public static int _width = 10;
    private static Transform[,] grid = new Transform[_width, _height];
    private float timerIndex = 0.25f;
    //public GameObject tetro;

    // Start is called before the first frame update
    void Start()
    {
        //tetro = GameObject.FindWithTag("Tetromino");
        /*FindObjectOfType<Block>().Rotate();
        FindObjectOfType<Block>().MoveLeft();
        FindObjectOfType<Block>().MoveRight();
        FindObjectOfType<Block>().MoveDown();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //UI movement

    public void MoveLeft()
    {
        FindObjectOfType<Block>().MoveLeft();
    }

    public void MoveRight()
    {
        FindObjectOfType<Block>().MoveRight();
    }

    public void Rotate()
    {
        FindObjectOfType<Block>().Rotate();
    }

    public void MoveDown()
    {
        FindObjectOfType<Block>().MoveDown();
    }
    /*void CheckForLines()
    {
        for (int i = _height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for (int j = 0; j < _width; j++)
        {
            if (grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < _width; j++)
        {

            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
            FindObjectOfType<GameManager>().IncreaseScore();
            _fallTime -= timerIndex;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < _height; y++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (grid[j, y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if (roundedX < 0 || roundedX >= _width || roundedY < 0 || roundedY >= _height)
            {
                return false;
            }
            if (grid[roundedX, roundedY] != null)
            {
                return false;
            }
        }
        return true;
    }

    bool gameIsOver()

    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;

            if (roundedY >= _height - 1)
            {
                FindObjectOfType<GameManager>().GameOver();
                print("Game over!");
                return true;
            }
        }
        return false;
    }*/
}
