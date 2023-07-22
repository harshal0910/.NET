namespace BOL
{
    public enum Category
    {
        CHIPS,BISCUITS,SOAP
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category category { get; set; }
        public double price { get; set; }

        public DateOnly mfgDate { get; set; }


        public Product(int id, string name, string description, Category category, double price, DateOnly mfgDate)
        {
            Id = id;
            Name = name;
            Description = description;
            this.category = category;
            this.price = price;
            this.mfgDate = mfgDate;
        }
        public Product() { }
    }
}