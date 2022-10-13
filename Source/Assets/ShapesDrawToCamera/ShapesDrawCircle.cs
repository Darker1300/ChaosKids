using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Shapes;
//using System;
//[Serializable]
public class Point
{
	public Point(Vector3 pos, Vector3 pre, Vector3 next)
	{
		position = pos;
		PrevPosition = pre;
		NextPosition = next;
	}
	public Vector3 position;
	public Vector3 PrevPosition;
	public Vector3 NextPosition;
}
public class ShapesDrawCircle : ImmediateModeShapeDrawer
{


	public int numberOfPoints;
	public float radius;
	public Color color;
	public float movementRadius;
	float TAU = Mathf.PI * 2;
	public Vector3 lastPoint = Vector3.zero;
	[SerializeField]
	public List<Point> points = new List<Point>();
	public bool GenNew;
	public float smoothness;
	public float seed;
	Polygon poly;
	public bool GenHalf;
	public enum CircleQaud
	{
		CircQaudA, CircQaudB, CircQaudC, CircQaudD
	}

	public void Awake()
	{
		poly = GetComponent<Polygon>();
		//GenerateGround();
		GenerateGroundStart();

	}

	// Start is called before the first frame update
	public override void DrawShapes(Camera cam)
	{

		//using (Draw.Command(cam))
		//{
		//	Draw.ZTest = CompareFunction.Always;
		//	Draw.BlendMode = ShapesBlendMode.Transparent;
		//	Draw.LineGeometry = LineGeometry.Flat2D;
		//	Draw.Matrix = transform.localToWorldMatrix;
		//	Draw.Color = Color.white;

		//          for (int i = 2; i < numberOfPoints -1; i++)
		//          {


		//		Draw.Line(points[i].PrevPosition, points[i].position,color);

		//	}
		//	//bool should = true;
		//	//for (int i = 0; i < numberOfPoints; i++)
		//	//{
		//	//	should = !should;
		//	//	float angle = (TAU / (float)numberOfPoints) * i;
		//	//	float X = should ? Mathf.Cos(angle) *  (movementRadius *  Mathf.Cos(angle)) : Mathf.Cos(angle)* movementRadius;
		//	//	float y = should ? Mathf.Sin(angle) *  (movementRadius * Mathf.Sin(angle)) : Mathf.Sin(angle) * movementRadius;
		//	//	//float y = Mathf.Sin(angle) * (movementRadius * Mathf.Sin(angle));
		//	//	//Draw.Sphere(new Vector3(X, y, 0), radius,color);
		//	//	Draw.Line(lastPoint, new Vector3(X, y, 0), color);
		//	//	lastPoint = new Vector3(X, y, 0);
		//	//}

		//}

	}
	public void Update()
	{

		if (GenNew)
		{
			points.Clear();
			GenerateGroundStart();

			GenNew = false;

		}

	}
	public void GenerateGround()
	{
		poly.points.Clear();
		seed = Random.Range(-10000, 10000);
		//smoothness = Random.Range(0.02f, 0.5f);
		//radius = Random.Range(1f, 6f);
		GenHalf = !GenHalf;


		float perlinHeight;
		int Start = GenHalf ? 0 : (numberOfPoints / 2);
		int End = GenHalf ? (numberOfPoints / 2) : numberOfPoints;


		points.RemoveRange(Start, End - Start);
		for (int i = Start; i < End; i++)
		{

			float angle = i * Mathf.PI * 2 / numberOfPoints;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * movementRadius;
			perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(pos.x / smoothness, seed) * radius / 2);
			perlinHeight += (pos.magnitude / 2.0f);
			pos = pos * (perlinHeight * 0.5f);


			//Draw.Sphere(new Vector3(X, y, 0), radius,color);
			Draw.Line(lastPoint, pos, color);
			//Draw.draw
			if (GenHalf)
			{
				points.Insert(i, new Point(pos, lastPoint, Vector3.zero));
			}
			else points.Add(new Point(pos, lastPoint, Vector3.zero));

			if (lastPoint != Vector3.zero && i != 0)
			{

				points[i - 1].NextPosition = pos;
				//points[i-2].NextPosition = points[points.Count - 1].position;

			}
			lastPoint = pos;
		}
		for (int i = 1; i < numberOfPoints; i++)
		{

			poly.AddPoint(points[i].position);
		}


	}

	public void GenerateGroundStart()
	{
		seed = Random.Range(-10000, 10000);
		poly.points.Clear();


		float perlinHeight;
		for (int i = 0; i < numberOfPoints; i++)
		{

			float angle = i * Mathf.PI * 2 / numberOfPoints;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * movementRadius;
			perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(pos.x / smoothness, seed) * movementRadius / 2);
			perlinHeight += (pos.magnitude / 2.0f);
			pos = pos.normalized * (perlinHeight * 0.5f);


			//Draw.Sphere(new Vector3(X, y, 0), radius,color);
			Draw.Line(lastPoint, pos, color);
			//Draw.draw

			poly.AddPoint(pos);
			points.Add(new Point(pos, lastPoint, Vector3.zero));
			if (lastPoint != Vector3.zero)
			{

				points[i - 1].NextPosition = pos;
				//points[i-2].NextPosition = points[points.Count - 1].position;

			}
			lastPoint = pos;
		}
	}
	public void generatepoocircle()
	{

		for (int i = 0; i < numberOfPoints; i++)
		{

			float angle = (TAU / (float)numberOfPoints) * i;
			float X = Mathf.Cos(angle) * (movementRadius);
			float y = Mathf.Sin(angle) * (movementRadius);
			y += (movementRadius / y) * .01f;
			X += (movementRadius / X) * .01f;
			//Draw.Sphere(new Vector3(X, y, 0), radius,color);
			Draw.Line(lastPoint, new Vector3(X, y, 0), color);
			//Draw.draw
			points.Add(new Point(new Vector3(X, y, 0), lastPoint, Vector3.zero));
			if (lastPoint != Vector3.zero)
			{
				points[i - 1].NextPosition = new Vector3(X, y, 0);
				//points[i-2].NextPosition = points[points.Count - 1].position;

			}
			lastPoint = new Vector3(X, y, 0);
		}
	}

}
