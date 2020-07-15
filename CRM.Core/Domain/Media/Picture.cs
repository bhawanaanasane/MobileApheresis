using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.Domain.Media
{
    public partial class Picture : BaseEntity
    {

        /// <summary>
        /// Gets or sets the picture binary
        /// </summary>
        public byte[] PictureBinary { get; set; }

        /// <summary>
        /// Gets or sets the picture mime type
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the "alt" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// </summary>
        public string AltAttribute { get; set; }

        /// <summary>
        /// Gets or sets the "title" attribute for "img" HTML element. If empty, then a default rule will be used (e.g. product name)
        /// </summary>
        public string TitleAttribute { get; set; }

        /// <summary>
        /// Gets or sets the picture Name
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// Gets or sets the picture Path
        /// </summary>
        public string Picturepath { get; set; }

        /// <summary>
        /// Gets or sets the tumbnail binary
        /// </summary>
        public byte[] ThumbnailBinary { get; set; }
    }
}
