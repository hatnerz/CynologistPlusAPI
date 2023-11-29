namespace WebAPI.DTO
{
    public class CreateOrderModel
    {
        public decimal OrderDate { get; set; }
        public string? Comment { get; set; }
        public int DogId { get; set; }
        public int DogTrainingCenterId { get; set; }
        public int TimeOffset { get; set; }
    }
}
