using InVision.Input;

namespace InVision.TutorialFx
{
	public abstract partial class BaseApplication
	{
		protected Keyboard mKeyboard;
		protected Mouse mMouse;

		protected virtual void InitializeInput()
		{
			LogManager.Singleton.LogMessage("*** Initializing OIS ***");

			int windowHnd;
			mWindow.GetCustomAttribute("WINDOW", out windowHnd);
			var inputMgr = MOIS.InputManager.CreateInputSystem((uint)windowHnd);

			mKeyboard = (MOIS.Keyboard)inputMgr.CreateInputObject(MOIS.Type.OISKeyboard, true);
			mMouse = (MOIS.Mouse)inputMgr.CreateInputObject(MOIS.Type.OISMouse, true);

			mKeyboard.KeyPressed += new KeyListener.KeyPressedHandler(OnKeyPressed);
			mKeyboard.KeyReleased += new KeyListener.KeyReleasedHandler(OnKeyReleased);
			mMouse.MouseMoved += OnMouseMoved;
			mMouse.MousePressed += OnMousePressed;
			mMouse.MouseReleased += OnMouseReleased;
		}

		protected void ProcessInput()
		{
			mKeyboard.Capture();
			mMouse.Capture();
		}

		protected virtual bool OnKeyPressed(KeyEvent evt)
		{
			switch (evt.key)
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

		protected virtual bool OnKeyReleased(KeyEvent evt)
		{
			switch (evt.key)
			{
				case KeyCode.KC_W:
				case KeyCode.KC_UP:
					mCameraMan.GoingForward = false;
					break;

				case KeyCode.KC_S:
				case KeyCode.KC_DOWN:
					mCameraMan.GoingBack = false;
					break;

				case KeyCode.KC_A:
				case KeyCode.KC_LEFT:
					mCameraMan.GoingLeft = false;
					break;

				case KeyCode.KC_D:
				case KeyCode.KC_RIGHT:
					mCameraMan.GoingRight = false;
					break;

				case KeyCode.KC_E:
				case KeyCode.KC_PGUP:
					mCameraMan.GoingUp = false;
					break;

				case KeyCode.KC_Q:
				case KeyCode.KC_PGDOWN:
					mCameraMan.GoingDown = false;
					break;

				case KeyCode.KC_LSHIFT:
				case KeyCode.KC_RSHIFT:
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
