﻿using Enums;

//TODO: Move all sprite structs to TileSpriteManager, out of PlanetTileMap

namespace PlanetTileMap
{
    struct Sprite
    {
        public string Name;
        public int Left;//position in atlas
        public int Top;//position in atlas
        //TODO: remove these
        public int Width; //Why do we have this? Width is always 32 pixels
        public int Height; //Why do we have this? Width always 32 pixels
        public int[,] Texture;
        public PlanetTileLayer Layer;
    }
}