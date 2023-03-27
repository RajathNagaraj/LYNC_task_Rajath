using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils 
{
    private static PositionObject midPoint;

    private static PositionObject origin;

    private static PositionObject end;

    static ScreenUtils()
    {
        //Initialise the origin and end for the resolution of the device 
        origin = new PositionObject(0,0);
        end = new PositionObject(HorizontalRes,VerticalRes);
        midPoint = new PositionObject(HorizontalRes / 2, VerticalRes / 2);
        Debug.Log("Inside ScreenUtils static constructor");
    }

    public static int ScreenDivisor(int divisor)
    {
        return Screen.width / divisor;
    }

    public static List<ScreenObject> PartitionScreen(int _widthOfScreenObject)
    {
       List<ScreenObject> partitions = new List<ScreenObject>(); 
       PositionObject tempStart = new PositionObject(origin.X,origin.Y);
       PositionObject tempEnd = new PositionObject(_widthOfScreenObject,VerticalRes);
        while(tempStart.X < HorizontalRes)
        {
            Debug.Log("tempStart.X value "+tempStart.X);
            partitions.Add(new ScreenObject(tempStart,tempEnd));
            tempStart.X += _widthOfScreenObject;
            tempEnd.X += _widthOfScreenObject;
        }

        return partitions;
       
          
    }
 
    public static int HorizontalRes
    {
        get{ return Screen.width; } 
    }

    public static int VerticalRes
    {
        get{ return Screen.height; } 
    }
}

    
