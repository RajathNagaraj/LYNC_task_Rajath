using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenObject 
{
    private PositionObject screenStart;

    private PositionObject screenEnd;

    private PositionObject midPoint;

    public ScreenObject(PositionObject start, PositionObject end)
    {
        screenStart = new PositionObject(start.X,start.Y);
        screenEnd = new PositionObject(end.X,end.Y);
        midPoint = new PositionObject((screenEnd.X + screenStart.X) / 2, (screenEnd.Y + screenStart.Y) / 2);
    }

    public PositionObject ScreenStart
    {
        get{return screenStart;}
    }

    public PositionObject ScreenEnd
    {
        get{return screenEnd;}
    }

    public PositionObject MidPoint
    {
        get{return midPoint;}
    }

    

    
    
}