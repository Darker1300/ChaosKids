using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shapes;
using UnityEngine.Rendering;

public class TestShapeThing : ImmediateModeShapeDrawer
{
	public Color color;
	
	public float y = 0;
	public float x = 0;
	public float angle;
    public float movementRadius;
	public float discRadius;

    public override void DrawShapes(Camera cam)
	{

		using (Draw.Command(cam))
		{
			Draw.ZTest = CompareFunction.Always;
			Draw.BlendMode = ShapesBlendMode.Transparent;
			Draw.LineGeometry = LineGeometry.Flat2D;
			Draw.Matrix = transform.localToWorldMatrix;
			Draw.Color = Color.white;
			 y = Mathf.Sin(angle)* movementRadius;
			x = Mathf.Cos(angle)* movementRadius;
			Vector2 test = new Vector2(x, y);
			y += (y / movementRadius) * 2f;
			x += (x / movementRadius) * 2f;
			Draw.Disc(new Vector3(x,y,0), discRadius,color);
			angle += 0.005f;

		}

	}
}
