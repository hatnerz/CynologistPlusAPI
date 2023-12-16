namespace WebAPI.DTO
{
    public class CreateOrderModel
    {
        public string? Comment { get; set; }
        public int DogId { get; set; }
        public int DogTrainingCenterId { get; set; }
    }
}
