﻿namespace ApiMto.Dto
{
    public class CameraDataSheetDto
    {
        public string DataSheetName { get; set; }
        public string CameraId { get; set; }
        public IFormFile File { get; set; }
    }
}
