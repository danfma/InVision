using System;
using InVision.Rendering;
using OpenTK;

namespace InVision.TutorialFx
{
	public class CameraMan
	{
		private readonly Camera mCamera;
		private bool mFastMove;
		private bool mFreeze;
		private bool mGoingBack;
		private bool mGoingDown;
		private bool mGoingForward;
		private bool mGoingLeft;
		private bool mGoingRight;
		private bool mGoingUp;


		public CameraMan(Camera camera)
		{
			mCamera = camera;
		}

		public bool GoingForward
		{
			set { mGoingForward = value; }
			get { return mGoingForward; }
		}

		public bool GoingBack
		{
			set { mGoingBack = value; }
			get { return mGoingBack; }
		}

		public bool GoingLeft
		{
			set { mGoingLeft = value; }
			get { return mGoingLeft; }
		}

		public bool GoingRight
		{
			set { mGoingRight = value; }
			get { return mGoingRight; }
		}

		public bool GoingUp
		{
			set { mGoingUp = value; }
			get { return mGoingUp; }
		}

		public bool GoingDown
		{
			set { mGoingDown = value; }
			get { return mGoingDown; }
		}

		public bool FastMove
		{
			set { mFastMove = value; }
			get { return mFastMove; }
		}

		public bool Freeze
		{
			set { mFreeze = value; }
			get { return mFreeze; }
		}

		public void UpdateCamera(float timeFragment)
		{
			if (mFreeze)
				return;

			// build our acceleration vector based on keyboard input composite
			var move = Vector3.Zero;

			if (mGoingForward) move += mCamera.Direction;
			if (mGoingBack) move -= mCamera.Direction;
			if (mGoingRight) move += mCamera.Right;
			if (mGoingLeft) move -= mCamera.Right;
			if (mGoingUp) move += mCamera.Up;
			if (mGoingDown) move -= mCamera.Up;

			move.Normalize();
			move *= 150; // Natural speed is 150 units/sec.
			if (mFastMove)
				move *= 3; // With shift button pressed, move twice as fast.

			if (move != Vector3.Zero)
				mCamera.Move(move * timeFragment);
		}

		public void MouseMovement(int x, int y)
		{
			if (mFreeze)
				return;

			mCamera.Yaw(new Degree(-x * 0.15f).ValueRadians);
			mCamera.Pitch(new Degree(-y * 0.15f).ValueRadians);
		}
	}
}