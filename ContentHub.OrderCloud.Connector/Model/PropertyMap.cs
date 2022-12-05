

using System;


namespace ContentHub.OrderCloud.Connector.Model
{
    /// <summary>
    /// Represents a mapping between property names.
    /// </summary>
    public class PropertyMap
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyMap"/> class.
        /// </summary>
        /// <param name="fromProperty">The source property for mapping.</param>
        /// <param name="toProperty">The target property for mapping.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="fromProperty"/> or <paramref name="toProperty"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="fromProperty"/> or <paramref name="toProperty"/> is <see cref="string.Empty"/>
        ///     or contains only whitespace characters.
        /// </exception>
        public PropertyMap(string fromProperty, string toProperty)
        {
          

            FromProperty = fromProperty;
            ToProperty = toProperty;
        }

        /// <summary>
        /// Gets the source property for mapping.
        /// </summary>
        public string FromProperty { get; }

        /// <summary>
        /// Gets the target property for mapping.
        /// </summary>
        public string ToProperty { get; }
    }
}
