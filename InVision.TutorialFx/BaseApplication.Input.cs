using System;
using InVision.OIS;
using InVision.Rendering;

namespace InVision.TutorialFx
{
	public abstract partial class BaseApplication
	{
		protected InputManager InputManager;
		protected Keyboard Keyboard;
		protected Mouse Mouse;

		protected virtual void InitializeInput()
		{
			LogManager.Instance.LogMessage("*** Initializing OIS ***");

			IntPtr windowHnd;

			Window.GetCustomAttribute("WINDOW", out windowHnd);

			InputManager inputMgr = InputManager.Create(windowHnd);

			Keyboard = (Keyboard)inputMgr.CreateInputObject(DeviceType.Keyboard, true);
			Mouse = (Mouse)inputMgr.CreateInputObject(DeviceType.Mouse, true);

			Keyboard.KeyPressed += OnKeyPressed;
			Keyboard.KeyReleased += OnKeyReleased;

			Mouse.MouseMoved += OnMouseMoved;
			Mouse.MousePressed += OnMousePressed;
			Mouse.MouseReleased += OnMouseReleased;
		}

		protected void ProcessInput()
		{
			Keyboard.Capture();
			Mouse.Capture();
		}

		protected virtual bool OnKeyPressed(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case KeyCode.W:
				case KeyCode.Up:
					CameraMan.GoingForward = true;
					break;

				case KeyCode.S:
				case KeyCode.Down:
					CameraMan.GoingBack = true;
					break;

				case KeyCode.A:
				case KeyCode.Left:
					CameraMan.GoingLeft = true;
					break;

				case KeyCode.D:
				case KeyCode.Right:
					CameraMan.GoingRight = true;
					break;

				case KeyCode.E:
				case KeyCode.PgUp:
					CameraMan.GoingUp = true;
					break;

				case KeyCode.Q:
				case KeyCode.PgDown:
					CameraMan.GoingDown = true;
					break;

				case KeyCode.LShift:
				case KeyCode.RShift:
					CameraMan.FastMove = true;
					break;

				case KeyCode.T:
					CycleTextureFilteringMode();
					break;

				case KeyCode.R:
					CyclePolygonMode();
					break;

				case KeyCode.F5:
					ReloadAllTextures();
					break;

				case KeyCode.Sysrq:
					TakeScreenshot();
					break;

				case KeyCode.Escape:
					Shutdown();
					break;
			}

			return true;
		}

		protected virtual bool OnKeyReleased(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case KeyCode.W:
				case KeyCode.Up:
					CameraMan.GoingForward = false;
					break;

				case KeyCode.S:
				case KeyCode.Down:
					CameraMan.GoingBack = false;
					break;

				case KeyCode.A:
				case KeyCode.Left:
					CameraMan.GoingLeft = false;
					break;

				case KeyCode.D:
				case KeyCode.Right:
					CameraMan.GoingRight = false;
					break;

				case KeyCode.E:
				case KeyCode.PgUp:
					CameraMan.GoingUp = false;
					break;

				case KeyCode.Q:
				case KeyCode.PgDown:
					CameraMan.GoingDown = false;
					break;

				case KeyCode.LShift:
				case KeyCode.RShift:
					CameraMan.FastMove = false;
					break;
			}

			return true;
		}

		protected virtual bool OnMouseMoved(MouseEventArgs e)
		{
			CameraMan.MouseMovement(e.State.X.Relative, e.State.Y.Relative);
			return true;
		}

		protected virtual bool OnMousePressed(MouseEventArgs mouseEventArgs, MouseButton button)
		{
			return true;
		}

		protected virtual bool OnMouseReleased(MouseEventArgs mouseEventArgs, MouseButton button)
		{
			return true;
		}
	}
}