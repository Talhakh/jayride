namespace JayRideTest.DTO
{
    public class FilteredListingDto : Listing
    {
        public decimal TotalPrice { get; set; }
        public FilteredListingDto(string name, double pricePerPassenger, VehicleType vehicleType, decimal totalPrice) 
        {
            base.name = name;
            base.pricePerPassenger = pricePerPassenger;
            base.vehicleType = vehicleType; 
            TotalPrice= totalPrice;
        }
    }
}
