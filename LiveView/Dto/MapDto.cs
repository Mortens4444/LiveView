using Database.Interfaces;
using Database.Models;
using System;
using System.Drawing;
using System.Linq;

namespace LiveView.Dto
{
    public class MapDto : IDisposable
    {
        ~MapDto()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (MapObjects != null)
            {
                for (var i = 0; i < MapObjects.Length; i++)
                {
                    MapObjects[i].Dispose();
                }
            }

            MapImage?.Dispose();
        }

        public long Id { get; private set; }

        public MapObjectDto[] MapObjects { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public int OriginalWidth { get; set; }

        public int OriginalHeight { get; set; }

        public Image MapImage { get; set; }

        public static MapDto FromModel(Map map, IActionObjectRepository actionObjectRepository)
        {
            return new MapDto
            {
                Id = map.Id,
                Name = map.Name,
                Comment = map.Comment,
                OriginalWidth = map.OriginalWidth,
                OriginalHeight = map.OriginalHeight,
                MapImage = Services.ImageConverter.ByteArrayToImage(map.MapImage),
                MapObjects = actionObjectRepository?.SelectWhere(new { map.Id }).Select(MapObjectDto.FromModel).ToArray()
            };
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
