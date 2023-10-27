// <copyright file="MiniGameChangeEvent.Generated.cs" company="MUnique">
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
/// A plain implementation of <see cref="MiniGameChangeEvent"/>.
/// </summary>
public partial class MiniGameChangeEvent : MUnique.OpenMU.DataModel.Configuration.MiniGameChangeEvent, IIdentifiable, IConvertibleTo<MiniGameChangeEvent>
{
    
    /// <summary>
    /// Gets or sets the identifier of this instance.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets the raw collection of <see cref="TerrainChanges" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("terrainChanges")]
    public ICollection<MiniGameTerrainChange> RawTerrainChanges { get; } = new List<MiniGameTerrainChange>();
    
    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override ICollection<MUnique.OpenMU.DataModel.Configuration.MiniGameTerrainChange> TerrainChanges
    {
        get => base.TerrainChanges ??= new CollectionAdapter<MUnique.OpenMU.DataModel.Configuration.MiniGameTerrainChange, MiniGameTerrainChange>(this.RawTerrainChanges);
        protected set
        {
            this.TerrainChanges.Clear();
            foreach (var item in value)
            {
                this.TerrainChanges.Add(item);
            }
        }
    }

    /// <summary>
    /// Gets the raw object of <see cref="TargetDefinition" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("targetDefinition")]
    public MonsterDefinition RawTargetDefinition
    {
        get => base.TargetDefinition as MonsterDefinition;
        set => base.TargetDefinition = value;
    }

    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override MUnique.OpenMU.DataModel.Configuration.MonsterDefinition TargetDefinition
    {
        get => base.TargetDefinition;
        set => base.TargetDefinition = value;
    }

    /// <summary>
    /// Gets the raw object of <see cref="SpawnArea" />.
    /// </summary>
    [System.Text.Json.Serialization.JsonPropertyName("spawnArea")]
    public MonsterSpawnArea RawSpawnArea
    {
        get => base.SpawnArea as MonsterSpawnArea;
        set => base.SpawnArea = value;
    }

    /// <inheritdoc/>
    [System.Text.Json.Serialization.JsonIgnore]
    public override MUnique.OpenMU.DataModel.Configuration.MonsterSpawnArea SpawnArea
    {
        get => base.SpawnArea;
        set => base.SpawnArea = value;
    }

    /// <inheritdoc />
    public override MUnique.OpenMU.DataModel.Configuration.MiniGameChangeEvent Clone(MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
    {
        var clone = new MiniGameChangeEvent();
        clone.AssignValuesOf(this, gameConfiguration);
        return clone;
    }
    
    /// <inheritdoc />
    public override void AssignValuesOf(MUnique.OpenMU.DataModel.Configuration.MiniGameChangeEvent other, MUnique.OpenMU.DataModel.Configuration.GameConfiguration gameConfiguration)
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
    public MiniGameChangeEvent Convert() => this;
}
