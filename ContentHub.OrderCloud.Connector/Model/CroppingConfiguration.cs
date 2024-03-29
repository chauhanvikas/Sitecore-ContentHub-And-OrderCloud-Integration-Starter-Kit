﻿

using System;
using Newtonsoft.Json;


namespace ContentHub.OrderCloud.Connector.Model
{
    /// <summary>
    ///     Represents a class with information about the way cropping has been performed
    ///     as part of <see cref="ConversionConfiguration"/>. 
    /// </summary>
    public class CroppingConfiguration
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="CroppingConfiguration"/>.
        /// </summary>
        /// <param name="croppingType">The type of the cropping that has been performed.</param>
        /// <param name="width">The output width.</param>
        /// <param name="height">The output height.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="croppingType"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="croppingType"/> is <see cref="string.Empty"/> or contains only whitespace characters.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="width"/> or <paramref name="height"/> is less than or equal to zero.
        /// </exception>
        public CroppingConfiguration(string croppingType, int width, int height)
        {
          

            CroppingType = croppingType;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets the type of the cropping that has been performed.
        /// </summary>
        [JsonProperty("cropping_type")]
        public string CroppingType { get; }

        /// <summary>
        /// Gets the output width.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the output height.
        /// </summary>
        public int Height { get; }
    }
}
