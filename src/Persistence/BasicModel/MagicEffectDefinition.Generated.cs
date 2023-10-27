// <copyright file="MagicEffectDefinition.Generated.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

//------------------------------------------------------------------------------
// <auto-generated>
//     This source code was auto-generated by a roslyn code generator.
// </auto-generated>
//------------------------------------------------------------------------------

// ReSharper disable All

namespace MUnique.OpenMU.Persistence.BasicModel;

using MUnique.OpenMU.Persistence.Json;

/// <summary>
/// A plain implementation of <see cref="MagicEffectDefinition"/>.
/// </summary>
public partial class MagicEffectDefinition : MUnique.OpenMU.DataModel.Configuration.MagicEffectDefinition, IIdentifiable, IConvertibleTo<MagicEffectDefinition>
{
    
    /// <summary>
    /// Gets or sets the identifier of this instance.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the raw collection of <see cref="PowerUpDefinitions" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("powerUpDefinitions")]
    public ICollection<PowerUpDefinition> RawPowerUpDefinitions { get; } = new List<PowerUpDefinition>();
    
    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override ICollection<MUnique.OpenMU.DataModel.Attributes.PowerUpDefinition> PowerUpDefinitions
    {
        get => base.PowerUpDefinitions ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Attributes.PowerUpDefinition, PowerUpDefinition>(this.RawPowerUpDefinitions);
        protected set
        {
            this.PowerUpDefinitions.Clear();
            foreach (var item in value)
            {
                this.PowerUpDefinitions.Add(item);
            }
        }
    }

    /// <summary>
    /// Gets the raw object of <see cref="Duration" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("duration")]
    public PowerUpDefinitionValue RawDuration
    {
        get => base.Duration as PowerUpDefinitionValue;
        set => base.Duration = value;
    }

    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override MUnique.OpenMU.DataModel.Attributes.PowerUpDefinitionValue Duration
    {
        get => base.Duration;
        set => base.Duration = value;
    }

    /// <inheritdoc />
    public override MUnique.OpenMU.DataModel.Configuration.MagicEffectDefinition Clone(MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
    {
        var clone = new MagicEffectDefinition();
        clone.AssignValuesOf(this, gameConfiguration);
        return clone;
    }
    
    /// <inheritdoc />
    public override void AssignValuesOf(MUnique.OpenMU.DataModel.Configuration.MagicEffectDefinition other, MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
    {
        base.AssignValuesOf(other, gameConfiguration);
        this.Id = other.GetId();
    }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        var baseObject = obj as IIdentifiable;
        if (baseObject != null)
        {
            return baseObject.Id == this.Id;
        }

        return base.Equals(obj);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    /// <inheritdoc/>
    public MagicEffectDefinition Convert() => this;
}
