using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCR_Grid : MonoBehaviour
{
    public int width = 7;  // Horizontal size of the grid

    public int height = 3;  // Vertical size of the grid

    private GameObject[,] grid;  //  Array of all the cells, [0, 0] is the bottom left

    [SerializeField]
    private GameObject cellPrefab;

    [SerializeField]
    private float cellSize;  // Size of each octagon cell

    [SerializeField]
    private float cellSpacing = .1f;


    // Directions to make the path up
    enum Direction { Up, Down, Left, Right };

    [SerializeField]
    private Direction[] correctPath;

    [SerializeField]
    private Vector2 startingCell;  // The row and column





    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[width, height];


        // Find all its cell children and put them in the grid array
        foreach (Transform child in transform)
        {
            //child is your child transform
            PCR_Cell cell = child.GetComponent<PCR_Cell>();

            // Adjust position so the cells for a grid centered on the transform of the script

            child.transform.localPosition = new Vector3((cellSize + cellSpacing) * (cell.x - (width / 2)), 0, (cellSize + cellSpacing) * (cell.y - (height / 2)));

            // Add to array
            grid[cell.x, cell.y] = child.gameObject;
        }
    }


    // Checks the whole dna sequence to see if the player has completed the PCR fragment
    public void CheckSequence()
    {
        if (RecursiveSequenceCheck(grid[(int)startingCell.x, (int)startingCell.y].GetComponent<PCR_Cell>(), 0))
        {
            // Code to excute when the path is correct
            Debug.Log("YAY!");
        }
        else
        {
            // Code to excute when the path is wrong
        }
    }



    // Given a cell and an index of the correctPath array, cehcks to see if that cell has that directional oath open
    private bool RecursiveSequenceCheck(PCR_Cell cell, int pathIndex)
    {
        //Debug.Log(cell.x.ToString() + cell.y.ToString());

        // Base case, if at end, whole oath is correct
        if (pathIndex == correctPath.Length)
        {
            return true;
        }

        // Calculate the next cell
        int xDiff = 0;  // The difference in position for the next cell from the current one
        int yDiff = 0;

        if (correctPath[pathIndex] == Direction.Up)
        {
            yDiff += 1;
        }
        else if (correctPath[pathIndex] == Direction.Down)
        {
            yDiff -= 1;
        }
        else if (correctPath[pathIndex] == Direction.Right)
        {
            xDiff += 1;
        }
        else if (correctPath[pathIndex] == Direction.Left)
        {
            xDiff -= 1;
        }


        // If the cell has the correct path open and the next cell has its path open
        if (CheckPath(grid[cell.x, cell.y].GetComponent<PCR_Cell>(), grid[cell.x + xDiff, cell.y + yDiff].GetComponent<PCR_Cell>(), correctPath[pathIndex]))
        {
            //Recursive Check
            if (RecursiveSequenceCheck(grid[cell.x + xDiff, cell.y + yDiff].GetComponent<PCR_Cell>(), pathIndex + 1))
            {
                return true;
            }
        }

        return false;
    }



    // Given a PCR cell and a direction, checks to see if that path is open and the next cell has its path open
    private bool CheckPath(PCR_Cell cell, PCR_Cell nextCell, Direction path)
    {
        bool firstCellCorrect = false;
        if ((path == Direction.Up) && (cell.upOpen))
        {
            firstCellCorrect = true;
        }
        else if ((path == Direction.Down) && (cell.downOpen))
        {
            firstCellCorrect = true;
        }
        else if ((path == Direction.Right) && (cell.rightOpen))
        {
            firstCellCorrect = true;
        }
        else if ((path == Direction.Left) && (cell.leftOpen))
        {
            firstCellCorrect = true;
        }


        // If the first cell is correct, check if the conencting oath on the next cell is correct
        if (firstCellCorrect)
        {
            if ((path == Direction.Up) && (nextCell.downOpen))
            {
                return true;
            }
            else if ((path == Direction.Down) && (nextCell.upOpen))
            {
                return true;
            }
            else if ((path == Direction.Right) && (nextCell.leftOpen))
            {
                return true;
            }
            else if ((path == Direction.Left) && (nextCell.rightOpen))
            {
                return true;
            }
        }


        return false;
    }


}


