using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class RenderWindowParameters : IDictionary<string, string>
	{
		private readonly IDictionary<string, string> _parameters;

		/// <summary>
		/// Initializes a new instance of the <see cref="RenderWindowParameters"/> class.
		/// </summary>
		public RenderWindowParameters()
		{
			_parameters = new Dictionary<string, string>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RenderWindowParameters"/> class.
		/// </summary>
		public RenderWindowParameters(IDictionary<string, string> parameters)
		{
			_parameters = parameters;
		}

		/// <summary>
		/// Sets the title.
		/// </summary>
		/// <param name="value">The value.</param>
		public string Title
		{
			set { this["title"] = value; }
		}

		/// <summary>
		/// Sets the color depth.
		/// </summary>
		/// <value>The color depth (must be 16 or 32).</value>
		public uint ColorDepth
		{
			set { this["colourDepth"] = value.ToString(); }
		}

		/// <summary>
		/// Sets the left.
		/// </summary>
		/// <value>The left.</value>
		public int Left
		{
			set { this["left"] = value.ToString(); }
		}

		/// <summary>
		/// Sets the top.
		/// </summary>
		/// <value>The top.</value>
		public int Top
		{
			set { this["top"] = value.ToString(); }
		}

		/// <summary>
		/// Sets a value indicating whether [depth buffer].
		/// </summary>
		/// <value><c>true</c> if [depth buffer]; otherwise, <c>false</c>.</value>
		public bool DepthBuffer
		{
			set { this["depthBuffer"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets the external window handle.
		/// </summary>
		/// <remarks>
		/// Win32: HWND as integer
		/// GLX: poslong:posint:poslong (display*:screen:windowHandle) or poslong:posint:poslong:poslong (display*:screen:windowHandle:XVisualInfo*)
		/// </remarks>
		/// <value>The external window handle.</value>
		public string ExternalWindowHandle
		{
			set { this["externalWindowHandle"] = value; }
		}

		/// <summary>
		/// Sets a value indicating whether [external GL control].
		/// </summary>
		/// <value><c>true</c> if [external GL control]; otherwise, <c>false</c>.</value>
		public bool ExternalGlControl
		{
			set { this["externalGLControl"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets the external gl context.
		/// </summary>
		/// <value>The external gl context.</value>
		public long ExternalGlContext
		{
			set { this["externalGLContext"] = value.ToString(); }
		}

		/// <summary>
		/// Sets the parent window handle.
		/// </summary>
		/// <value>The parent window handle.</value>
		public string ParentWindowHandle
		{
			set { this["parentWindowHandle"] = value; }
		}

		/// <summary>
		/// Sets the mac API.
		/// </summary>
		/// <value>The mac API.</value>
		public string MacAPI
		{
			set { this["macAPI"] = value; }
		}

		/// <summary>
		/// Sets a value indicating whether [mac API cocoa use NS view].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [mac API cocoa use NS view]; otherwise, <c>false</c>.
		/// </value>
		public bool MacAPICocoaUseNSView
		{
			set { this["macAPICocoaUseNSView"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets the content scaling factor.
		/// </summary>
		/// <value>The content scaling factor.</value>
		public float ContentScalingFactor
		{
			set { this["contentScalingFactor"] = value.ToString(CultureInfo.InvariantCulture); }
		}

		/// <summary>
		/// Sets the FSAA.
		/// </summary>
		/// <value>The FSAA.</value>
		public uint FSAA
		{
			set { this["FSAA"] = value.ToString(); }
		}

		/// <summary>
		/// Sets the FSAA hint.
		/// </summary>
		/// <value>The FSAA hint.</value>
		public string FSAAHint
		{
			set { this["FSAAHint"] = value; }
		}

		/// <summary>
		/// Sets the display frequency.
		/// </summary>
		/// <value>The display frequency.</value>
		public uint DisplayFrequency
		{
			set { this["displayFrequency"] = value.ToString(); }
		}

		/// <summary>
		/// Sets a value indicating whether Vertical sync.
		/// </summary>
		/// <value><c>true</c> if Vertical sync; otherwise, <c>false</c>.</value>
		public bool VSync
		{
			set { this["vsync"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets the V sync interval.
		/// </summary>
		/// <value>The V sync interval.</value>
		public uint VSyncInterval
		{
			set { this["vsyncInterval"] = value.ToString(); }
		}

		/// <summary>
		/// Sets the border.
		/// </summary>
		/// <value>The border.</value>
		public WindowBorder Border
		{
			set { this["border"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets a value indicating whether [outer dimensions].
		/// </summary>
		/// <value><c>true</c> if [outer dimensions]; otherwise, <c>false</c>.</value>
		public bool OuterDimensions
		{
			set { this["outerDimensions"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets a value indicating whether [use nvidia perf HUD].
		/// </summary>
		/// <value><c>true</c> if [use nvidia perf HUD]; otherwise, <c>false</c>.</value>
		public bool UseNvidiaPerfHUD
		{
			set { this["useNVPerfHUD"] = value.ToString().ToLower(); }
		}

		/// <summary>
		/// Sets a value indicating whether this <see cref="RenderWindowParameters"/> is gamma.
		/// </summary>
		/// <value><c>true</c> if gamma; otherwise, <c>false</c>.</value>
		public bool Gamma
		{
			set { this["gamma"] = value.ToString().ToLower(); }
		}

		#region IDictionary<string,string> Members

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			return _parameters.GetEnumerator();
		}

		/// <summary>
		/// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
		public void Add(KeyValuePair<string, string> item)
		{
			_parameters.Add(item);
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
		public void Clear()
		{
			_parameters.Clear();
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		public bool Contains(KeyValuePair<string, string> item)
		{
			return _parameters.Contains(item);
		}

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="array"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="array"/> is multidimensional.-or-The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.-or-Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.</exception>
		public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
		{
			_parameters.CopyTo(array, arrayIndex);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </returns>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
		public bool Remove(KeyValuePair<string, string> item)
		{
			return _parameters.Remove(item);
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </summary>
		/// <returns>
		/// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </returns>
		public int Count
		{
			get { return _parameters.Count; }
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
		/// </returns>
		public bool IsReadOnly
		{
			get { return _parameters.IsReadOnly; }
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key; otherwise, false.
		/// </returns>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool ContainsKey(string key)
		{
			return _parameters.ContainsKey(key);
		}

		/// <summary>
		/// Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <param name="key">The object to use as the key of the element to add.</param><param name="value">The object to use as the value of the element to add.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
		public void Add(string key, string value)
		{
			_parameters.Add(key, value);
		}

		/// <summary>
		/// Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <returns>
		/// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		/// <param name="key">The key of the element to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
		public bool Remove(string key)
		{
			return _parameters.Remove(key);
		}

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key whose value to get.</param><param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool TryGetValue(string key, out string value)
		{
			return _parameters.TryGetValue(key, out value);
		}

		/// <summary>
		/// Gets or sets the element with the specified key.
		/// </summary>
		/// <returns>
		/// The element with the specified key.
		/// </returns>
		/// <param name="key">The key of the element to get or set.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> is not found.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
		public string this[string key]
		{
			get { return _parameters[key]; }
			set { _parameters[key] = value; }
		}

		/// <summary>
		/// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		public ICollection<string> Keys
		{
			get { return _parameters.Keys; }
		}

		/// <summary>
		/// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
		/// </returns>
		public ICollection<string> Values
		{
			get { return _parameters.Values; }
		}

		/// <summary>
		/// Returns an enumerator that iterates through a collection.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		/// <summary>
		/// Toes the name value pair list.
		/// </summary>
		/// <returns></returns>
		public NameValuePairList ToNameValuePairList()
		{
			return NameValuePairList.Convert(this);
		}
	}
}