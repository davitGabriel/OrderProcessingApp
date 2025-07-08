using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrderProcessingApp.Models
{
    // Base class for all entities
    public abstract class BaseEntity
    {
        // Unique identifier for the entity
        [JsonInclude]
        public int Id { get; set; }

        public abstract bool IsValid();
    }
}
