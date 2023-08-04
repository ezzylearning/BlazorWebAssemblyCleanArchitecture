using BlazorWebAssemblyCleanArchitecture.Domain.Common.Interfaces;

using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWebAssemblyCleanArchitecture.Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; } 
    }
}
