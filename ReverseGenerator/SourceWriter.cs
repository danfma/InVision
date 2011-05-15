using System;
using System.IO;
using System.Text;
using InVision.Extensions;

namespace CodeGenerator
{
	public class SourceWriter : IDisposable
	{
		private StreamWriter _writer;

		/// <summary>
		/// Initializes a new instance of the <see cref="SourceWriter"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public SourceWriter(string filename)
		{
			_writer = File.CreateText(filename);
		}

		/// <summary>
		/// Gets or sets the indentation level.
		/// </summary>
		/// <value>The indentation level.</value>
		public int IndentationLevel { get; private set; }

		/// <summary>
		/// Gets or sets the line terminator string used by the current TextWriter.
		/// </summary>
		/// <returns>
		/// The line terminator string for the current TextWriter.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public string NewLine
		{
			get { return _writer.NewLine; }
			set { _writer.NewLine = value; }
		}

		/// <summary>
		/// Gets an object that controls formatting.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.IFormatProvider"/> object for a specific culture, or the formatting of the current culture if no other culture is specified.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public IFormatProvider FormatProvider
		{
			get { return _writer.FormatProvider; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the <see cref="T:System.IO.StreamWriter"/> will flush its buffer to the underlying stream after every call to <see cref="M:System.IO.StreamWriter.Write(System.Char)"/>.
		/// </summary>
		/// <returns>
		/// true to force <see cref="T:System.IO.StreamWriter"/> to flush its buffer; otherwise, false.
		/// </returns>
		/// <filterpriority>1</filterpriority>
		public bool AutoFlush
		{
			get { return _writer.AutoFlush; }
			set { _writer.AutoFlush = value; }
		}

		/// <summary>
		/// Gets the underlying stream that interfaces with a backing store.
		/// </summary>
		/// <returns>
		/// The stream this StreamWriter is writing to.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public Stream BaseStream
		{
			get { return _writer.BaseStream; }
		}

		/// <summary>
		/// Gets the <see cref="T:System.Text.Encoding"/> in which the output is written.
		/// </summary>
		/// <returns>
		/// The <see cref="T:System.Text.Encoding"/> specified in the constructor for the current instance, or <see cref="T:System.Text.UTF8Encoding"/> if an encoding was not specified.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public Encoding Encoding
		{
			get { return _writer.Encoding; }
		}

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		/// <summary>
		/// Indents this instance.
		/// </summary>
		public void Indent()
		{
			IndentationLevel++;
		}

		/// <summary>
		/// Deindents this instance.
		/// </summary>
		public void Deindent()
		{
			IndentationLevel = Math.Max(IndentationLevel - 1, 0);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_writer.Dispose();
				_writer = null;
			}
		}

		/// <summary>
		/// Writes the text representation of a Boolean value to the text stream.
		/// </summary>
		/// <param name="value">The Boolean to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(bool value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a 4-byte signed integer to the text stream.
		/// </summary>
		/// <param name="value">The 4-byte signed integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(int value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a 4-byte unsigned integer to the text stream.
		/// </summary>
		/// <param name="value">The 4-byte unsigned integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(uint value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of an 8-byte signed integer to the text stream.
		/// </summary>
		/// <param name="value">The 8-byte signed integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(long value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of an 8-byte unsigned integer to the text stream.
		/// </summary>
		/// <param name="value">The 8-byte unsigned integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(ulong value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a 4-byte floating-point value to the text stream.
		/// </summary>
		/// <param name="value">The 4-byte floating-point value to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(float value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of an 8-byte floating-point value to the text stream.
		/// </summary>
		/// <param name="value">The 8-byte floating-point value to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(double value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of a decimal value to the text stream.
		/// </summary>
		/// <param name="value">The decimal value to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(decimal value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes the text representation of an object to the text stream by calling ToString on that object.
		/// </summary>
		/// <param name="value">The object to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(object value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg0">An object to write into the formatted string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception><filterpriority>1</filterpriority>
		public void Write(string format, object arg0)
		{
			_writer.Write(format, arg0);
		}

		/// <summary>
		/// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg0">An object to write into the formatted string. </param><param name="arg1">An object to write into the formatted string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception><filterpriority>1</filterpriority>
		public void Write(string format, object arg0, object arg1)
		{
			_writer.Write(format, arg0, arg1);
		}

		/// <summary>
		/// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg0">An object to write into the formatted string. </param><param name="arg1">An object to write into the formatted string. </param><param name="arg2">An object to write into the formatted string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception><filterpriority>1</filterpriority>
		public void Write(string format, object arg0, object arg1, object arg2)
		{
			_writer.Write(format, arg0, arg1, arg2);
		}

		/// <summary>
		/// Writes out a formatted string, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg">The object array to write into the formatted string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> or <paramref name="arg"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to <paramref name="arg"/>. Length. </exception><filterpriority>1</filterpriority>
		public void Write(string format, params object[] arg)
		{
			_writer.Write(format, arg);
		}

		/// <summary>
		/// Writes a line terminator to the text stream.
		/// </summary>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine()
		{
			WriteIdentation();
			_writer.WriteLine();
		}

		/// <summary>
		/// Writes a character followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The character to write to the text stream. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(char value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes an array of characters followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="buffer">The character array from which data is read. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(char[] buffer)
		{
			WriteIdentation();
			_writer.WriteLine(buffer);
		}

		/// <summary>
		/// Writes a subarray of characters followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="buffer">The character array from which data is read. </param><param name="index">The index into <paramref name="buffer"/> at which to begin reading. </param><param name="count">The maximum number of characters to write. </param><exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>. </exception><exception cref="T:System.ArgumentNullException">The <paramref name="buffer"/> parameter is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(char[] buffer, int index, int count)
		{
			WriteIdentation();
			_writer.WriteLine(buffer, index, count);
		}

		/// <summary>
		/// Writes the text representation of a Boolean followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The Boolean to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(bool value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of a 4-byte signed integer followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The 4-byte signed integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(int value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of a 4-byte unsigned integer followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The 4-byte unsigned integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(uint value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of an 8-byte signed integer followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The 8-byte signed integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(long value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of an 8-byte unsigned integer followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The 8-byte unsigned integer to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(ulong value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of a 4-byte floating-point value followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The 4-byte floating-point value to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(float value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of a 8-byte floating-point value followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The 8-byte floating-point value to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(double value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of a decimal value followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The decimal value to write. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(decimal value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes a string followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The string to write. If <paramref name="value"/> is null, only the line termination characters are written. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(string value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes the text representation of an object by calling ToString on this object, followed by a line terminator to the text stream.
		/// </summary>
		/// <param name="value">The object to write. If <paramref name="value"/> is null, only the line termination characters are written. </param><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void WriteLine(object value)
		{
			WriteIdentation();
			_writer.WriteLine(value);
		}

		/// <summary>
		/// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatted string. </param><param name="arg0">The object to write into the formatted string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception><filterpriority>1</filterpriority>
		public void WriteLine(string format, object arg0)
		{
			WriteIdentation();
			_writer.WriteLine(format, arg0);
		}

		/// <summary>
		/// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg0">The object to write into the format string. </param><param name="arg1">The object to write into the format string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception><filterpriority>1</filterpriority>
		public void WriteLine(string format, object arg0, object arg1)
		{
			WriteIdentation();
			_writer.WriteLine(format, arg0, arg1);
		}

		/// <summary>
		/// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg0">The object to write into the format string. </param><param name="arg1">The object to write into the format string. </param><param name="arg2">The object to write into the format string. </param><exception cref="T:System.ArgumentNullException"><paramref name="format"/> is null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to the number of provided objects to be formatted. </exception><filterpriority>1</filterpriority>
		public void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			WriteIdentation();
			_writer.WriteLine(format, arg0, arg1, arg2);
		}

		/// <summary>
		/// Writes out a formatted string and a new line, using the same semantics as <see cref="M:System.String.Format(System.String,System.Object)"/>.
		/// </summary>
		/// <param name="format">The formatting string. </param><param name="arg">The object array to write into format string. </param><exception cref="T:System.ArgumentNullException">A string or object is passed in as null. </exception><exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextWriter"/> is closed. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.FormatException">The format specification in format is invalid.-or- The number indicating an argument to be formatted is less than zero, or larger than or equal to arg.Length. </exception><filterpriority>1</filterpriority>
		public void WriteLine(string format, params object[] arg)
		{
			WriteIdentation();
			_writer.WriteLine(format, arg);
		}

		/// <summary>
		/// Writes the identation.
		/// </summary>
		private void WriteIdentation()
		{
			for (int i = 0; i < IndentationLevel; i++)
			{
				_writer.Write('\t');
			}
		}

		/// <summary>
		/// Clears all buffers for the current writer and causes any buffered data to be written to the underlying stream.
		/// </summary>
		/// <exception cref="T:System.ObjectDisposedException">The current writer is closed. </exception><exception cref="T:System.IO.IOException">An I/O error has occurred. </exception><exception cref="T:System.Text.EncoderFallbackException">The current encoding does not support displaying half of a Unicode surrogate pair. </exception><filterpriority>1</filterpriority>
		public void Flush()
		{
			_writer.Flush();
		}

		/// <summary>
		/// Closes the current StreamWriter object and the underlying stream.
		/// </summary>
		/// <exception cref="T:System.Text.EncoderFallbackException">The current encoding does not support displaying half of a Unicode surrogate pair.</exception><filterpriority>1</filterpriority>
		public void Close()
		{
			_writer.Close();
		}

		/// <summary>
		/// Writes a string to the stream.
		/// </summary>
		/// <param name="value">The string to write to the stream. If <paramref name="value"/> is null, nothing is written. </param><exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and current writer is closed. </exception><exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"/> is at the end the stream. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><filterpriority>1</filterpriority>
		public void Write(string value)
		{
			_writer.Write(value);
		}

		/// <summary>
		/// Writes a subarray of characters to the stream.
		/// </summary>
		/// <param name="buffer">A character array containing the data to write. </param><param name="index">The index into <paramref name="buffer"/> at which to begin writing. </param><param name="count">The number of characters to read from <paramref name="buffer"/>. </param><exception cref="T:System.ArgumentNullException"><paramref name="buffer"/> is null. </exception><exception cref="T:System.ArgumentException">The buffer length minus <paramref name="index"/> is less than <paramref name="count"/>. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative. </exception><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and current writer is closed. </exception><exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"/> is at the end the stream. </exception><filterpriority>1</filterpriority>
		public void Write(char[] buffer, int index, int count)
		{
			_writer.Write(buffer, index, count);
		}

		/// <summary>
		/// Writes a character array to the stream.
		/// </summary>
		/// <param name="buffer">A character array containing the data to write. If <paramref name="buffer"/> is null, nothing is written. </param><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and current writer is closed. </exception><exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"/> is at the end the stream. </exception><filterpriority>1</filterpriority>
		public void Write(char[] buffer)
		{
			_writer.Write(buffer);
		}

		/// <summary>
		/// Writes a character to the stream.
		/// </summary>
		/// <param name="value">The character to write to the text stream. </param><exception cref="T:System.IO.IOException">An I/O error occurs. </exception><exception cref="T:System.ObjectDisposedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and current writer is closed. </exception><exception cref="T:System.NotSupportedException"><see cref="P:System.IO.StreamWriter.AutoFlush"/> is true or the <see cref="T:System.IO.StreamWriter"/> buffer is full, and the contents of the buffer cannot be written to the underlying fixed size stream because the <see cref="T:System.IO.StreamWriter"/> is at the end the stream. </exception><filterpriority>1</filterpriority>
		public void Write(char value)
		{
			_writer.Write(value);
		}
	}
}