using System;

namespace InVision
{
	public struct VersionInfo : IEquatable<VersionInfo>
	{
		private readonly int build;
		private readonly int major;
		private readonly int minor;
		private readonly string name;
		private readonly int revision;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "VersionInfo" /> struct.
		/// </summary>
		/// <param name = "name">The name.</param>
		/// <param name = "major">The major.</param>
		/// <param name = "minor">The minor.</param>
		/// <param name = "build">The build.</param>
		/// <param name = "revision">The revision.</param>
		public VersionInfo(string name, int major, int minor, int build = 0, int revision = 0)
		{
			this.name = name;
			this.major = major;
			this.minor = minor;
			this.build = build;
			this.revision = revision;
		}

		/// <summary>
		/// 	Gets the major.
		/// </summary>
		/// <value>The major.</value>
		public int Major
		{
			get { return major; }
		}

		/// <summary>
		/// 	Gets the minor.
		/// </summary>
		/// <value>The minor.</value>
		public int Minor
		{
			get { return minor; }
		}

		/// <summary>
		/// 	Gets the build.
		/// </summary>
		/// <value>The build.</value>
		public int Build
		{
			get { return build; }
		}

		/// <summary>
		/// 	Gets the revision.
		/// </summary>
		/// <value>The revision.</value>
		public int Revision
		{
			get { return revision; }
		}

		/// <summary>
		/// 	Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return name; }
		}

		/// <summary>
		/// 	Gets the version.
		/// </summary>
		/// <value>The version.</value>
		public Version Version
		{
			get { return new Version(major, minor, build, revision); }
		}

		#region IEquatable<VersionInfo> Members

		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// 	true if the current object is equal to the <paramref name = "other" /> parameter; otherwise, false.
		/// </returns>
		/// <param name = "other">An object to compare with this object.</param>
		public bool Equals(VersionInfo other)
		{
			return other.major == major && other.minor == minor && other.build == build && other.revision == revision &&
				   Equals(other.name, name);
		}

		#endregion

		/// <summary>
		/// 	Returns a <see cref = "System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// 	A <see cref = "System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("{0}.{1}.{2}.{3} ({4})", major, minor, build, revision, name);
		}

		/// <summary>
		/// 	Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "obj" /> and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		/// <param name = "obj">Another object to compare to. </param>
		/// <filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof(VersionInfo)) return false;
			return Equals((VersionInfo)obj);
		}

		/// <summary>
		/// 	Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// 	A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			unchecked
			{
				int result = major;
				result = (result * 397) ^ minor;
				result = (result * 397) ^ build;
				result = (result * 397) ^ revision;
				result = (result * 397) ^ (name != null ? name.GetHashCode() : 0);
				return result;
			}
		}

		public static bool operator ==(VersionInfo left, VersionInfo right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(VersionInfo left, VersionInfo right)
		{
			return !left.Equals(right);
		}
	}
}