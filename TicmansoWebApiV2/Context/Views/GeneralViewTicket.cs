namespace TicmansoWebApiV2.Context.Views
{
    public class GeneralViewTicket
    {
        public int NumTicket { get; set; }

        public string Tittle { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CreationUser { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; } = null!;

        public string? SuportUser { get; set; } = null!;
    }
}
