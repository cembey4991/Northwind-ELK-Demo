namespace Elasticsearch.API.Entities
{
    public partial class CustomerCustomerDemo
    {
        public string? CustomerId { get; set; }
        public string? CustomerTypeId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual CustomerDemographics? CustomerType { get; set; }
    }
}
