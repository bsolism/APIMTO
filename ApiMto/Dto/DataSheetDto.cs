namespace ApiMto.Dto
{
    public class DataSheetDto
    {
        public string DataSheetName { get; set; }
        public string? DeviceId { get; set; }
        public IFormFile File { get; set; }
    }
}
