using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayLayout
{
    [SerializeField]
    public struct rowData
    {
        public bool[] row;
    }

    public rowData[] rows = new rowData[7]; //grid of 7x7
}
