namespace FoxAdmTool.API.Models
{
    public class UserProduct
    {
        //joining entity class for a joining table.
        //User and Product entities should include a foreign key property and a reference navigation property for each entity.

        //their foreign key property
        public int UserId { get; set; }

        //reference navigation property
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}