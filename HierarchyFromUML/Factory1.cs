namespace HierarchyFromUML
{
    public class Factory1 : IFactory
    {
        public IProductA ProduceProductA()
        {
            return new ProductA1();
        }

        public IProductB ProduceProductB()
        {
            return new ProductB1();
        }
    }
}
