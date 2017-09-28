using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportModel {

	private Vector3 position;
	private Vector3 rotation;

	public Vector3 Position
	{
		get { return this.position; }
	}

	public Vector3 Rotation
	{
		get { return this.rotation; }
	}

	public TeleportModel(Vector3 position, Vector3 rotation)
	{
		this.position = position;
		this.rotation = rotation;
	}

	public TeleportModel(float posX, float posY, float posZ, float rotX, float rotY)
	{
		this.position = new Vector3(posX, posY, posZ);
		this.rotation = new Vector3(rotX, rotY);
	}

	public TeleportModel(float posX, float posY, float posZ, float rotX, float rotY, float rotZ)
	{
		this.position = new Vector3(posX, posY, posZ);
		this.rotation = new Vector3(rotX, rotY, rotZ);
	}
}
