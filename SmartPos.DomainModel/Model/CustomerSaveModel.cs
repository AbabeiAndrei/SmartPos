namespace SmartPos.DomainModel.Model
{
    public class CustomerSaveModel
    {
        public int CreatedBy { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        /// <inheritdoc />
        public CustomerSaveModel()
        {
        }

        public CustomerSaveModel(string name, string address)
            : this()
        {
            Name = name;
            Address = address;
        }
    }
}
