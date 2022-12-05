

using System;


namespace ContentHub.OrderCloud.Connector.Model
{
    /// <summary>
    /// Represents a ratio of <see cref="ConversionConfiguration"/>.
    /// </summary>
    public class Ratio
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Ratio"/>.
        /// </summary>
        /// <param name="name">The name of the <see cref="Ratio"/>.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="name"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="name"/> is <see cref="string.Empty"/> or contains only whitespace characters.
        /// </exception>
        public Ratio(string name)
        {
          
            Name = name;
        }

        /// <summary>
        /// Gets the name of the <see cref="Ratio"/>.
        /// </summary>
        public string Name { get; }
    }
}
