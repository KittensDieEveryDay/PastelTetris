using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Vector3 _rotationPoint;
    private float _previousTime;
    public float _fallTime = 0.8f;
    public static int _height = 20;
    public static int _width = 10;
    private static Transform[,] grid = new Transform[_width, _height];
    private float timerIndex = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //sides movement
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        }

        

        //vertical movement
        if (Time.time - _previousTime > (Input.GetKey(KeyCode.DownArrow) ? _fallTime / 10 : _fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                enabled = false;

                if (!gameIsOver())
                {
                    FindObjectOfType<TetrosSpawner>().spawnTetromino();
                }
            }
            _previousTime = Time.time;
        }

        //rotation
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(_rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(_rotationPoint), new Vector3(0, 0, 1), -90);
        }
    }

    //UI movement

    public void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0);
        if (!ValidMove())
            transform.position -= new Vector3(-1, 0, 0);
    }

    public void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0);
        if (!ValidMove())
            transform.position -= new Vector3(1, 0, 0);
    }

    public void Rotate()
    {
        transform.RotateAround(transform.TransformPoint(_rotationPoint), new Vector3(0, 0, 1), 90);
        if (!ValidMove())
            transform.RotateAround(transform.TransformPoint(_rotationPoint), new Vector3(0, 0, 1), -90);
    }

    public void MoveDown()
    {
        _fallTime = 0.1f;
        transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                this.enabled = false;

                if (!gameIsOver())
                {
                    FindObjectOfType<TetrosSpawner>().spawnTetromino();
                }
            }
            _previousTime = Time.time;
    }

    void CheckForLines()
    {
        for (int i = _height-1; i >= 0; i--)
        {
            if(HasLine(i))
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
            if(grid[j, i] == null)
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

            if(roundedX < 0 || roundedX >= _width || roundedY < 0 || roundedY >= _height)
            {
                return false;
            }
            if(grid[roundedX, roundedY] != null)
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
    }
}
