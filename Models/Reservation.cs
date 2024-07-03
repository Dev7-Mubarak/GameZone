
using GameZone.Models.Eunms;

namespace GameZone.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public virtual AppUser User { get; set; } = default!;
        public int RoomId { get; set; }
        public virtual Room Room { get; set; } = default!;
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public short NumberOfHours { get; set; }
        //public ReservationStatus Satuts { get; set; }
        public float TotalPrice { get; set; }
        public float Discount { get; set; }
        public int PaymentMethodID { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; } = default!;
        public string? DepositImage { get; set; } = string.Empty!;
    }
}
