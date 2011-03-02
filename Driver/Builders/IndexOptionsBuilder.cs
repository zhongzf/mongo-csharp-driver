﻿/* Copyright 2010-2011 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace MongoDB.Driver.Builders {
    /// <summary>
    /// Represents an instance of IMongoIndexOptions that was created using a builder.
    /// </summary>
    public static class IndexOptions {
        #region public static properties
        /// <summary>
        /// Gets a null value with a type of IMongoIndexOptions.
        /// </summary>
        public static IMongoIndexOptions Null {
            get { return null; }
        }
        #endregion

        #region public static methods
        /// <summary>
        /// Sets whether to build the index in the background.
        /// </summary>
        /// <param name="value">Whether to build the index in the background.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public static IndexOptionsBuilder SetBackground(
            bool value
        ) {
            return new IndexOptionsBuilder().SetBackground(value);
        }

        /// <summary>
        /// Sets whether duplicates should be dropped.
        /// </summary>
        /// <param name="value">Whether duplicates should be dropped.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public static IndexOptionsBuilder SetDropDups(
            bool value
        ) {
            return new IndexOptionsBuilder().SetDropDups(value);
        }

        /// <summary>
        /// Sets the geospatial range.
        /// </summary>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public static IndexOptionsBuilder SetGeoSpatialRange(
            double min,
            double max
        ) {
            return new IndexOptionsBuilder().SetGeoSpatialRange(min, max);
        }

        /// <summary>
        /// Sets the name of the index.
        /// </summary>
        /// <param name="value">The name of the index.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public static IndexOptionsBuilder SetName(
            string value
        ) {
            return new IndexOptionsBuilder().SetName(value);
        }

        /// <summary>
        /// Sets whether the index enforces unique values.
        /// </summary>
        /// <param name="value">Whether the index enforces unique values.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public static IndexOptionsBuilder SetUnique(
            bool value
        ) {
            return new IndexOptionsBuilder().SetUnique(value);
        }

        /// <summary>
        /// Wraps an object so that it can be used where an IMongoIndexOptions is expected (the wrapped object is expected to serialize properly).
        /// </summary>
        /// <param name="options">The wrapped object.</param>
        /// <returns>A IndexOptionsWrapper.</returns>
        public static IMongoIndexOptions Wrap(
            object options
        ) {
            return IndexOptionsWrapper.Create(options);
        }
        #endregion
    }

    /// <summary>
    /// Represents an instance of IMongoIndexOptions that was created using a builder.
    /// </summary>
    [Serializable]
    public class IndexOptionsBuilder : BuilderBase, IMongoIndexOptions {
        #region private fields
        private BsonDocument document;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the IndexOptionsBuilder class.
        /// </summary>
        public IndexOptionsBuilder() {
            document = new BsonDocument();
        }
        #endregion

        #region public methods
        /// <summary>
        /// Sets whether to build the index in the background.
        /// </summary>
        /// <param name="value">Whether to build the index in the background.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public IndexOptionsBuilder SetBackground(
            bool value
        ) {
            document["background"] = value;
            return this;
        }

        /// <summary>
        /// Sets whether duplicates should be dropped.
        /// </summary>
        /// <param name="value">Whether duplicates should be dropped.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public IndexOptionsBuilder SetDropDups(
            bool value
        ) {
            document["dropDups"] = value;
            return this;
        }

        /// <summary>
        /// Sets the geospatial range.
        /// </summary>
        /// <param name="min">The min value of the range.</param>
        /// <param name="max">The max value of the range.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public IndexOptionsBuilder SetGeoSpatialRange(
            double min,
            double max
        ) {
            document["min"] = min;
            document["max"] = max;
            return this;
        }

        /// <summary>
        /// Sets the name of the index.
        /// </summary>
        /// <param name="value">The name of the index.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public IndexOptionsBuilder SetName(
            string value
        ) {
            document["name"] = value;
            return this;
        }

        /// <summary>
        /// Sets whether the index enforces unique values.
        /// </summary>
        /// <param name="value">Whether the index enforces unique values.</param>
        /// <returns>The builder (so method calls can be chained).</returns>
        public IndexOptionsBuilder SetUnique(
            bool value
        ) {
            document["unique"] = value;
            return this;
        }

        /// <summary>
        /// Returns the result of the builder as a BsonDocument.
        /// </summary>
        /// <returns>A BsonDocument.</returns>
        public override BsonDocument ToBsonDocument() {
            return document;
        }
        #endregion

        #region protected methods
        /// <summary>
        /// Serializes the result of the builder to a BsonWriter.
        /// </summary>
        /// <param name="bsonWriter">The writer.</param>
        /// <param name="nominalType">The nominal type.</param>
        /// <param name="options">The serialization options.</param>
        protected override void Serialize(
            BsonWriter bsonWriter,
            Type nominalType,
            IBsonSerializationOptions options
        ) {
            document.Serialize(bsonWriter, nominalType, options);
        }
        #endregion
    }
}
