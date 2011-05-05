using System;
using InVision.Bullet;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.Dynamics.Dynamics;
using InVision.GameMath;

namespace Bullet.HelloWorld
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var collisionConfig = new DefaultCollisionConfiguration();
			var dispatcher = new CollisionDispatcher(collisionConfig);
			var pairCache = new DbvtBroadphase();
			var solver = new SequentialImpulseConstraintSolver();

			var dynamicsWorld = new DiscreteDynamicsWorld(dispatcher, pairCache, solver, collisionConfig);
			dynamicsWorld.Gravity = new Vector3(0, -10, 0);

			var groundShape = new BoxShape(new Vector3(50, 50, 50));
			var groundTransform = Matrix.CreateTranslation(0, -56, 0);

			{
				float mass = 0;
				bool isDynamic = mass != 0;
				Vector3 localInertia = Vector3.Zero;

				if (isDynamic)
					localInertia = groundShape.CalculateLocalInertia(mass);

				var motionState = new DefaultMotionState(groundTransform);
				var rbinfo = new RigidBodyConstructionInfo(mass, motionState, groundShape, localInertia);
				var body = new RigidBody(rbinfo);

				dynamicsWorld.AddRigidBody(body);
			}

			{
				var collisionShape = new SphereShape(1);
				var transform = Matrix.Identity;
				float mass = 1;
				bool isDynamic = mass != 0;
				Vector3 localInertia = Vector3.Zero;

				if (isDynamic)
					localInertia = collisionShape.CalculateLocalInertia(mass);

				transform.Translation = new Vector3(2, 10, 0);

				var motionState = new DefaultMotionState(transform);
				var rbinfo = new RigidBodyConstructionInfo(mass, motionState, collisionShape, localInertia);
				var body = new RigidBody(rbinfo);

				dynamicsWorld.AddRigidBody(body);
			}

			Console.WriteLine("Starting simulation");

			for (int i = 0; i < 100; i++)
			{
				dynamicsWorld.StepSimulation(1f / 60f, 10);

				for (int j = dynamicsWorld.GetNumCollisionObjects() - 1; j >= 0; j--)
				{
					var obj = dynamicsWorld.GetCollisionObjectArray()[j];
					var body = (RigidBody)obj;

					if (body != null && body.GetMotionState() != null)
					{
						Matrix transform = Matrix.Identity;

						body.GetMotionState().GetWorldTransform(ref transform);

						Console.WriteLine("Object@{0} Position={1}", body.GetHashCode(), transform.Translation);
					}
				}
			}

			Console.Read();
		}
	}
}
