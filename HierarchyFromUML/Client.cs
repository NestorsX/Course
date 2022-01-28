namespace HierarchyFromUML
{
    public class Client
    {
        private readonly IProductA _productA;
        private readonly IProductB _productB;

        public Client(IFactory factory)
        {
            _productA = factory.ProduceProductA();
            _productB = factory.ProduceProductB();
        }
    }
}
