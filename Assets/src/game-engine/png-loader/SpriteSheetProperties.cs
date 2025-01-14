using System.IO;
using BigGustave;
using UnityEngine;

namespace ImageLoader
{
    public struct SpriteSheetData
    {
        public int SpriteSheetId;
        public int SpriteSheetType; //enum in src/enums
        public int Loaded;
        public int AccessCounter; //0 at creation, increment every blit or usage operation
        public Vector2Int Size;
        public int PixelFormat; //enum in src/enums, RGBA default

        #region FileProperties

        public string FileName; // Filename and path string
        public long Hash; // 64 bit xxHash of image file
        public string FileCreationTime; // time of file modification
        public long FileSize;
        public byte[] PixelsArray;

        #endregion

        public SpriteSheetData(Png pngData, string fileName, int spriteSheetId, int spriteSheetType, int loaded, int accessCounter,
            int pixelFormat, long hash) : this()
        {
            var fileInfo = new FileInfo(fileName);
            
            SpriteSheetId = spriteSheetId;
            SpriteSheetType = spriteSheetType;
            Loaded = loaded;
            AccessCounter = accessCounter;
            Size.x = pngData.Header.Width;
            Size.y = pngData.Header.Height;
            PixelFormat = pixelFormat;
            FileName = fileName;
            Hash = hash;
            FileCreationTime = fileInfo.CreationTime.ToString();
            FileSize = fileInfo.Length;
            CreatePixelsArray(pngData);
        }

        /// <summary>
        /// Creating byte array from PNG
        /// </summary>
        public void CreatePixelsArray(Png png)
        {
            PixelsArray = new byte[4 * Size.x * Size.y];
            
            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    var getPixels = png.GetPixel(x, y);
                    var index = y * Size.x + x;
                    PixelsArray[4 * index + 0] = getPixels.R;
                    PixelsArray[4 * index + 1] = getPixels.G;
                    PixelsArray[4 * index + 2] = getPixels.B;
                    PixelsArray[4 * index + 3] = getPixels.A;
                }
            }
        }
        
        /// <summary>
        /// Getting RGBA color bytes from index
        /// </summary>
        public Color32 GetColor(int x, int y)
        {
            int index = y * Size.x + x;
            
            var r = PixelsArray[4 * index + 0];
            var g = PixelsArray[4 * index + 1];
            var b = PixelsArray[4 * index + 2]; 
            var a = PixelsArray[4 * index + 3];

            return new Color32(r, g, b, a);
        }
    }
}
    
   

