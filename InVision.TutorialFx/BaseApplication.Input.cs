using System;
using InVision.Input;
using InVision.Rendering;

namespace InVision.TutorialFx
{
	public abstract partial class BaseApplication
	{
		protected InputManager inputManager;
		protected Keyboard mKeyboard;
		protected Mouse mMouse;

		protected virtual void InitializeInput()
		{
			LogManager.Instance.LogMessage("*** Initializing OIS ***");

			IntPtr windowHnd;

			mWindow.GetCustomAttribute("WINDOW", out windowHnd);
			
			var inputMgr = new InputManager(windowHnd);

			mKeyboard = (Keyboard)inputMgr.CreateInputObject(InputType.Keyboard, true);
			mMouse = (Mouse)inputMgr.CreateInputObject(InputType.Mouse, true);

			mKeyboard.KeyPressed += OnKeyPressed;
			mKeyboard.KeyReleased += OnKeyReleased;
			mMouse.MouseMoved += OnMouseMoved;
			mMouse.MousePressed += OnMousePressed;
			mMouse.MouseReleased += OnMouseReleased;
		}

		protected void ProcessInput()
		{
			mKeyboard.Capture();
			mMouse.Capture();
		}

		protected virtual bool OnKeyPressed(KeyEventArgs e)
		{
			switch (e.Key)
			{
				case KeyCode.W:
				case KeyCode.Up:
					mCameraMan.GoingForward = true;
					break;

				case KeyCode.S:
				case KeyCode.Down:
					mCameraMan.GoingBack = true;
					break;

				case KeyCode.A:
				case KeyCode.Left:
					mCameraMan.GoingLeft = true;
					break;

				case KeyCode.D:
				case KeyCode.Right:
					mCameraMan.GoingRight = true;
					break;

				case KeyCode.E:
				case KeyCode.PgUp:
					mCameraMan.GoingUp = true;
					break;

				case KeyCode.Q:
				case KeyCode.PgDown:
					mCameraMan.GoingDown = true;
					break;

				case KeyCode.LShift:
				case KeyCode.RShift:
					mCameraMan.FastMove = true;
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
			switch (e.Key)
			{
				case KeyCode.W:
				case KeyCode.Up:
					mCameraMan.GoingForward = false;
					break;

				case KeyCode.S:
				case KeyCode.Down:
					mCameraMan.GoingBack = false;
					break;

				case KeyCode.A:
				case KeyCode.Left:
					mCameraMan.GoingLeft = false;
					break;

				case KeyCode.D:
				case KeyCode.Right:
					mCameraMan.GoingRight = false;
					break;

				case KeyCode.E:
				case KeyCode.PgUp:
					mCameraMan.GoingUp = false;
					break;

				case KeyCode.Q:
				case KeyCode.PgDown:
					mCameraMan.GoingDown = false;
					break;

				case KeyCode.LShift:
				case KeyCode.RShift:
					mCameraMan.FastMove = false;
					break;
			}

			return true;
		}

		protected virtual bool OnMouseMoved(MouseEventArgs e)
		{
			mCameraMan.MouseMovement(e.State.X.Relative, e.State.Y.Relative);
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
