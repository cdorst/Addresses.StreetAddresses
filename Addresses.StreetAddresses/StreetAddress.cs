// Copyright © Christopher Dorst. All rights reserved.
// Licensed under the GNU General Public License, Version 3.0. See the LICENSE document in the repository root for license information.

using Addresses.StreetAddressLines;
using DevOps.Code.Entities.Interfaces.StaticEntity;
using Position = ProtoBuf.ProtoMemberAttribute;
using ProtoBufSerializable = ProtoBuf.ProtoContractAttribute;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Addresses.StreetAddresses
{
    /// <summary>Contains street address line information</summary>
    [ProtoBufSerializable]
    [Table("StreetAddresses", Schema = "Addresses")]
    public class StreetAddress : IStaticEntity<StreetAddress, int>
    {
        public StreetAddress()
        {
        }

        public StreetAddress(StreetAddressLine addressLine1, StreetAddressLine addressLine2)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
        }

        /// <summary>Contains AddressLine1 reference</summary>
        [Position(3)]
        public StreetAddressLine AddressLine1 { get; set; }

        /// <summary>Contains AddressLine1 foreign key</summary>
        [Position(2)]
        public int AddressLine1Id { get; set; }

        /// <summary>Contains AddressLine2 reference</summary>
        [Position(5)]
        public StreetAddressLine AddressLine2 { get; set; }

        /// <summary>Contains AddressLine2 foreign key</summary>
        [Position(4)]
        public int AddressLine2Id { get; set; }

        /// <summary>StreetAddress unique identifier (primary key)</summary>
        [Key]
        [Position(1)]
        public int StreetAddressId { get; set; }

        /// <summary>Returns a value that uniquely identifies this entity type. Each entity type in the model has a unique identifier</summary>
        public int GetEntityType() => 7;

        /// <summary>Returns the entity's unique identifier</summary>
        public int GetKey() => StreetAddressId;

        /// <summary>Returns an expression defining this entity's unique index (alternate key)</summary>
        public Expression<Func<StreetAddress, object>> GetUniqueIndex() => entity => new { entity.AddressLine1Id, entity.AddressLine2Id };
    }
}
