using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCR_Grid : MonoBehaviour
{
    public int width = 4;  // Horizontal size of the grid

    public int height = 8;  // Vertical size of the grid

    private GameObject[,] grid;  //  Array of all the cells

    [SerializeField]
    private GameObject cellPrefab;

    [SerializeField]
    private float cellSize;  // Size of each octagon cell

    [SerializeField]
    private float cellSpacing = .1f;


    [SerializeField]
    private Vector3 bottomLeftCellOffSet;  // The offset of the bottom left cell from this script's position


    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[width, height];

        // Initialise array to be all null
        //for (int i = 0; i < width; i++)
        //{
        //    for (int j = 0; j < height; j++)
        //    {
        //        //grid[i, j] = null;

        //        // Code to make a basic grid
        //        GameObject newCell = Instantiate(cellPrefab, transform.position + new Vector3(cellSize * i + cellSpacing * i, 0, cellSize * j + cellSpacing * j) + bottomLeftCellOffSet, transform.rotation);
        //        grid[i, j] = newCell;
        //    }
        //}

        // Find all its cellc hildren and put them in the grid array
        foreach (Transform child in transform)
        {
            //child is your child transform
            PCR_Cell cell = child.GetComponent<PCR_Cell>();
            // Adjust position
            child.transform.localPosition = new Vector3(cellSize * cell.row + cellSpacing * cell.row, 0, cellSize * cell.column + cellSpacing * cell.column) + bottomLeftCellOffSet;

            // Add tp array
            grid[cell.column, cell.row] = child.gameObject;
        }
    }

    
}
