//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int GameObject = 0;
    public const int Particle = 1;
    public const int Position = 2;

    public const int TotalComponents = 3;

    public static readonly string[] componentNames = {
        "GameObject",
        "Particle",
        "Position"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(src.ecs.Game.Particle.ParticleSpawn.GameObjectComponent),
        typeof(src.ecs.Game.Particle.ParticleSpawn.ParticleComponent),
        typeof(src.ecs.Game.Particle.ParticleSpawn.PositionComponent)
    };
}
