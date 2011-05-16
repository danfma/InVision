using System.Collections.Generic;

namespace CodeGenerator.CSharp
{
    public class NamespaceComparer : IComparer<string>
    {
        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <returns>
        /// A signed integer that indicates the relative values of <paramref name="x"/> and <paramref name="y"/>, as shown in the following table.Value Meaning Less than zero<paramref name="x"/> is less than <paramref name="y"/>.Zero<paramref name="x"/> equals <paramref name="y"/>.Greater than zero<paramref name="x"/> is greater than <paramref name="y"/>.
        /// </returns>
        /// <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
        public int Compare(string x, string y)
        {
            bool xFromSystem = IsFromSystem(x);
            bool yFromSystem = IsFromSystem(y);

            if (xFromSystem && yFromSystem)
                return x.CompareTo(y);

            if (xFromSystem)
                return -1;

            if (yFromSystem)
                return 1;

            return x.CompareTo(y);
        }

        /// <summary>
        /// Determines whether [is from system] [the specified ns].
        /// </summary>
        /// <param name="ns">The ns.</param>
        /// <returns>
        /// 	<c>true</c> if [is from system] [the specified ns]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsFromSystem(string ns)
        {
            return ns.StartsWith("System");
        }
    }
}