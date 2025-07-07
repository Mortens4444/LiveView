using Database.Enums;
using Database.Models;
using System;
using System.Drawing;

namespace LiveView.Dto
{
    public class MapObjectDto : IDisposable
    {
        ~MapObjectDto()
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
            Image?.Dispose();
        }

        public int Id { get; set; } = -1;

        public MapActionType ActionType { get; set; } = MapActionType.NoAction;

        public long ActionReferencedId { get; set; } = -1;

        public string Comment { get; set; } = String.Empty;

        public Point Location { get; set; }

        public Size Size { get; set; }

        public Image Image { get; set; }

        public static MapObjectDto FromModel(ActionObject mapObject)
        {
            return new MapObjectDto
            {
                Id = mapObject.Id,
                Image = Services.ImageConverter.ByteArrayToImage(mapObject.Image),
                Location = new Point(mapObject.X, mapObject.Y),
                Size = new Size(mapObject.Width, mapObject.Height),
                ActionType = mapObject.ActionType,
                ActionReferencedId = mapObject.ActionReferencedId,
                Comment = mapObject.Comment
            };
        }
    }
}
