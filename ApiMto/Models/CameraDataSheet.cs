﻿namespace ApiMto.Models
{
    public class CameraDataSheet
    {
        public int Id { get; set; }
        public string DataSheetName { get; set; }
        public string CameraId { get; set; }
        public Camera? Camera { get; set; }
    }
}
