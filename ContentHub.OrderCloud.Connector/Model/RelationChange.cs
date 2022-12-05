

using System;
using System.Collections.Generic;


namespace ContentHub.OrderCloud.Connector.Model
{
    /// <summary>
    ///     Represents a change in relations between Content Hub entities,
    ///     received as part of <see cref="Changeset"/>.
    /// </summary>
    public class RelationChange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationChange"/> class.
        /// </summary>
        /// <param name="relation">The relation between entities.</param>
        /// <param name="role">The role of relation.</param>
        /// <param name="cardinality">The cardinality of relation.</param>
        /// <param name="newValues">The collection of new values in relation.</param>
        /// <param name="removedValues">The collection of removed values from relation.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="relation"/>, <paramref name="newValues"/>, or <paramref name="removedValues"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="relation"/> is <see cref="string.Empty"/> or contains only whitespace characters.
        /// </exception>
        public RelationChange(string relation, int role, int cardinality,
            IReadOnlyList<int> newValues, IReadOnlyList<int> removedValues)
        {
         

            Relation = relation;
            Role = role;
            Cardinality = cardinality;
            NewValues = newValues;
            RemovedValues = removedValues;
        }

        /// <summary>
        /// Gets the relation between entities.
        /// </summary>
        public string Relation { get; }

        /// <summary>
        /// Gets the role of relation.
        /// </summary>
        public int Role { get; }

        /// <summary>
        /// Gets the cardinality of relation.
        /// </summary>
        public int Cardinality { get; }

        /// <summary>
        /// Gets the collection of new values in relation.
        /// </summary>
        public IReadOnlyList<int> NewValues { get; }

        /// <summary>
        /// Gets the collection of removed values from relation.
        /// </summary>
        public IReadOnlyList<int> RemovedValues { get; }
    }
}
